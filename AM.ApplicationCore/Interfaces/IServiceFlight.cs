using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        IList<Staff> GetStaff(int id);
        IList<Traveller> GetTravellers(Plane plane, DateTime date);
        void AfficherNbreTravellers(DateTime date1, DateTime date2);
        IEnumerable<Flight> SortFlights();

    }
}
