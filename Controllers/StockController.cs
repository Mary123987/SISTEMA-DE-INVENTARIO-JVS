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

        [HttpGet]
        public IActionResult Editar(long id)
        {
            var producto = _context.DataProducto.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var productoExistente = _context.DataProducto.FirstOrDefault(p => p.Id == producto.Id);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = producto.Nombre;
                    productoExistente.Codigo = producto.Codigo;
                    productoExistente.Categoría = producto.Categoría;
                    productoExistente.Stock = producto.Stock;
                    productoExistente.UbiAlmacen = producto.UbiAlmacen;
                    productoExistente.Proveedor = producto.Proveedor;
                    productoExistente.Precio = producto.Precio;
                    productoExistente.FechaI = producto.FechaI;

                    _context.Update(productoExistente);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        [HttpDelete]
        public IActionResult Eliminar(long id)
        {
            var producto = _context.DataProducto.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _context.DataProducto.Remove(producto);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
