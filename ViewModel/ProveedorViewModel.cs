using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_INVENTARIO_JVS.Models;

namespace SISTEMA_DE_INVENTARIO_JVS.ViewModel
{
       public class ProveedorViewModel
    {
        public Proveedor? FormProveedor  {get; set;}
        public IEnumerable<Proveedor>? ListProveedor  {get; set;}
    }
}