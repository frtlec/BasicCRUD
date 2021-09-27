using System;

namespace BasicCRUD.Business.Utilities.Logger.Models
{
    public class Response
    {
        public DateTime ResponseDateTime { get; set; }
        public int StatusCode { get; set; }
        public string Body { get; set; }
    }
}
