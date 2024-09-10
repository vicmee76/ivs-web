using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Events
{
    public class UpcomingEventsDto
    {
        public string _id { get; set; }
        public string ivsEventId { get; set; }
        public DateTime startDateAndTime { get; set; }
        public DateTime endDateAndTime { get; set; }
        public string eventName { get; set; }
        public string eventAddress { get; set; }
        public string eventState { get; set; }
        public string eventOption { get; set; }
        public DateTime createdAt { get; set; }
        public int attendeesCount { get; set; }

    }
}
