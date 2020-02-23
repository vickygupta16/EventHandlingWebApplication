using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHWA6.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public int EventsId { get; set; }
        public virtual Events evs { get; set; }
        public int UserId { get; set; }
        public virtual UserProfile ups { get; set; }
    }
}