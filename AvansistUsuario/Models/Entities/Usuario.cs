using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayName("Contaseña")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string ConfContrasena { get; set; }
        
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
