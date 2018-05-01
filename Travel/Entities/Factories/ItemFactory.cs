namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var typeOfAirplane = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == type);

            return (IItem)Activator.CreateInstance(typeOfAirplane);
        }
	}
}
