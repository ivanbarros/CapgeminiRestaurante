using Capgemini.Domain.DTOs;
using Capgemini.Domain.Entities;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task<LogDTO> AddLog(LogDTO log);
    }
}
