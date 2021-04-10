using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        [Column("Nombre Rol", TypeName ="varchar(20)")]
        public string Nombre { get; set; }
    }
}
