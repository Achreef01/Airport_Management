using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AfficherNbreTravellers(DateTime date1, DateTime date2)
        {
            var query=GetMany(f=>f.FlightDate>=date1&& f.FlightDate<=date2)
                .SelectMany(f=>f.Tickets)
                .GroupBy(t=>t.MyFlight.FlightDate)
                .Select(t => new {date=t.Key, nbre=t.Count()});

            foreach(var item in query)
            {
                Console.WriteLine("Date vol= "+ item.date
                    + " Nombre voyageurs= "+ item.nbre);
            }






        }

        public IList<Staff> GetStaff(int id)
        {
           return GetById(id)
                .Tickets
                .Select(t=>t.MyPassenger)
                .OfType<Staff>()
                .ToList();
        }

        public IList<Traveller> GetTravellers(Plane plane, DateTime date)
        {
            return GetMany(f => f.MyPlane == plane && f.FlightDate == date)
                .SelectMany(f => f.Tickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .ToList();
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}
