using Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
  public  class RiseAssesstmentContext :DbContext
    {
        public RiseAssesstmentContext(DbContextOptions<RiseAssesstmentContext> options) : base(options)
        {

        }
      
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ReportStatus> ReportStatuses { get; set; }
        public DbSet<Report> Reports { get; set; }

         
    }
}
