using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Model;
namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatBotController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ChatRequest request)
        {
            // כאן ננתח את הטקסט וניצור משימה
            var task = ParseMessage(request.Text);

            // לשמור למסד נתונים
            //SaveTask(task);
            return Ok(task);
            //return Ok(new { response = $"הוספתי את המשימה: {task.Title} לתאריך {task.DueDate:dd/MM/yyyy}" });
        }
        private TaskItem ParseMessage(string text)
        {
           
            var title = "";
            var description = "";
            var dueDate = DateTime.Now.AddDays(1); 

            
            if (text.Contains("ביום"))
            {
                var parts = text.Split("ביום");
                title = parts[0].Replace("תזכיר לי", "").Trim();
                description = parts.Length > 1 ? parts[1].Trim() : "";
                dueDate = ParseHebrewDayToDate(description);
            }

            return new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate
            };
        }
        private DateTime ParseHebrewDayToDate(string dayHebrew)
        {
            var today = DateTime.Today;
            var daysOfWeek = new Dictionary<string, DayOfWeek>
    {
        {"ראשון", DayOfWeek.Sunday},
        {"שני", DayOfWeek.Monday},
        {"שלישי", DayOfWeek.Tuesday},
        {"רביעי", DayOfWeek.Wednesday},
        {"חמישי", DayOfWeek.Thursday},
        {"שישי", DayOfWeek.Friday},
        {"שבת", DayOfWeek.Saturday}
    };

            foreach (var kvp in daysOfWeek)
            {
                if (dayHebrew.Contains(kvp.Key))
                {
                    int daysUntil = ((int)kvp.Value - (int)today.DayOfWeek + 7) % 7;
                    return today.AddDays(daysUntil == 0 ? 7 : daysUntil); // תמיד לשבוע הבא אם היום זה אותו יום
                }
            }

            return today.AddDays(1); // ברירת מחדל – מחר
        }
        //private void SaveTask(TaskItem task)
        //{
            //var entity = new TaskEntity
            //{
            //    Title = task.Title,
            //    Description = task.Description,
            //    DueDate = task.DueDate
            //};

            //_context.Tasks.Add(entity);
            //_context.SaveChanges();
        //}


    }

}
