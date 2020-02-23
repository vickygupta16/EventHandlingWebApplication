using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EHWA6.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        [Required]
        [Display(Name="Name")]
        public string OrganizationName { get; set; }
        [Required]
        [Display(Name="Contact")]
        public string OrganizationContact { get; set; }
        [Required]
        [Display(Name="Email ID")]
        public string OrganizationEmail { get; set; }
        [Required]
        [Display(Name="Address")]
        public string OrganizationAddress { get; set; }
        public virtual ICollection<Events> evs { get; set; }
    }
}