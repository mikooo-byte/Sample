using FinalProject.Domain;
using System.Linq;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            var data = new Data();
            return PartialView("_Navbar", data.NavbarItems().ToList());
        }
    }
}