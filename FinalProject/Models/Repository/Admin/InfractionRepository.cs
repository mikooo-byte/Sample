using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Entities;
using FinalProject.Models.DTO;

namespace FinalProject.Models.Repository.Admin
{
    public class InfractionRepository
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<InfractionDTO> InfractionRecords()
        {

            List<InfractionDTO> records = new List<InfractionDTO>();
            List<Infraction> infraction = new List<Infraction>();

            infraction = db.Infractions.ToList();
            //looping of details
            foreach (Infraction mem in infraction)
            {
                InfractionDTO r = new InfractionDTO();

                r.Infr_Id = mem.Infr_Id;
                r.Studentnum = mem.Studentnum;
                r.Library = mem.Library;
                r.L_inf = mem.L_inf;
                r.Health = mem.Health;
                r.H_inf = mem.H_inf;
                r.Osas = mem.Osas;
                r.O_inf = mem.O_inf;
                r.Registrar = mem.Registrar;
                r.R_inf = mem.R_inf;



                records.Add(r);
            }


            return records;
        }
    }
}