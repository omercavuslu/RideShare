using System.ComponentModel.DataAnnotations.Schema;

namespace RideShare.Entity
{
    public class ReservationDataModel : BaseEntity
    {
        [ForeignKey("Ride")]
        public int rideId { get; set; }
        public RideDataModel ride { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool isActive { get; set; }

    }
}
