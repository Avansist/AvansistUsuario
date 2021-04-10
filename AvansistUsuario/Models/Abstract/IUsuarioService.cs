using AvansistUsuario.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Abstract
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerListaUsuarios();
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task GuardarUsuario(Usuario usuario);
        Task EditarUsuario(Usuario usuario);
        Task EliminarUsuario(Usuario usuario);
        Task<IEnumerable<Rol>> ObtenerListaRoles();
        Task<IEnumerable<Estado>> ObtenerListaEstados();
        Task<Usuario> ObtenerUsuarioPorCorreo(string correo);
    }
}
