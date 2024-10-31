using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISTEMA_DE_INVENTARIO_JVS.Models;
using SISTEMA_DE_INVENTARIO_JVS.Data;


namespace SISTEMA_DE_INVENTARIO_JVS.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly ApplicationDbContext _context;

        public StockController(ILogger<StockController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

       public async Task<IActionResult> Index()
            {
                var productos = await _context.DataProducto
                                            .OrderBy(p => p.Categoría)
                                            .ToListAsync();

                var groupedProducts = productos.GroupBy(p => p.Categoría);
                return View(groupedProducts);
            }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
