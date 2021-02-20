using FinalProject.Models.DTO;
using FinalProject.Models.Entities;
using FinalProject.Models.Repository;
using FinalProject.Models.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        readonly RegistrationEntities db = new RegistrationEntities();
        EncryptDecryptRepository EDrep = new EncryptDecryptRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("LogIn");
        }
        public ActionResult LogIn()
        {
           return View();
        }
        public ActionResult LogInStudent()
        {
            if (ModelState.IsValid)
            {
                if (Session["Username"] != null)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
             return View();
        }
        public ActionResult LoginAdmin()
        {
            if (ModelState.IsValid) 
            {
                if (Session["Username"] != null)
                {
                    return RedirectToAction("Index", "Admin");
                }                
            }
            return View();
            
        }

        public bool loginChecker(LoginFormDTO dto)
        {

            var success = false;
            var account = db.Admin_Acc.Where(ad => ad.Username == dto.Studentnum).FirstOrDefault();

            if (account != null)
            {
                var decryptedPass = EDrep.Decrypt(dto.Studentnum, account.Password);
                if (decryptedPass == dto.Password)
                {
                    Session["UserName"] = dto.Studentnum.ToString();
                    return true;
                }
            }
            return success;
        }

        public bool loginCheckerStudent(LoginFormDTO dto)
        {

            var success = false;
            var account = db.StudentInfoes.Where(ad => ad.Studentnum == dto.Studentnum).FirstOrDefault();

            if (account != null)
            {
                var decryptedPass = EDrep.Encrypt(dto.Studentnum, dto.Password);
                if (decryptedPass == account.Password)
                {
                    Session["UserName"] = dto.Studentnum.ToString();
                    Session["Email"] = account.Email.ToString();
                    return true;
                }
            }
            return success;
        }

    }
}