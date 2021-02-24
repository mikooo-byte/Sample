using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class ResetCodeDTO
    {
        public Int32 RC_Id { get; set; }
        public string Studentnum { get; set; }
        public string Code { get; set; }
    }
}