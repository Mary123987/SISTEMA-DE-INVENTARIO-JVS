using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SISTEMA_DE_INVENTARIO_JVS.Models;

namespace SISTEMA_DE_INVENTARIO_JVS.Controllers;

public class NotificacionesController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public  NotificacionesController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
