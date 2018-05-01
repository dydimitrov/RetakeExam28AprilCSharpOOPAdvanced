// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void TestValidConstructor()
	    {
            var passengers = new[]
            {
                new Passenger("Pesho"),
                new Passenger("Gosho"),
                new Passenger("Vanio"),
                new Passenger("Penka"),
                new Passenger("Penka0"),
                new Passenger("Penka1")
            };

            var airplane = new LightAirplane();
            foreach (var passenger in passengers)
            {
                airplane.AddPassenger(passenger);
            }
            var trip = new Trip("Sofia", "London", airplane);

            var airport = new Airport();

            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            var bag = new Bag(passengers[1], new[] { new Colombian() });
            passengers[1].Bags.Add(bag);

            var completedTrip = new Trip("Sofia", "London", new LightAirplane());
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            var actualResult = flightController.TakeOff();
            
                var expectedResult = @"SofiaLondon1:
Overbooked! Ejected Gosho
Confiscated 1 bags ($50000)
Successfully transported 5 passengers from Sofia to London.
Confiscated bags: 1 (1 items) => $50000";
            Assert.That(actualResult, Is.EqualTo(expectedResult).NoClip);
            Assert.That(trip.IsCompleted, Is.True);
        }
    }
}
