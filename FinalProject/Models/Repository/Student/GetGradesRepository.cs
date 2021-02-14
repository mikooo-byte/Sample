using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Entities;
using FinalProject.Models.DTO;

namespace FinalProject.Models.Repository.Student
{
    public class GetGradesRepository
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<GradeDTO> Graderecords(string IdCode)
        {

            List<GradeDTO> records = new List<GradeDTO>();
            List<Grade> grades = new List<Grade>();


            if (!string.IsNullOrEmpty(IdCode))
            {
                grades = db.Grades.Where(a => a.Studentnum.Contains(IdCode)).ToList();

            }

            foreach(Grade mem in grades)
            {
                GradeDTO r = new GradeDTO();

                r.id = mem.id;
                r.Studentnum = mem.Studentnum;
                r.LastName = mem.LastName;
                r.FirstName = mem.FirstName;
                r.Year = mem.Year;
                r.Section = mem.Section;
                r.Code = mem.Code;
                r.Subject = mem.Subject;
                r.Unit = (int)mem.Unit;
                r.Grade = (double)mem.GradeValue;



                records.Add(r);
            }

            return records;
        }
    }
}