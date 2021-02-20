using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Reports;
using FinalProject.Models.Repository;
using FinalProject.Models.DTO;
using FinalProject.Models.Entities;
using FinalProject.Models.Repository.Student;
using FinalProject.Reports.StudentLists;
using System.Web.Security;
using System.Net;
using System.Net.Mail;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        readonly RegistrationEntities db = new RegistrationEntities();
        // GET: Student
        public ActionResult Index()
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

        public ActionResult TeachersEvaluation()
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
        public ActionResult Test()
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
        public ActionResult TeachersEvalSuccess()
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
        public ActionResult Grade()
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
        [HttpPost]
        public ActionResult GetGrades(string IdCode)
        {
            GetGradesRepository gradeTable = new GetGradesRepository();
            List<GradeDTO> records = gradeTable.Graderecords(IdCode);
            return Json(new { data = records });
        }
        public ActionResult Schedules()
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
        public ActionResult ThingsToComply()
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
        public ActionResult UpdateInfo()
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
        public ActionResult FAQ()
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn", "Home");

        }

        public ActionResult GetStudentPersonalGrade()
        {

            StudentPersonalGrade rpt = new StudentPersonalGrade();
            Report rptMngmt = new Report(rpt);
            rpt.SetParameterValue("@StudentnumId", Session["Username"]); 

            rpt = (StudentPersonalGrade)rptMngmt.CrystalReportConnection();
            var result = rptMngmt.ConvertCrystalToFormat("PDF");

            return new FileContentResult(result.array, result.contenttype);

        }

        public ActionResult getConcern(ConcernDTO data)
        {

            Concern con = new Concern();

            con.Studentnum = data.Studentnum;
            con.Email = data.Email;
            con.Subject = data.Subject;
            con.Content = data.Content;
            con.Status = data.Status;


            db.Concerns.Add(con);
            db.SaveChanges();
            return View("FAQ");
                
        }

    }
}