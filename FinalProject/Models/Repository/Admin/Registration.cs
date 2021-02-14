using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using FinalProject.Models.DTO;
using FinalProject.Models.Entities;

namespace FinalProject.Models.Repository.Admin
{
    public class Registration
    {
        RegistrationEntities db = new RegistrationEntities();
        EncryptDecryptRepository EDrep = new EncryptDecryptRepository();

        public bool insertTodatabase(RegistrationFormDTO registrationFormDTO)
        {

             StudentInfo reg = new StudentInfo
             {
                IdStudent = registrationFormDTO.StudentId,
                Firstname = registrationFormDTO.Firstname,
                Middlename = registrationFormDTO.Middlename,
                Lastname = registrationFormDTO.Lastname,
                Email = registrationFormDTO.Email,
                Address = registrationFormDTO.Address,
                Sex = registrationFormDTO.Sex,
                Studentnum = registrationFormDTO.Studentnum,
                Password = EDrep.Encrypt(registrationFormDTO.Studentnum, registrationFormDTO.Password),
                Contact_number = registrationFormDTO.Contact_number,
                DOB = registrationFormDTO.DOB
            };


            db.StudentInfoes.Add(reg);
            try
            {
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return true;
        }
    }
}