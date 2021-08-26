using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppAPI.EF
{
    public partial class MeterReading
    {
        public string AccountId { get; set; }
        public DateTime? MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }
}
