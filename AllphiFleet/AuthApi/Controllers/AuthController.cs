using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Auth.ViewModels;
using ReadServices.Interfaces;

namespace AuthApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IDriverService _driverService;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IDriverService driverService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _driverService = driverService;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            long driverId = _driverService.GetDriverIdByEmail(viewModel.Email);
            if(driverId == 0)
            {
                ViewBag.ErrorMessage = "Email could not be found. Please enter an existing driver email.";
                //email does not exist, give error
                return View(viewModel);
            }
            var user = new IdentityUser
            {
                UserName = viewModel.Username,
                Email = viewModel.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                return Redirect(viewModel.ReturnUrl);
            }
            else
            {
                ViewBag.Errors = result.Errors;
                return View();
            }

        }
    }
}
