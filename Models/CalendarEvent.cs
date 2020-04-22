using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace petOwnerOneStopShop.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        public string Title { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Delete { get; set; }
        public int ColorId { get; set; }
        public IEnumerable<string> Attendees { get; set; }
        [ForeignKey("Calendar")]
        public int? CalendarId { get; set; }
        public Calendar Calendar { get; set; }
    }
}
