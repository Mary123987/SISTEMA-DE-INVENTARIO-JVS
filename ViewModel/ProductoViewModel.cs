using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_INVENTARIO_JVS.Models;

namespace SISTEMA_DE_INVENTARIO_JVS.ViewModel
{
       public class ProductoViewModel
    {
        public Producto? FormProducto  {get; set;}
        public IEnumerable<Producto>? ListProducto  {get; set;}
    }
}