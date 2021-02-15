using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Entities;
using FinalProject.Models.DTO;

namespace FinalProject.Models.Repository.Admin
{
    public class InquiryRepository
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<ConcernDTO> ConcernRecords()
        {

            List<ConcernDTO> records = new List<ConcernDTO>();
            List<Concern> concern = new List<Concern>();

            concern = db.Concerns.ToList();
            //looping of details
            foreach (Concern mem in concern)
            {
                ConcernDTO r = new ConcernDTO();

                r.C_id = mem.C_id;
                r.Content = mem.Content;
                r.Email = mem.Email;
                r.Status = mem.Status;
                r.Studentnum = mem.Studentnum;
                r.Subject = mem.Subject;



                records.Add(r);
            }


            return records;
        }
    }
}