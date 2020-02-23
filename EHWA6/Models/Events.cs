using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EHWA6.Models
{
    public class Events
    {
        public int EventsId { get; set; }
        [Required]
        [Display(Name="Name")]
        public string EventName { get; set; }
        [Required]
        [Display(Name="Date")]
        public string EventDate { get; set; }
        [Required]
        [Display(Name="Time")]
        public string EventTiming { get; set; }
        [Required]
        [Display(Name="Duration")]
        public string EventDuration { get; set; }
        [Required]
        [Display(Name="Venue")]
        public string EventVenue { get; set; }
        [Required]
        [Display(Name="Capacity")]
        public int EventCapacity { get; set; }
        [Required]
        [Display(Name="Organization Name")]
        public int OrganizationId { get; set; }
        public virtual Organization orgs { get; set; }
        public virtual ICollection<Volunteer> vols { get; set; }
    }
}