using Newtonsoft.Json;
using Scheduler.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Scheduler.Business.Services.Interfaces;

namespace Scheduler.Business.Services
{
    public class EventService : IEventService
    {
        public List<Event> GetEventsNotFinished(Notification result)
        {
            try
            {
                var eventResponse = JsonConvert.DeserializeObject<EventResponse<Event>>(result.Data.ToString());
                return eventResponse.Results
                        .Where(e => e?.EndDate >= DateTime.Today)
                        .OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public Event GetFirstEvent(Notification result)
        {
            try
            {
                var eventResponse = JsonConvert.DeserializeObject<EventResponse<Event>>(result.Data.ToString());
                return eventResponse.Results?.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Competition> GetCompetitions(Notification result)
        {
            try
            {
                var eventResponse = JsonConvert.DeserializeObject<EventResponse<Competition>>(result.Data.ToString());
                return eventResponse.Results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Round> GetRounds(Notification result)
        {
            try
            {
                var eventResponse = JsonConvert.DeserializeObject<EventResponse<Round>>(result.Data.ToString());
                return eventResponse.Results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
