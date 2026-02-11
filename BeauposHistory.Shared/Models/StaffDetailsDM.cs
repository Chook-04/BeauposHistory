using System;
using System.Collections.Generic;
using System.Text;

namespace BeauposHistory.Shared.Models
{
    public class StaffDetailsDM
    {
        public string StaffId { get; set; } = " ";
        public string Name { get; set; } = " ";
        public string PhoneNumber { get; set; } = " ";
        public decimal EffortPercentage { get; set; }
        public decimal Value { get; set; } = 0.00m;
        public decimal HofPercentage { get; set; } = 0.00m;
        public string PhotoUrl { get; set; } = " ";
    }
}
