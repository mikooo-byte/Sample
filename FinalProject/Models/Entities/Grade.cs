//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade
    {
        public int id { get; set; }
        public string Studentnum { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Year { get; set; }
        public string Section { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<double> GradeValue { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> IdProf { get; set; }
        public string ProfName { get; set; }
    
        public virtual Professor Professor { get; set; }
        public virtual Subject Subject1 { get; set; }
    }
}
