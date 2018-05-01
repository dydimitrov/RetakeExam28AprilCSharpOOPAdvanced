namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
		private List<IBag> items;
		private List<IPassenger> passengers;
		public Airplane(int seats, int bags)
        {
			this.passengers = new List<IPassenger>();
			this.Seats = seats;
			this.BaggageCompartments = bags;
			this.items = new List<IBag>();
		}
		public int Seats { get; }
		public int BaggageCompartments { get; }
		public IReadOnlyCollection<IBag> BaggageCompartment => this.items;

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

		public bool IsOverbooked => this.Passengers.Count() > this.Seats;        
        
        public void AddPassenger(IPassenger passenger)
        {
			this.passengers.Add(passenger);
		}

		public IPassenger RemovePassenger(int seatIndex)
        {
            var currentPassenger = this.passengers[seatIndex];
            this.passengers.RemoveAt(seatIndex);		

			return (IPassenger)currentPassenger;
		}

		public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
			var passengerBags = this.items
				.Where(b => b.Owner == passenger)
				.ToArray();

			foreach (var bag in passengerBags)
            {
                this.items.Remove(bag);
            }
			return passengerBags;
		}

		public void LoadBag(IBag bag)
        {
			var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;

			if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");
            }
            this.items.Add(bag);
		}
        
    }
}