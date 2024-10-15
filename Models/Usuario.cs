using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SISTEMA_DE_INVENTARIO_JVS
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("contraseña")]
        public required string Contraseña { get; set; }

        [Column("usuario")]
        public required string UsuarioAdmin { get; set; }

        [Column("created_at")]
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}