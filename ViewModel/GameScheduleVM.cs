using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StadiumManagementSys.ViewModel
{
    public class GameScheduleVM
    {
        [Key]
        public Int64 GameNo { get; set; }
        public string Tournament { get; set; }
        public string TourGameNo { get; set; }
        public DateTime GameTime { get; set; }
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }
    }
}
