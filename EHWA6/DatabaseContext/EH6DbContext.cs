using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EHWA6.Models;

namespace EHWA6.DatabaseContext
{
    public class EH6DbContext:System.Data.Entity.DbContext
    {
        public EH6DbContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<Organization> orgs { get; set; }
        public System.Data.Entity.DbSet<Events> evs { get; set; }
        public System.Data.Entity.DbSet<Volunteer> vols { get; set; }

        public System.Data.Entity.DbSet<UserProfile> UserProfiles { get; set; }

    }
}