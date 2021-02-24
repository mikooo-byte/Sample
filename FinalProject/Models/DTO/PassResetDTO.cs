using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class PassResetDTO
    {
        public Int32 PR_id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
    }
}