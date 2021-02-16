using System.Linq;

namespace BabyTracker.Models.RepositoryModels
{
    public interface IBabyTrackerRepository
    {
        IQueryable<Infant> Infants {get;}
        IQueryable<Feeding> Feedings {get;}
        IQueryable<Growth> Growths {get;}
        IQueryable<Medication> Medications {get;}
        IQueryable<Sleep> Sleeps {get;}
        IQueryable<Diaper> Diapers {get;}
    }
}