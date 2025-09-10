using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesteJJConsulting_API.Models;

namespace TesteJJConsulting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var listUsers = new VisualizarUsuarios();
            //var usuarios = await listUsers.ListAllUsers();
            //return View(usuarios);
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
