namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> checkedInBags;
        private List<IBag> confiscatedBags;
        private List<ITrip> trips;
        private List<IPassenger> passengers;
        public Airport()
        {
            this.checkedInBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.passengers = new List<IPassenger>();
        }
        public IReadOnlyCollection<IBag> CheckedInBags => checkedInBags;

        public IReadOnlyCollection<IBag> ConfiscatedBags => confiscatedBags;

        public IReadOnlyCollection<IPassenger> Passengers => passengers;

        public IReadOnlyCollection<ITrip> Trips =>trips;

        public void AddCheckedBag(IBag bag)
        {
            this.checkedInBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.confiscatedBags.Add(bag);
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public IPassenger GetPassenger(string username)
        {
            IPassenger passengerToReturn = (Passenger)this.passengers.FirstOrDefault(p => p.Username == username);
            return passengerToReturn;
        }

        public ITrip GetTrip(string id)
        {
            return (ITrip)this.trips.Where(t => t.Id == id);
        }
        
    }
}