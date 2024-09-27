using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        IList<Traveller> GetPassengers(Plane p);
        IList<Flight> GetFlights(int n);

        bool ReserverFlight(int n ,Flight flight);

        void SupprimerPlane(DateTime date);

    }
}
