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
    public class ProveedorController : Controller
    {
        private readonly ILogger<ProveedorController> _logger;

        private readonly ApplicationDbContext _context;

        public ProveedorController(ILogger<ProveedorController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var misproveedor = from o in _context.DataProveedor select o;
            _logger.LogDebug("proveedor {misproveedor}", misproveedor);
            var viewModel = new ProveedorViewModel
            {
                FormProveedor = new Proveedor(),
                ListProveedor = misproveedor
            };
            _logger.LogDebug("viewModel {viewModel}", viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Crear(ProveedorViewModel viewModel)
        {
            _logger.LogDebug("Ingreso a Crear Proveedor");

            var proveedor = new Proveedor
            {
                Nombre = viewModel.FormProveedor.Nombre,
                RUC = viewModel.FormProveedor.RUC,
                Email = viewModel.FormProveedor.Email,
                Telefono = viewModel.FormProveedor.Telefono,
                NombreC = viewModel.FormProveedor.NombreC,
                FechaI = viewModel.FormProveedor.FechaI,
                
            };

            _context.Add(proveedor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ObtenerProveedor(long id)
        {
            var proveedor = _context.DataProveedor.FirstOrDefault(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Json(proveedor);
        }

        [HttpPost]
        public IActionResult Editar(ProveedorViewModel viewModel)
        {
            var proveedorExistente = _context.DataProveedor.FirstOrDefault(p => p.Id == viewModel.FormProveedor.Id);
            if (proveedorExistente != null)
            {
                proveedorExistente.Nombre = viewModel.FormProveedor.Nombre;
                proveedorExistente.RUC = viewModel.FormProveedor.RUC;
                proveedorExistente.Email = viewModel.FormProveedor.Email;
                proveedorExistente.Telefono = viewModel.FormProveedor.Telefono;
                proveedorExistente.NombreC = viewModel.FormProveedor.NombreC;
                proveedorExistente.FechaI = viewModel.FormProveedor.FechaI;

                _context.Update(proveedorExistente);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(long id)
        {
            var proveedor = _context.DataProveedor.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
            {
                _context.DataProveedor.Remove(proveedor);
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