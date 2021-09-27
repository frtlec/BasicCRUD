using System;

namespace BasicCRUD.Business.Utilities.Logger.Models
{
    public class Request {


        public DateTime RequestDateTime { get; set; }
        public string Method { get; set; }
        public string Query { get; set; }
        public string Body { get; set; }
        public string Params { get; set; }
        public string Path { get; set; }
    }
}
