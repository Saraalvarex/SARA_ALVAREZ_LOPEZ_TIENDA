using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARA_ALVAREZ_LOPEZ_TIENDA.Models
{
    [Table("VISTAPEDIDOS")]
    public class VistaPedidos
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("TITULO")]
        public int Titulo { get; set; }
        [Column("PRECIO")]
        public int Precio { get; set; }
        [Column("PORTADA")]
        public string Portada { get; set; }

    }
}
