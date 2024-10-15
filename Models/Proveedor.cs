using System.ComponentModel.DataAnnotations.Schema;

namespace SISTEMA_DE_INVENTARIO_JVS.Models
{
    [Table("t_proveedor")]
    public class Proveedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long Id { get; set;} 
       public string? Nombre { get; set;} 
       public string? RUC { get; set;} 
       public string? Email { get; set;} 
       public string? Telefono { get; set;} 
       public string? NombreC { get; set;} 
       public string? FechaI { get; set;} 
        
    }
}