using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.Models
{
    public class Cost
    {
        [Key]
        public Int64 Id { get; set; }
        public string MonthName { get; set; }
        public DateTime Date { get; set; }
        public string ReasoneOfCost { get; set; }
        public Int64 Amounnt { get; set; }
       /// public Int64 BookingCost { get; set; }

    }
}
