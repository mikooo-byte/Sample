using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Reports.StudentLists;
using FinalProject.Reports;
using FinalProject.Models.Repository;
using FinalProject.Models.DTO;
using FinalProject.Models.Entities;
using FinalProject.Models.Repository.Admin;
using System.Web.Security;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        // Retrieving data from database using repository
       readonly DataTableRepository dataTBrepository = new DataTableRepository();
        readonly RegistrationEntities db = new RegistrationEntities();
        readonly RegistrationEntities entities = new RegistrationEntities();
        GradeTable gradeTable = new GradeTable();
        

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Username"] !=null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult NewsUpdate()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Announcements()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult UniversityCalendar()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult StudentsInfo()
        {
            //if (Session["Username"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        public ActionResult Grades()
        {
            //if (Session["Username"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        public ActionResult Infractions()
        {
            //if (Session["Username"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        public JsonResult StudentInfraction()
        {
            InfractionRepository infractionRepo = new InfractionRepository();
            List<InfractionDTO> records = infractionRepo.InfractionRecords();
            return Json(new { data = records });
        }
        public JsonResult StudentGrades()
        {
            List<GradeDTO> records = gradeTable.Graderecords();
            return Json(new { data = records });
        }

        public ActionResult LibraryInfo()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult StudentsInquiry()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        public ActionResult GetStudentList()
        {

            Students rpt = new Students();
            Report rptMngmt = new Report(rpt);
            rpt = (Students)rptMngmt.CrystalReportConnection();
            var result = rptMngmt.ConvertCrystalToFormat("PDF");

            return new FileContentResult(result.array, result.contenttype);

        }



        [HttpPost]
        public ActionResult GetRecords(string category, string keyword)
        {
            List<RecordDTO> records = dataTBrepository.records(category, keyword);
            return Json(new { data = records });
        }

        [HttpPost]
        public ActionResult DeleteRow(int? id)
        {

            if (id == null)
            {
                return Json(new { success = false });
            }
            else
            {
                Member data2 = db.Members.Find(id);
                db.Members.Remove(data2);
                db.SaveChanges();
                return Json(new { success = true });
            }
        }

        public JsonResult GetEvents()
        {
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                var events = dc.Calendars.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Calendar e)
        {
            var status = false;
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Calendars.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Calendars.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                var v = dc.Calendars.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Calendars.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status } };
        }

        [HttpPost] // This is for Registration
        public ActionResult DataTransfer(RegistrationFormDTO data)
        {
            Registration reg = new Registration();
            bool inserted = reg.insertTodatabase(data);
            return Json(new { success = inserted });
        }
        public string checkUserName(string Studentnum)
        {

            var checkUserName = db.StudentInfoes.Where(rt => rt.Studentnum == Studentnum).FirstOrDefault();
            if (checkUserName != null)
            {
                return "false";
            }
            return "true";

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn", "Home");

        }
        public JsonResult getInquiry()
        {
            RegistrationEntities entities = new RegistrationEntities();
            List<Concern> concern = (from account in entities.Concerns
                                     select account).ToList();
            return Json(concern);
        }


    }
}