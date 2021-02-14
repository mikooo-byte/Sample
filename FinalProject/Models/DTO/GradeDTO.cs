using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class GradeDTO
    {
        public int id { get; set; }
        public string Studentnum { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public int Unit { get; set; }
        public double Grade { get; set; }
    }
}