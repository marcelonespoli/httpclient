using Newtonsoft.Json;
using System.ComponentModel;

namespace Scheduler.Business.Models
{
    public class Competition
    {
        [JsonProperty(PropertyName = "competitionId")]
        public int CompetitionId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "seasonId")]
        public int SeasonId { get; set; }

        [JsonProperty(PropertyName = "eventId")]
        public int EventId { get; set; }

        [JsonProperty(PropertyName = "eventName")]
        public string EventName { get; set; }

        [JsonProperty(PropertyName = "eventOfficialName")]
        public string EventOfficialName { get; set; }

        [JsonProperty(PropertyName = "eventShortName")]
        public string EventShortName { get; set; }

        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }
    }
}
