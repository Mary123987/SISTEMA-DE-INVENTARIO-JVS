using Microsoft.AspNetCore.Mvc;
using SISTEMA_DE_INVENTARIO_JVS.Models;
using SISTEMA_DE_INVENTARIO_JVS.Data;

namespace SISTEMA_DE_INVENTARIO_JVS.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ILogger<AccesoController> _logger;
        private readonly ApplicationDbContext _context;


        public AccesoController(ILogger<AccesoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;  
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario model)
        {

            _logger.LogInformation($"Username: {model.UsuarioAdmin}");
            _logger.LogInformation($"Phone: {model.Contraseña}");

            var user = _context.DataUsuario.FirstOrDefault(x => x.UsuarioAdmin == model.UsuarioAdmin && x.Contraseña == model.Contraseña);
            if (user != null)
            {
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
            }
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}