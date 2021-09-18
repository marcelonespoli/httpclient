using System.Net;

namespace Scheduler.Business.Models
{
    public class Notification
    {
        public HttpStatusCode Statuscode { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Error { get; set; }

        public Notification()
        {
            Statuscode = 0;
            Success = false;
            Data = "";
            Error = "";
        }
    }
}
