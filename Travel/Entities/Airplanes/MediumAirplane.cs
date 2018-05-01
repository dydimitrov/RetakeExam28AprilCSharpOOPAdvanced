namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
        private const int maxSeats = 10;
        private const int maxBags = 14;
        public MediumAirplane()
			: base(seats: maxSeats, bags: maxBags)
		{
		}
	}
}