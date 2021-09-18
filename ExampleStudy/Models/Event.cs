using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Business.Models
{
    public class Event
    {
        [JsonProperty(PropertyName = "eventId")]
        public int EventId { get; set; }      

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "logoImageName")]
        public string LogoImageName { get; set; }

        [JsonProperty(PropertyName = "manageSubEvent")]
        public Boolean ManageSubEvent { get; set; }
    }
}
