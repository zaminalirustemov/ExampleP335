using Example.DAL;
using Example.Models;
using Example.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            AppUser appUser = null;

            appUser = await _userManager.FindByNameAsync(registerViewModel.Username);
            if (appUser is not null)
            {
                ModelState.AddModelError("Username", "Already exist");
                return View(registerViewModel);
            }
           

            appUser = new AppUser
            {
                UserName = registerViewModel.Username,
                PhoneNumber = registerViewModel.Phone
            };

            var result = await _userManager.CreateAsync(appUser,registerViewModel.Pass);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return RedirectToAction("index","home");
        }
    }
}
