using DtoModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.MVC.Models;
using Web.MVC.Services;

namespace Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EquityApiService _apiService;

        public HomeController(ILogger<HomeController> logger, EquityApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            PageModel model = new();
            model.Equities = await _apiService.GetEquities();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EquityInputDto input)
        {
            PageModel model = new();
            var result = await _apiService.CreateEquity(input);
            var equities = await _apiService.GetEquities();
            model.Results = result;
            model.Equities = equities;
            return View(model);
        }

        public async Task<IActionResult> DeleteEquity(int id)
        {
            PageModel model = new();
            _ = await _apiService.DeleteEquity(id);
            model.Equities = await _apiService.GetEquities();
            return View("Index", model);
        }

        public IActionResult Privacy()
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
