using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.Entity
{
    public class RideDataModel : BaseEntity
    {
        public string from { get; set; }
        public string to { get; set; }
        public DateTime Date { get; set; }
        public string description { get; set; }
        public int seat { get; set; }
        public bool isActive { get; set; }
        public ICollection<ReservationDataModel>? Reservations { get; set; }
    }
}
