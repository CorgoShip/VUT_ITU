using System;

namespace App1.ResFormat
{
    public struct Reservation
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Vehicle { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string CreatedBy { get; set; }
        public string EndTime { get; set; }
        public string Comment { get; set; }

    }
}