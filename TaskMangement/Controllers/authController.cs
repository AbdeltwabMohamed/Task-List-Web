using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMangement.ViewModels;

namespace TaskMangement.Controllers
{
    public class authController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signIn;
        public authController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
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
        
    }
}
