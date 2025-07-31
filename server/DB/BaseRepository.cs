using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

namespace DB
{


    public class BaseRepository<TEntity> where TEntity : class

        {

        private readonly TaskManagerContext context;

        public virtual IQueryable<TEntity> Items { get; set; }



            public BaseRepository(TaskManagerContext context)

            {
                this.context = context;
                Items = context.Set<TEntity>().AsQueryable();
            }



        public virtual async Task<EntityEntry<TEntity>> Add(TEntity entity, bool AllowAnonymous = false)
        {
            try
            {
                var res = await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving entity: " + ex.Message);
                throw; // אל תשכח לזרוק שוב, כדי שה-API יחזיר 500 אמיתי עם פרטים
            }
        

    }
        
        //public virtual async Task<string> GetIdByCode(long requestCode)
        //{
        //   var WeaponRequests = await context.WeaponRequests.FirstOrDefaultAsync(x => x.Code == requestCode);
        //   var id= WeaponRequests?.Id;
        //   return id;
        //}
        //public async Task<object> GetName(int code)
        //{
        //    string id = await GetIdByCode(code);

        //    var applicant = await context.ApplicantDetails.FirstOrDefaultAsync(x => x.Id == id);

        //    if (applicant == null)
        //        return null;

        //    return new
        //    {
        //        tz = applicant.Id,
        //        name = $"{applicant.FirstName} {applicant.LastName}"
        //    };
        //}


        //public async Task<List<AllRequestsDTO>> GetAllRequests()
        //{
        //    //var allRequests = await (from request in context.WeaponRequests
        //    //                         join applicant in context.ApplicantDetails on request.Id equals applicant.Id
        //    //                         join status in context.RequestStatuses on  request.Status equals status.Code 
        //    //                         select new AllRequestsDTO
        //    //                         {
        //    //                             RequestDate = request.DateOfRequest,
        //    //                             ApplicantName = applicant.FirstName + " " + applicant.LastName,
        //    //                             NameUnit = applicant.UnitName,
        //    //                             Facility = request.Facility,
        //    //                             ApplicationStatus = status.Description,
        //    //                             Completed = request.Status == 9,
        //    //                             Code = (int)request.Code
        //    //                         }).ToListAsync();

        //    //return allRequests;
        //    var allRequests = await (from request in context.WeaponRequests
        //                             join applicant in context.ApplicantDetails on request.Id equals applicant.Id
        //                             join status in context.RequestStatuses on request.Status equals status.Code
        //                             orderby request.DateOfRequest descending 
        //                             select new AllRequestsDTO
        //                             {
        //                                 RequestDate = request.DateOfRequest,
        //                                 ApplicantName = applicant.FirstName + " " + applicant.LastName,
        //                                 NameUnit = applicant.UnitName,
        //                                 Facility = request.Facility,
        //                                 ApplicationStatus = status.Description,
        //                                 Completed = request.Status == 9,
        //                                 Code = (int)request.Code
        //                             }).ToListAsync();

        //    return allRequests;

        //}
        //public async Task<List<WeaponDTO>> GetWeapon()
        //{
         
        //                var weapons= await (
        //                            from w in context.Weapons
        //                            join wt in context.WeaponTypes on w.WeaponType equals wt.Code
        //                            join m in context.Manufacturers on w.Manufacturer equals m.Code
        //                            join c in context.Calibers on w.Caliber equals c.Code
        //                            join p in context.Productions on w.Production equals p.Code
        //                            join s in context.WeaponStatuses on w.Status equals s.Code

        //                            join e in context.WeaponToEmployees on w.Id equals e.WeaponId into eGroup
        //                            from e in eGroup.DefaultIfEmpty()
        //                            join a in context.ApplicantDetails on e.Id equals a.Id into aGroup
        //                            from a in aGroup.DefaultIfEmpty()

        //                            select new WeaponDTO
        //                            {
        //                                Id = w.Id,
        //                                WeaponType = wt.Description,
        //                                Manufacturer = m.Description,
        //                                Caliber = c.Description,
        //                                Production = p.Description,
        //                                Status = s.Description,
        //                                AssignedToEmployee = (s.Description == "מושאל" && a != null) ? string.Concat(a.FirstName, " ", a.LastName): null
        //                            }).ToListAsync();



        //    return weapons;
        //}


        public virtual async Task<EntityEntry<TEntity>> Update(TEntity entity)

            {
            var key = GetKey();
            var keyValue = key.FieldInfo.GetValue(entity);

            var curEntity = context.Set<TEntity>().Find(keyValue);
            context.Entry(curEntity).State = EntityState.Detached;
            Console.WriteLine($"[Before Save] Status = {entity}");

            var updatedEntry = context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync(); 
            Console.WriteLine($"[After Save] Status = {updatedEntry.Entity}");

            return updatedEntry;

            }

            public virtual async Task<EntityEntry<TEntity>> Delete(TEntity entity)

            {

                var result= context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return result;

        }



        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))

            {

                return context.SaveChangesAsync(cancellationToken);

            }



            //public async Task<EntityEntry<TEntity>> AddOrUpdate(TEntity entity, Guid curUserId)

            //{

            //    var key = GetKey();

            //    var keyValue = key.FieldInfo.GetValue(entity);

            //    if (key.ClrType == typeof(Guid) && IsNew((Guid?)keyValue) || keyValue == null || (key.ClrType == typeof(int) && (int)keyValue == 0))

            //    {

            //        if (key.ClrType == typeof(Guid) && IsNew((Guid?)keyValue))

            //            key.FieldInfo.SetValue(entity, Guid.NewGuid());

            //        return Add(entity, curUserId);

            //    }



            //    return Update(entity, curUserId);

            //}



            private IProperty GetKey(IEntityType entityType = null)

            {

                if (entityType == null)

                    entityType = context.Model.FindEntityType(typeof(TEntity));

                return entityType.FindPrimaryKey().Properties[0];

            }
        public virtual async Task<TEntity> GetById(object id)
        {
            try
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    Console.WriteLine($"Entity of type {typeof(TEntity).Name} with ID {id} not found.");
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving entity: " + ex.Message);
                throw;
            }
        }


        public bool IsNew(Guid? key)

            {

                return key == null || key == Guid.Empty;

            }



            public virtual void DeleteRange(IEnumerable<TEntity> entities)

            {

                context.Set<TEntity>().RemoveRange(entities);

            }

        }

    }

