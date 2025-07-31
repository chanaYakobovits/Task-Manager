using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Model;
using Models.DTO;
using AutoMapper;


namespace Services.Services
{
    public class UserService : Iservice.IUserService
    {
        private readonly BaseRepository<User> _BaseRepository;
        
        private readonly ILogger<UserService> _logger;
        
        // c-tor
        public UserService(
            BaseRepository<User> BaseRepository,
           
            ILogger<UserService> logger)
        {
            _BaseRepository = BaseRepository;
           
            _logger = logger;
        }

        //public async Task<IEnumerable<ApplicantDetailDTO>> GetAll()
        //{
        //    _logger.LogInformation("התחלה: שליפת כלל פרטי המועמדים (GetAll)");

        //    try
        //    {
        //        var details = await _BaseRepository.Items.ToListAsync();

        //        if (details != null)
        //        {
        //            var result = _mapper.Map<IEnumerable<ApplicantDetailDTO>>(details);
        //            _logger.LogInformation("הצלחה: נמצאו {Count} פרטי מועמדים", result.Count());
        //            return result;
        //        }
        //        else
        //        {
        //            _logger.LogWarning("לא נמצאו פרטי מועמדים.");
        //            return Enumerable.Empty<ApplicantDetailDTO>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בשליפת כלל פרטי המועמדים");
        //        return Enumerable.Empty<ApplicantDetailDTO>();
        //    }
        //}

        //public async Task<ApplicantDetailDTO> GetByRequestCode(long requestCode)
        //{
        //    _logger.LogInformation("התחלה: שליפת מועמד לפי קוד בקשה {RequestCode}", requestCode);

        //    try
        //    {
        //        var result = await (from w in _context.WeaponRequests
        //                            where w.Code == requestCode
        //                            join a in _context.ApplicantDetails on w.Id equals a.Id
        //                            select a).FirstOrDefaultAsync();

        //        if (result == null)
        //        {
        //            _logger.LogWarning("לא נמצא מועמד עבור קוד בקשה {RequestCode}", requestCode);
        //            return null;
        //        }

        //        var applicantDTO = _mapper.Map<ApplicantDetailDTO>(result);
        //        applicantDTO.CountryOfBirth = await mirshamRepository.GetCountryById(applicantDTO.CountryOfBirth.ToString());
        //        applicantDTO.UnitManagerName = _ActiveDirectoryService.GetManagerNameByEmail(applicantDTO.UnitManagerEmail);

        //        _logger.LogInformation("הצלחה: נמצא מועמד עבור קוד בקשה {RequestCode}", requestCode);
        //        return applicantDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בשליפת פרטי מועמד לפי קוד בקשה {RequestCode}", requestCode);
        //        throw new ApplicationException("Error while look for ApplicantDetailDTO by requestCode", ex);
        //    }
        //}

        //public async Task<IEnumerable<AllRequestsDTO>> GetAllRequests()
        //{
        //    _logger.LogInformation("התחלה: שליפת כל הבקשות.");

        //    try
        //    {
        //        var allRequest = await _BaseRepository.GetAllRequests();
        //        if (allRequest != null)
        //        {
        //            _logger.LogInformation("הצלחה: נמצאו {Count} בקשות.", allRequest.Count());
        //            return allRequest;
        //        }

        //        _logger.LogWarning("לא נמצאו בקשות.");
        //        return Enumerable.Empty<AllRequestsDTO>();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בעת שליפת כל הבקשות.");
        //        return Enumerable.Empty<AllRequestsDTO>();
        //    }
        //}

        //public async Task<ApplicantDetailDTO?> GetById(string id)
        //{
        //    _logger.LogInformation("התחלה: שליפת מועמד לפי מזהה {Id}.", id);

        //    try
        //    {
        //        var entity = await _BaseRepository.Items.FirstOrDefaultAsync(a => a.Id == id);

        //        if (entity != null)
        //        {
        //            var dto = _mapper.Map<ApplicantDetailDTO>(entity);
        //            _logger.LogInformation("הצלחה: נמצא מועמד עבור מזהה {Id}.", id);
        //            return dto;
        //        }

        //        _logger.LogWarning("לא נמצא מועמד עבור מזהה {Id}.", id);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בעת שליפת מועמד לפי מזהה {Id}.", id);
        //        return null;
        //    }
        //}

        //public async Task<UserDTO> Add(UserDTO UserDTO)
        //{
        //    _logger.LogInformation("התחלה: הוספת מועמד חדש.");

            //try
            //{
               
            //    //var detail = _mapper.Map<ApplicantDetail>(applicantDetailDTO);

            //    if (code != 0)
            //    {
            //        detail.CountryOfBirth = (int)code;
            //    }

            //    var newDetails = await _BaseRepository.Add(detail);
            //    var result = _mapper.Map<ApplicantDetailDTO>(newDetails.Entity);

            //    _logger.LogInformation("הצלחה: מועמד נוסף (ID={Id}).", result.Id);
            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "שגיאה בעת הוספת מועמד.");
            //    throw new ApplicationException("Error while adding details", ex);
            //}
        }

        //public async Task<ApplicantDetailDTO> Delete(string id)
        //{
        //    _logger.LogInformation("התחלה: מחיקת מועמד {Id}.", id);

        //    try
        //    {
        //        var detailDTO = await _BaseRepository.Items.FirstOrDefaultAsync(d => d.Id == id);
        //        if (detailDTO == null)
        //        {
        //            _logger.LogWarning("לא נמצא מועמד למחיקה (Id={Id}).", id);
        //            return null;
        //        }

        //        var newDetails = await _BaseRepository.Delete(detailDTO);
        //        var detailDTO1 = _mapper.Map<ApplicantDetailDTO>(newDetails.Entity);

        //        _logger.LogInformation("הצלחה: מועמד נמחק (Id={Id}).", id);
        //        return detailDTO1;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בעת מחיקת מועמד (Id={Id}).", id);
        //        throw new ApplicationException("Error while deleting details", ex);
        //    }
        //}

        //public async Task<ApplicantDetailDTO> Update(ApplicantDetailDTO applicantDetailDTO)
        //{
        //    _logger.LogInformation("התחלה: עדכון מועמד {Id}.", applicantDetailDTO.Id);

        //    try
        //    {
        //        var code = await mirshamRepository.GetCountryByHebrewName(applicantDetailDTO.CountryOfBirth);
        //        var detail = _mapper.Map<ApplicantDetail>(applicantDetailDTO);

        //        if (code != 0)
        //        {
        //            detail.CountryOfBirth = (int)code;
        //        }

        //        var newDetails = await _BaseRepository.Update(detail);
        //        var result = _mapper.Map<ApplicantDetailDTO>(newDetails.Entity);

        //        _logger.LogInformation("הצלחה: מועמד עודכן (Id={Id}).", result.Id);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בעת עדכון מועמד (Id={Id}).", applicantDetailDTO.Id);
        //        throw new ApplicationException("Error while updating details", ex);
        //    }
        //}

        //public async Task<ApplicantDetailDTO> UpdateRequestFields(string id, string email, string phone)
        //{
        //    _logger.LogInformation("התחלה: עדכון שדות טופס למועמד {Id}.", id);

        //    try
        //    {
        //        var applicantDetailDTO = await _BaseRepository.Items.FirstOrDefaultAsync(x => x.Id == id);
        //        applicantDetailDTO.Phone = phone;
        //        applicantDetailDTO.Email = email;

        //        var updateApplicantDetail = await _BaseRepository.Update(applicantDetailDTO);
        //        var result = _mapper.Map<ApplicantDetailDTO>(updateApplicantDetail.Entity);

        //        _logger.LogInformation("הצלחה: שדות עודכנו למועמד {Id}.", id);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בעת עדכון שדות טופס למועמד {Id}.", id);
        //        throw new ApplicationException("Error while updating details", ex);
        //    }
        //}

        //public async Task<string> GetNameById(string id)
        //{
        //    _logger.LogInformation("התחלה: שליפת שם לפי מזהה {Id}.", id);

        //    var applicantDetail = await _BaseRepository.Items.FirstOrDefaultAsync(x => x.Id == id);
        //    if (applicantDetail != null)
        //    {
        //        var fullName = applicantDetail.FirstName + " " + applicantDetail.LastName;
        //        _logger.LogInformation("הצלחה: שם נמצא עבור {Id}: {Name}.", id, fullName);
        //        return fullName;
        //    }

        //    _logger.LogWarning("לא נמצא שם עבור מזהה {Id}.", id);
        //    return null;
        //}

        //public async Task<string> GetEmailById(string id)
        //{
        //    _logger.LogInformation("התחלה: שליפת אימייל לפי מזהה {Id}.", id);

        //    var applicantDetail = await _BaseRepository.Items.FirstOrDefaultAsync(x => x.Id == id);
        //    if (applicantDetail != null)
        //    {
        //        _logger.LogInformation("הצלחה: אימייל נמצא עבור {Id}.", id);
        //        return applicantDetail.UnitManagerEmail;
        //    }

        //    _logger.LogWarning("לא נמצא אימייל עבור מזהה {Id}.", id);
        //    return null;
        //}


    }

//}
