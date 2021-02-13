using System;

namespace RideShare.ViewModel
{
    public class RideCreateViewModel
    {
        public string from { get; set; }
        public string to { get; set; }
        public DateTime Date { get; set; }
        public string description { get; set; }
        public int seat { get; set; }
    }
}
