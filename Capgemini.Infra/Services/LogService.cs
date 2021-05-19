using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;

        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }

        public async Task<LogDTO> AddLog(LogDTO log)
        {
            var result = await _repository.AddLog(log);
            return result;
        }
    }
}
