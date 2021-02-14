using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.DTO
{
    public class Navbar
    {
        public int Id { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string nameOption { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string controller { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string action { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string area { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string imageClass { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public string activeli { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public bool status { get; set; }
        public int parentId { get; set; }
        public bool isParent { get; set; }
    }
}