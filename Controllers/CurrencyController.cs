using Interview_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_task.Controllers
{
    public class CurrencyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CurrencyViewModel());
        }
    }
}