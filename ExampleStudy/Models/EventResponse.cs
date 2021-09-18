using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Business.Models
{
    public class EventResponse<T>  where T: class
    {
        [JsonProperty(PropertyName = "meta")]
        public JObject Meta { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        [JsonProperty(PropertyName = "responseStatus")]
        public JObject ResponseStatus { get; set; }

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<T> Results { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

    }
}
