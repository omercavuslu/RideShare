﻿using System;
using System.Collections.Generic;

namespace RideShare.ViewModel
{
    public class RideViewModel
    {
        public string from { get; set; }
        public string to { get; set; }
        public DateTime Date { get; set; }
        public string description { get; set; }
        public int seat { get; set; }
        public bool isActive { get; set; }
        public ICollection<ReservationViewModel>? Reservations { get; set; }
    }
}
