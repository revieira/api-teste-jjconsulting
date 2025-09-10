using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesteJJConsulting_API.Models;

namespace TesteJJConsulting_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listUsers = new VisualizarUsuarios();
            var usuarios = await listUsers.ListAllUsers();
            return View(usuarios);
        }

        // Caso id não seja passado, inicializa no valor 1
        [HttpGet("details/{id=1}")]
        public async Task<IActionResult> Details(int id)
        {
            var listUser = new ExibirDetalheUsuario();
            var usuario = await listUser.GetUserById(id);
            // Se não encontrar o usuário, retorna o usuário com id=1
            if (usuario == null) usuario = await listUser.GetUserById(1);
            return View(usuario);
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
