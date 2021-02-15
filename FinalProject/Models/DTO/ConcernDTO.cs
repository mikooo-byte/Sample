using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class ConcernDTO
    {
        public int C_id { get; set; }
        public string Studentnum { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
    }
}