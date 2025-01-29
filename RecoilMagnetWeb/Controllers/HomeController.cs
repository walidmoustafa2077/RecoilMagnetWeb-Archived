using Microsoft.AspNetCore.Mvc;

namespace RecoilMagnetWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  // This will render the 'Index.cshtml' view
        }

        public IActionResult Features()
        {
            return View();  // This will render the 'Features.cshtml' view
        }
    }
}
