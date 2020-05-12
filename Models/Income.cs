using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.Models
{
    public class Income
    {
        public Int64 Id { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public Int64 BookingCost { get; set; }
        public Int64 Advance { get; set; }
        public Int64 Due { get; set; }
        /// public Int64 BookingCost { get; set; }
    }
}
