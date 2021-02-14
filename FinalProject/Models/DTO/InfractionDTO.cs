using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class InfractionDTO
    {
        public int Infr_Id { get; set; }
        public string Studentnum { get; set; }
        public string Library { get; set; }
        public string L_inf { get; set; }
        public string Health { get; set; }
        public string H_inf { get; set; }
        public string Osas { get; set; }
        public string O_inf { get; set; }
        public string Registrar { get; set; }
        public string R_inf { get; set; }
    }
}