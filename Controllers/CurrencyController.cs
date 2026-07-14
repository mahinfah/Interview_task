using Interview_task.Models;
using Interview_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview_task.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CurrencyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(CurrencyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _currencyService.ConvertCurrency(
                model.Amount,
                model.FromCurrency.ToUpper(),
                model.ToCurrency.ToUpper());

            if (result != null)
            {
                model.ConvertedAmount = result.Value;
            }
            else
            {
                ViewBag.Error = "Currency conversion failed.";
            }

            return View(model);
        }
    }
}