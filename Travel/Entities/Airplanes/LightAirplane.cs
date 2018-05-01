namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
        private const int maxSeats = 5;
        private const int maxBags = 8;
		public LightAirplane()
			: base(seats: maxSeats, bags: maxBags)
		{
		}
	}
}