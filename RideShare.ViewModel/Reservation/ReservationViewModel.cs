namespace RideShare.ViewModel
{
    public class ReservationViewModel
    {
        public int rideId { get; set; }
        public RideViewModel ride { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool isActive { get; set; }
    }
}
