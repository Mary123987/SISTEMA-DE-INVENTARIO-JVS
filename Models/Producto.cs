using System.ComponentModel.DataAnnotations.Schema;

namespace SISTEMA_DE_INVENTARIO_JVS.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long Id { get; set;} 
       public string? Nombre { get; set;} 
       public string? Codigo { get; set;} 
       public string? Categoría { get; set;} 
       public string? Stock { get; set;} 
       public string? UbiAlmacen { get; set;} 
       public string? Proveedor { get; set;} 
       public string? Precio { get; set;} 
       public string? FechaI { get; set;} 
    }
}