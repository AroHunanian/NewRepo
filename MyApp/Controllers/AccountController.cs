using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models.Account;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

namespace MyApp.Controllers;

public class AccountController : Controller
{
    ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
  

    public AccountController(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }


    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpUserModel user)
    {
        //_context.UserSignUp.Add(user);
        //_context.SaveChanges();
        if (ModelState.IsValid)
        {
            var _user = new ApplicationUser { UserName = user.UserName, PasswordHash = user.Password };
            var result = await  _userManager.CreateAsync(_user, user.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(_user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach(var error in result.Errors) 
            {
                ModelState.AddModelError(" ", error.Description);
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
   public async Task<IActionResult> SignIn(SignInUserModel user)
   {
        return View();
        
    }

    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}