using Microsoft.AspNetCore.Mvc;

namespace StudentsEnrollmentSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
