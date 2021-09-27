using BasicCRUD.Business.Utilities.Logger;
using BasicCRUD.Business.Utilities.Logger.Enums;
using BasicCRUD.Business.Utilities.Logger.Models;
using BasicCRUD.Entities.Concrete.DataModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicCRUD.WebAPI.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
       
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,ILoggerManager _IloggerManager)
        {
            string responseBodyString = string.Empty;
            LogInfoEnum logInfoEnum = LogInfoEnum.Success;
            LogData logData = null;
            try
            {
               logData = new(context);
                using (var memStream = new MemoryStream())
                {
                    Stream originalResponseBody = context.Response.Body;
                    using MemoryStream replacementResponseBody = new MemoryStream();
                    context.Response.Body = replacementResponseBody;

                    await _next(context);

                    replacementResponseBody.Position = 0;
                    await replacementResponseBody.CopyToAsync(originalResponseBody).ConfigureAwait(false);
                    context.Response.Body = originalResponseBody;

                    if (replacementResponseBody.CanRead)
                    {
                        replacementResponseBody.Position = 0;
                        responseBodyString = new StreamReader(replacementResponseBody, leaveOpen: true).ReadToEndAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                        replacementResponseBody.Position = 0;
                    }
                }
               
            }
            catch (Exception ex)
            {
                logData.SetError(new ErrorResponse { 
                    StackTrace=ex.StackTrace,
                    ErrorMessage=ex.Message
                });
                logInfoEnum = LogInfoEnum.Error;
            }
            finally
            {
                string bodyContent = responseBodyString;
           
                logData.SetResponse(new Response
                {

                    Body = bodyContent,
                    StatusCode = context.Response.StatusCode,
                    ResponseDateTime = DateTime.Now,
                    
                });
                AppLog appLog=new AppLog
                {
                     Data=JsonSerializer.Serialize(logData),
                      CreatedDate=DateTime.Now,
                      LogInfo=(int) logInfoEnum
                };
               await _IloggerManager.WriteLog(appLog);
              
               
            }
        }
    }
}
