﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentsEnrollmentSystem.ViewModels;
public class AccountController : Controller
{
   //public IActionResult login()
   // {
   //     return View();
   // }


    //public IActionResult Signin()
    //{
    //    return View();
    //}

    public IActionResult ForgotPass()
    {
        return View();
    }


    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: /Account/Register
    [HttpGet]
    public IActionResult Signin()
    {
        return View();
    }

    // POST: /Account/Register
    //[HttpPost]
    //public async Task<IActionResult> Signin(RegisterViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //        return View(model);

    //    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
    //    var result = await _userManager.CreateAsync(user, model.Password);

    //    if (result.Succeeded)
    //    {
    //        await _signInManager.SignInAsync(user, isPersistent: false);
    //        return RedirectToAction("Index", "Home");
    //    }

    //    foreach (var error in result.Errors)
    //        ModelState.AddModelError("", error.Description);

    //    return View(model);
    //}

    //// GET: /Account/Login
    //[HttpGet]
    //public IActionResult login()
    //{
    //    return View();
    //}

    //// POST: /Account/Login
    //[HttpPost]
    //public async Task<IActionResult> Login(LoginViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //        return View(model);

    //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

    //    if (result.Succeeded)
    //        return RedirectToAction("Index", "Home");

    //    ModelState.AddModelError("", "Invalid login attempt.");
    //    return View(model);
    //}

    //// POST: /Account/Logout
    //[HttpPost]
    //public async Task<IActionResult> Logout()
    //{
    //    await _signInManager.SignOutAsync();
    //    return RedirectToAction("Index", "Home");
    //}


}
