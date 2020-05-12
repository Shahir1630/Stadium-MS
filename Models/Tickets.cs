using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.Models
{
    public class Tickets
    {
        [Key]
        public Int64 TicketNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 GameNo { get; set; }
        public string Catagory  { get; set; }
        public string SeatNo  { get; set; }
        public string Zone  { get; set; }
    }
}
