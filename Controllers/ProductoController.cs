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

        public IActionResult Index(string? searchTerm = null)
        {
            var misproductos = from o in _context.DataProducto select o;
            // Buscar
            if (!string.IsNullOrEmpty(searchTerm))
            {
                misproductos = misproductos.Where(p => p.Nombre.Contains(searchTerm) ||
                                                    p.Codigo.Contains(searchTerm) ||
                                                    p.Categoría.Contains(searchTerm) ||
                                                    p.Proveedor.Contains(searchTerm));
            }

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

        [HttpGet]
        public IActionResult ObtenerProducto(long id)
        {
            var producto = _context.DataProducto.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Json(producto);
        }

        [HttpPost]
        public IActionResult Editar(ProductoViewModel viewModel)
        {
            var productoExistente = _context.DataProducto.FirstOrDefault(p => p.Id == viewModel.FormProducto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = viewModel.FormProducto.Nombre;
                productoExistente.Codigo = viewModel.FormProducto.Codigo;
                productoExistente.Categoría = viewModel.FormProducto.Categoría;
                productoExistente.Stock = viewModel.FormProducto.Stock;
                productoExistente.UbiAlmacen = viewModel.FormProducto.UbiAlmacen;
                productoExistente.Proveedor = viewModel.FormProducto.Proveedor;
                productoExistente.Precio = viewModel.FormProducto.Precio;
                productoExistente.FechaI = viewModel.FormProducto.FechaI;

                _context.Update(productoExistente);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(long id)
        {
            var producto = _context.DataProducto.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _context.DataProducto.Remove(producto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}