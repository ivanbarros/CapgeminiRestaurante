using Capgemini.Domain.Models;
using Capgemini.Domain.Notifications;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneSignal.RestAPIv3.Client;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Capgemini.Infra.Helpers.OneSignal
{
    public class OneSignalPushNotificationHelper
    {
        public static async Task<string> OneSignalPushNotification(CreateNotificationModel request, Guid appkey, string restkey)
        {
            try
            {
                var client = new OneSignalClient(restkey);
                var opt = new NotificationCreateOptions()
                {

                    AppId = appkey,
                    IncludePlayerIds = request.PlayersId,
                    Priority = 10
                };

                opt.Url = request.LinkUrl;
                opt.Headings.Add(LanguageCodes.English, request.Title);
                opt.Contents.Add(LanguageCodes.English, request.Content);
                opt.Priority = 10;
                NotificationCreateResult result = await client.Notifications.CreateAsync(opt);
                return result.Recipients.ToString();
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }
        public static async Task<string> OneSignalPushNotificationByTemplate(CreateNotificationModel request, Guid appkey, string restkey)
        {
            NotificationCreateResult result = null;
            try
            {
                var templates = await OneSignalGetTemplates(appkey, restkey);
                var client = new OneSignalClient(restkey);

                foreach (var item in templates)
                {
                    if (request.TemplateName == item.Name)
                    {
                        request.TemplateId = item.Id;
                    }
                }

                if (String.IsNullOrEmpty(request.Title) || request.Title == "string")
                {
                    var opt = new NotificationCreateOptions()
                    {
                        AppId = appkey,
                        IncludePlayerIds = request.PlayersId,
                        TemplateId = request.TemplateId,


                    };
                    result = await client.Notifications.CreateAsync(opt);
                }
                else
                {
                    var opt = new NotificationCreateOptions()
                    {
                        AppId = appkey,
                        IncludePlayerIds = request.PlayersId,
                        TemplateId = request.TemplateId,
                    };
                    opt.Url = request.LinkUrl;
                    opt.Headings.Add(LanguageCodes.English, request.Title);
                    opt.Contents.Add(LanguageCodes.English, request.Content);
                    result = await client.Notifications.CreateAsync(opt);
                }



                return result.Recipients.ToString();
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.Message);
            }
        }
        public static async Task<IEnumerable<TemplatesListVm>> OneSignalGetTemplates(Guid appKey, string restKey)
        {
            try
            {
                var appId = appKey;
                string webrequest = $"https://onesignal.com/api/v1/templates?app_id={appId}&limit=50&offset=0";

                using (var client = new HttpClient())
                {
                    var auth = client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", restKey);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseMessage = await client.GetAsync(webrequest);
                    var data = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new DomainException(JObject.Parse(data)["mensagem"].ToString());
                    }

                    var listModel = JsonConvert.DeserializeObject(data);
                    JObject json = JObject.Parse(data);
                    var result = from p in json["templates"]
                                 select new TemplatesListVm()
                                 {
                                     Id = (string)p["id"],
                                     Name = (string)p["name"]

                                 };

                    listModel = result.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
