namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var typeOfAirplane = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == type);

            return (IAirplane)Activator.CreateInstance(typeOfAirplane);
        }
	}
}