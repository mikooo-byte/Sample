using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.DTO;
using FinalProject.Models.Entities;

namespace FinalProject.Models.Repository.Student
{
    public class ScheduleRepo
    {
        RegistrationEntities db = new RegistrationEntities();

        public List<ScheduleDTO> RequestSchedule()
        {

            List<ScheduleDTO> records = new List<ScheduleDTO>();
            List<Schedule> request = new List<Schedule>();

            request = db.Schedules.ToList();
            //looping of details
            foreach (Schedule req in request)
            {
                ScheduleDTO r = new ScheduleDTO();

                r.S_id = req.S_id;
                r.Code = req.Code;
                r.Subject = req.Subject;
                r.Unit = req.Unit;
                r.Room = req.Room;
                r.Day = req.Day;
                r.Time = req.Time;
                r.Professor = req.Professor;
                records.Add(r);
            }


            return records;
        }
    }
}