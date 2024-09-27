using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork _unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<Flight> GetFlights(int n)
        {
            return _unitOfWork.Repository<Plane>().GetAll()
                .OrderByDescending(p=>p.PlaneId)
                .Take(n)
                .SelectMany(p=>p.Flights)
                .ToList();  

        }

        public IList<Traveller> GetPassengers(Plane p)
        {
            return (_unitOfWork.Repository<Plane>().GetById(p.PlaneId).Flights
                .SelectMany(f=>f.Tickets)
                .Select(f => f.MyPassenger)
                .OfType<Traveller>()
                .ToList());
    }

        public bool ReserverFlight(int n, Flight flight)
        {
            int capacity = flight.MyPlane.Capacity;
            int nbreTickets = flight.Tickets.Count();

            return capacity- nbreTickets >= n;
        }

        public void SupprimerPlane(DateTime date)
        {
            foreach (var plane in GetMany(p=>DateTime.Now.Year
                                                -p.ManufactureDate.Year>10))
            {
                Delete(plane);
                Commit();

            }
        }

        //public IList<Staff> GetStaff(int id)
        //{
        //    return _unitOfWork.Repository<Flight>().GetById(id)
        //         .Tickets
        //         .Select(t => t.MyPassenger)
        //         .OfType<Staff>()
        //         .ToList();
        //}
    }
}
