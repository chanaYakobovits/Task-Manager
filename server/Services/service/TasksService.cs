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
using Services.Iservice;
using AutoMapper;


namespace Services.Services
{
    public class TasksService : ITasksService
    {
        private readonly BaseRepository<Tasks> _BaseRepository;

        private readonly ILogger<TasksService> _logger;

        private readonly IMapper _mapper;

        // c-tor
        public TasksService(
            BaseRepository<Tasks> BaseRepository,IMapper mapper,ILogger<TasksService> logger)
        {
            _BaseRepository = BaseRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TasksDTO>> Get()
        {
            _logger.LogInformation("התחלה: שליפת כלל פרטי המועמדים (GetAll)");

            try
            {
                var details = await _BaseRepository.Items.ToListAsync();

                if (details != null)
                {
                    var result = _mapper.Map<IEnumerable<TasksDTO>>(details);
                    _logger.LogInformation(": נמצאו {Count} משימות ", result.Count());
                    return result;
                }
                else
                {
                    _logger.LogWarning("לא נמצאו משימות.");
                    return Enumerable.Empty<TasksDTO>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת כלל המשימות");
                return Enumerable.Empty<TasksDTO>();
            }
        }

    }

}
