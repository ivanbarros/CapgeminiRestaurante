using Capgemini.Domain.Interfaces.Services;
using Capgemini.Domain.Models;
using Capgemini.Infra.Helpers.OneSignal;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Capgemini.Infra.Services
{
    public class OneSignalService : IOneSignalService
    {
        protected readonly IConfiguration _configuration;

        public OneSignalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CreateNotificationModel> PostOneSignal(CreateNotificationModel oneSignal)
        {
            try
            {
                Guid appKeyId = Guid.Parse(_configuration["OneSignal:appKeyId"]);
                string RestKey = _configuration["OneSignal:RestKey"];

                if (String.IsNullOrEmpty(oneSignal.TemplateName) || oneSignal.TemplateName == "string")
                {

                    await OneSignalPushNotificationHelper.OneSignalPushNotification(oneSignal, appKeyId, RestKey);
                }
                if (oneSignal.TemplateName != null && oneSignal.TemplateName != "string")
                {

                    await OneSignalPushNotificationHelper.OneSignalPushNotificationByTemplate(oneSignal, appKeyId, RestKey);
                }

                     

                return oneSignal;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
