using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMangement.Models;
using TaskMangement.ViewModels;

namespace TaskMangement.Controllers
{
    public class authController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<SystemUser> _signIn;
        public authController(RoleManager<IdentityRole> roleManager, UserManager<SystemUser> userManager, SignInManager<SystemUser> signIn)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            _signIn = signIn;

        }
        public IActionResult Index()
        {
            return View();
        }

       public async Task<IActionResult> login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(loginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(model.Email
                    , model.password, isPersistent: false
                    , lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Cradintails");
            }
                return View(model);
            
        }

        public IActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> signUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
              var result= await _userManager.CreateAsync(user,model.Password);
                
                if (!result.Succeeded)
                    
                {
                    foreach(var error in result.Errors)
                    {


                    ModelState.AddModelError("", error.Description);
                        
                    }
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
