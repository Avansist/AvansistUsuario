using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Entities
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        [Column("Nombre Estado", TypeName = "varchar(20)")]
        public string Nombre { get; set; }
    }
}
