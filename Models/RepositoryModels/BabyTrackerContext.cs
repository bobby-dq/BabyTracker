using Microsoft.EntityFrameworkCore;

namespace BabyTracker.Models.RepositoryModels
{
    public class BabyTrackerContext: DbContext
    {
        public BabyTrackerContext(DbContextOptions<BabyTrackerContext> opts) : base(opts) {}

        public DbSet<Infant> Infants {get; set;}
        public DbSet<Feeding> Feedings {get;set;}
        public DbSet<Growth> Growths {get; set;}
        public DbSet<Medication> Medications {get; set;}
        public DbSet<Sleep> Sleeps {get; set;}
        public DbSet<Diaper> Diapers {get; set;}

    }
}