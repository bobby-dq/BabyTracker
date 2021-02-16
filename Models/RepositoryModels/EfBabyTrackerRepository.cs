using System.Linq;

namespace BabyTracker.Models.RepositoryModels
{
    public class EfBabyTrackerRepository: IBabyTrackerRepository
    {
        private BabyTrackerContext context;
        public EfBabyTrackerRepository(BabyTrackerContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Infant> Infants => context.Infants;
        public IQueryable<Feeding> Feedings => context.Feedings;
        public IQueryable<Growth> Growths => context.Growths;
        public IQueryable<Medication> Medications => context.Medications;
        public IQueryable<Sleep> Sleeps => context.Sleeps;
        public IQueryable<Diaper> Diapers => context.Diapers;
    }
}