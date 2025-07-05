using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentsEnrollmentSystem.ViewModels;
public class AccountController : Controller
{
   public IActionResult login()
    {
        return View();
    }


    public IActionResult Signin()
    {
        return View();
    }

    public IActionResult ForgotPass()
    {
        return View();
    }


}
