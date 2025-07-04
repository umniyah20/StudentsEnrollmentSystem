using Microsoft.AspNetCore.Mvc;

namespace StudentsEnrollmentSystem.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
