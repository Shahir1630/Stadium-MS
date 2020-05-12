using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.Models
{
    public class Account
    {
        [Key]
        public Int64 No { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string TransactionType { get; set; }
        public string Categories { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 Amount { get; set; }
        public String Email { get; set; }
        public String Gameno { get; set; }
    }
   
}
