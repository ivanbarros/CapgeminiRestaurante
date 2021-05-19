using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Apresentation.Filter
{
    public class RemovePropertyFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var response = context.HttpContext.Response;

            new StreamReader(response.Body).ReadToEnd();

            var request = context.HttpContext.Request;

            if (request.Path.Value.Contains("Notifications"))
            {
                var stream = request.Body;
                var originalContent = new StreamReader(stream).ReadToEnd();
                var notModified = true;

                try
                {
                    var dataSource = JsonConvert.DeserializeObject<dynamic>(originalContent);
                    if (dataSource != null && dataSource.Take > 2000)
                    {
                        dataSource.Take = 2000;
                        var json = JsonConvert.SerializeObject(dataSource);
                        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                        stream = await requestContent.ReadAsStreamAsync();
                        notModified = false;
                    }
                }
                catch
                {
                    //No-op or log error
                }
                if (notModified)
                {
                    //put original data back for the downstream to read
                    var requestData = Encoding.UTF8.GetBytes(originalContent);
                    stream = new MemoryStream(requestData);
                }

                request.Body = stream;
            }

            await next();
        }
    }
}