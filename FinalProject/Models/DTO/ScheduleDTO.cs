using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class ScheduleDTO
    {
        public Int32 S_id { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Unit { get; set; }
        public string Room { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Professor { get; set; }
    }
}