using Capgemini.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Domain.Interfaces.Services
{
    public interface IOneSignalService
    {
        Task<CreateNotificationModel> PostOneSignal(CreateNotificationModel oneSignal);
    }
}
