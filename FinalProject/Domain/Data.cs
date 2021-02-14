using System;
using System.Collections.Generic;
using FinalProject.Models.DTO;
using System.Linq;
using System.Web;

namespace FinalProject.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> NavbarItems()
        {
            List<Navbar> menu = new List<Navbar>
            {
                new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 },

                new Navbar { Id = 2, nameOption = "General Information", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 },
                new Navbar { Id = 3, nameOption = "Mission & Vission", controller = "Home", action = "Index", status = true, isParent = false, parentId = 2 },
                new Navbar { Id = 4, nameOption = "Core Values", controller = "Home", action = "Index", status = true, isParent = false, parentId = 2 },
                new Navbar { Id = 5, nameOption = "University Calendar ", controller = "Home", action = "Index", status = true, isParent = false, parentId = 2 },
                new Navbar { Id = 6, nameOption = "University Hymn ", controller = "Home", action = "Index", status = true, isParent = false, parentId = 2 },

                new Navbar { Id = 7, nameOption = "Campuses", controller = "Home", action = "Index", imageClass = "fa fa-table fa-fw", status = true, isParent = true, parentId = 0 },
                new Navbar { Id = 8, nameOption = "San Bartolome ", controller = "Home", action = "Index", status = true, isParent = false, parentId = 7 },
                new Navbar { Id = 9, nameOption = "Batasan ", controller = "Home", action = "Index", status = true, isParent = false, parentId = 7 },
                new Navbar { Id = 10, nameOption = "San Francisco ", controller = "Home", action = "Index", status = false, isParent = false, parentId = 7 },

                new Navbar { Id = 11, nameOption = "Services", controller = "Home", action = "Index", imageClass = "fa fa-edit fa-fw", status = true, isParent = true, parentId = 0 },
                new Navbar { Id = 12, nameOption = "Transcript of Record", controller = "Index", action = "TranscriptOfRecord", status = false, isParent = false, parentId = 11 },
                new Navbar { Id = 13, nameOption = "Downloadable forms ", controller = "Index", action = "DownloadableForms", status = false, isParent = false, parentId = 11 },

                new Navbar { Id = 14, nameOption = "Pages", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 },
                new Navbar { Id = 15, nameOption = "Login", controller = "Home", action = "Index", status = true, isParent = false, parentId = 14 },
                new Navbar { Id = 16, nameOption = "Register", controller = "Home", action = "Index", status = true, isParent = false, parentId = 14 },
                new Navbar { Id = 17, nameOption = "Forgot Password", controller = "Home", action = "Index", status = true, isParent = false, parentId = 14 },

                new Navbar { Id = 18, nameOption = "Grades", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 }
            };



            return menu.ToList();
        }
    }
}