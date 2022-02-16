using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refugiados1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;



namespace Refugiados1.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Ajudadores()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Ongs()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        

        public IActionResult LoginAnjo()
        {
            
            return View();
            
        }
        public IActionResult LoginOng()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}