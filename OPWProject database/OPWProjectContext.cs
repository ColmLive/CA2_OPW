using OPWProject1.Pages.Models;
using System.Data.Entity;

namespace OPWProject_database
{
    class OPWProjectContext : DbContext
    {
       public DbSet<Property> PropertyContext { get; set; }
       public DbSet<Authorisation> AuthorisationContext { get; set; }
       public DbSet<Building_Works> WorksContext { get; set; }
    }
}
