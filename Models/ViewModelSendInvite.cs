using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PawentsOneStopShop.Models
{
    public class ViewModelSendInvite
    {
        public int EventId { get; set; }
        [Display(Name = "Event Name")]
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Details { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int HostCalendarId { get; set; }
        public ObjectCalendar ObjectCalendar { get; set; }
        public int Id { get; set; }
        public bool? isInvitationAccepted { get; set; }
        [Display(Name = "Event")]
        public int? ObjectEventId { get; set; }
        public ObjectEvent ObjectEvent { get; set; }
        public int? OwnerSendingId { get; set; }
        public int? OwnerInvitedId { get; set; }
        public PetProfile PetProfile { get; set; }
        public int PetProfileId { get; set; }
    }
}
