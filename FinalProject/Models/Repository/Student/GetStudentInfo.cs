using FinalProject.Models.DTO;
using FinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.Repository.Student
{
    public class GetStudentInfo
    {
        RegistrationEntities db = new RegistrationEntities();

        //public RecordDTO records(string Studentnum2)
        //{

        //    RecordDTO records = new RecordDTO();
        //    Member members = new Member();


        //    members = (Member)db.Members.Where(a => a.Studentnum.Equals(Studentnum2));

        //    //looping of details
        //    foreach (Member mem in members)
        //    {
        //        RecordDTO r = new RecordDTO();

        //        r.StudentId = members.StudentId;
        //        r.Firstname = members.Firstname;
        //        r.Lastname = members.Lastname;
        //        r.Middlename = members.Middlename;
        //        r.Sex = members.Sex;
        //        r.Age = members.Age.ToString();
        //        r.DOB = (DateTime)members.DOB;
        //        r.Email = members.Email;
        //        r.Contact_number = members.Contact_number;
        //        r.Address = members.Address;



        //        records.Add(r);
        //    }


        //    return records;
        //}

    }
}