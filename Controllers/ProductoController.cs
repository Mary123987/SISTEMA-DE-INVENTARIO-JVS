using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_INVENTARIO_JVS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISTEMA_DE_INVENTARIO_JVS.Models;
using SISTEMA_DE_INVENTARIO_JVS.ViewModel;

namespace SISTEMA_DE_INVENTARIO_JVS.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;

        private readonly ApplicationDbContext _context;

        public ProductoController(ILogger<ProductoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var misproductos = from o in _context.DataProducto select o;
            _logger.LogDebug("producto {misproductos}", misproductos);
            var viewModel = new ProductoViewModel
            {
                FormProducto = new Producto(),
                ListProducto = misproductos
            };
            _logger.LogDebug("viewModel {viewModel}", viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Crear(ProductoViewModel viewModel)
        {
            _logger.LogDebug("Ingreso a Crear Producto");

            var producto = new Producto
            {
                Nombre = viewModel.FormProducto.Nombre,
                Codigo = viewModel.FormProducto.Codigo,
                Categoría = viewModel.FormProducto.Categoría,
                Stock = viewModel.FormProducto.Stock,
                UbiAlmacen = viewModel.FormProducto.UbiAlmacen,
                Proveedor = viewModel.FormProducto.Proveedor,
                Precio = viewModel.FormProducto.Precio,
                FechaI = viewModel.FormProducto.FechaI,
            };

            _context.Add(producto);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}