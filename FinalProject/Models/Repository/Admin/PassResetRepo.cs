using FinalProject.Models.DTO;
using FinalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.Repository.Admin
{
    public class PassResetRepo
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<PassResetDTO> RequestRecords()
        {

            List<PassResetDTO> records = new List<PassResetDTO>();
            List<Pass_Reset> request = new List<Pass_Reset>();

            request = db.Pass_Reset.ToList();
            //looping of details
            foreach (Pass_Reset req in request)
            {
                PassResetDTO r = new PassResetDTO();

                r.PR_id = req.PR_id;
                r.Username = req.Username;
                r.Email = req.Email;
                r.Code = req.Code;
                r.Status = "Closed";
                records.Add(r);
            }


            return records;
        }
    }
}