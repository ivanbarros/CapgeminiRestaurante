﻿using Capgemini.Domain.DTOs;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface ILogService
    {
        Task<LogDTO> AddLog(LogDTO log);
    }
}
