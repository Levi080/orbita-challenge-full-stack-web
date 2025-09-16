using Microsoft.AspNetCore.Mvc;

namespace AmaisEducacao.API.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
