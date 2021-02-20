using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DTO
{
    public class SendMailDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Receiver { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}