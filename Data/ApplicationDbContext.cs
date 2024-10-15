using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SISTEMA_DE_INVENTARIO_JVS.Models;

namespace SISTEMA_DE_INVENTARIO_JVS.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<SISTEMA_DE_INVENTARIO_JVS.Models.Producto> DataProducto { get; set; }
    public DbSet<SISTEMA_DE_INVENTARIO_JVS.Models.Proveedor> DataProveedor { get; set; }
    public DbSet<Usuario> DataUsuario { get; set; }
}
