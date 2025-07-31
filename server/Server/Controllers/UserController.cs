using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<ActionResult> AddApplicantAll([FromBody] ApplicantDetailAllDTO dto)
        //{
        //    try
        //    {
        //        if (dto == null)
        //            return BadRequest(new { success = false, message = "הנתונים שהתקבלו אינם תקינים." });

        //        var applicant = dto.applicantDetail;
        //        var service = dto.serviceDetail;
        //        var weapon = dto.weaponRequest;

        //        if (applicant == null || service == null || weapon == null)
        //            return BadRequest(new { success = false, message = "חובה למלא את כל חלקי הבקשה." });

        //        var existingApplicant = await _ApplicantDetailService.GetById(applicant.Id);

        //        if (existingApplicant != null)
        //        {
        //            var updatedApplicant = await _ApplicantDetailService.Update(applicant);
        //            var updatedService = await _ServiceDetailService.Update(service);

        //            weapon.Code = weapon.Code == 0 ? (await context.WeaponRequests.AnyAsync() ? await context.WeaponRequests.MaxAsync(x => x.Code) + 1 : 1) : weapon.Code;
        //            weapon.DateOfRequest ??= DateTime.Now;

        //            var updatedWeapon = await _WeaponRequestService.Add(weapon);

        //            if (updatedApplicant == null || updatedService == null || updatedWeapon == null)
        //                return StatusCode(500, new { success = false, message = "שגיאה בשמירת הנתונים." });

        //            return Ok(new { success = true, message = "הבקשה עודכנה בהצלחה." });
        //        }
        //        else
        //        {
        //            var addedApplicant = await _ApplicantDetailService.Add(applicant);
        //            var addedService = await _ServiceDetailService.Add(service);

        //            weapon.Code = weapon.Code == 0 ? (await context.WeaponRequests.AnyAsync() ? await context.WeaponRequests.MaxAsync(x => x.Code) + 1 : 1) : weapon.Code;
        //            weapon.DateOfRequest ??= DateTime.Now;

        //            var addedWeapon = await _WeaponRequestService.Add(weapon);

        //            if (addedApplicant == null || addedService == null || addedWeapon == null)
        //                return StatusCode(500, new { success = false, message = "שגיאה בהוספת הבקשה." });

        //            return Ok(new { success = true, message = "הבקשה נוספה בהצלחה." });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "שגיאה בלתי צפויה בעת שמירת בקשה חדשה");
        //        return StatusCode(500, new { success = false, message = $"שגיאה בלתי צפויה: {ex.Message}" });
        //    }
        //}


        //[HttpGet()]
        //public IEnumerable<WeatherForecast> Get()
        //{

        //}
    }
}
