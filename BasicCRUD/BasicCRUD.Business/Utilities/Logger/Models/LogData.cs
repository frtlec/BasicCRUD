using BasicCRUD.Core.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Utilities.Logger.Models
{
    public class LogData
    {
        public LogData(HttpContext httpContext)
        {
            this.RemoteIP = httpContext.Connection.RemoteIpAddress.ToString();
            this.UserName = httpContext.User.ClaimUserName();


            string body = GetBodyString(httpContext).Result;
            this.Request = new Request
            {
                Query = httpContext.Request.QueryString.Value,
                RequestDateTime = DateTime.Now,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Body = body,

            };
        }
        private async Task<string> GetBodyString(HttpContext httpContext)
        {
            string bodyString = string.Empty;
            using (StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8))
            {
                bodyString = await reader.ReadToEndAsync();
            }
            return bodyString;
        }
        public void SetResponse(Response response)
        {
            this.Response = response;
        }
        public void SetError(ErrorResponse err)
        {
            this.ErrorResponse = err;
        }
        public string RemoteIP { get; private set; }
        public string UserName { get; private set; }
        public Response Response { get; private set; }
        public Request Request { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }
    }
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
