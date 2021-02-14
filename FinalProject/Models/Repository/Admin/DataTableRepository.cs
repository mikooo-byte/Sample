using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Entities;
using FinalProject.Models.DTO;

namespace FinalProject.Models.Repository
{
    public class DataTableRepository
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<RecordDTO> records(string category, string keyword)
        {

            List<RecordDTO> records = new List<RecordDTO>();
            List<Member> members = new List<Member>();


            if (!string.IsNullOrEmpty(category))
            {
                if (category == "First Name")
                {
                    members = db.Members.Where(a => a.Firstname.Contains(keyword)).ToList();
                }
                else if (category == "Last Name")
                {
                    members = db.Members.Where(a => a.Lastname.Contains(keyword)).ToList();
                }
                else if (category == "Email")
                {
                    members = db.Members.Where(a => a.Email.Contains(keyword)).ToList();
                }

            }
            else
            {
                members = db.Members.ToList();
            }


            //looping of details
            foreach (Member mem in members)
            {
                RecordDTO r = new RecordDTO();

                r.StudentId = mem.StudentId;
                r.Firstname = mem.Firstname;
                r.Lastname = mem.Lastname;
                r.Middlename = mem.Middlename;
                r.Sex = mem.Sex;
                r.Age = mem.Age.ToString();
                r.DOB = (DateTime)mem.DOB;
                r.Email = mem.Email;
                r.Contact_number = mem.Contact_number;
                r.Address = mem.Address;



                records.Add(r);
            }


            return records;
        }



        public bool updateRecord(RecordDTO record)
        {

            var checkIfExisting = db.Members.Where(r => r.StudentId == record.StudentId).FirstOrDefault();
            if (checkIfExisting != null)
            {
                checkIfExisting.Firstname = record.Firstname;
                checkIfExisting.Middlename = record.Middlename;
                checkIfExisting.Lastname = record.Lastname;
                checkIfExisting.Email = record.Email;
                checkIfExisting.Address = record.Address;
                checkIfExisting.Contact_number = record.Contact_number;
                checkIfExisting.DOB = record.DOB;

                db.SaveChanges();


                return true;
            }
            else
            {
                return false;
            }

        }
    }
}