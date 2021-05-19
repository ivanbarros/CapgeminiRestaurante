using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using Capgemini.Domain.Interfaces.Repositories;
using Capgemini.Domain.UnitOfWork;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LogDTO> AddLog(LogDTO log)
        {
            await _unitOfWork.Connection.ExecuteAsync($@"INSERT INTO log
                            (
                    Method_Name, ErrorMessage, ErrorDay)
                    VALUES
                    (
                    @Method_Name,
                    @ErrorMessage,
                    @ErrorDay);"
            , log
         , commandType: CommandType.Text, transaction: _unitOfWork.Transaction);
            return log;

        }
    }
}
