using AvansistUsuario.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }       
        public string Apellido { get; set; }       
        public string Correo { get; set; }
        public  string Estado { get; set; }        
        public string Rol { get; set; }
    }
}
