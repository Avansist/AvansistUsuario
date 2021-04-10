using AvansistUsuario.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Abstract
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> ObtenerListaRoles();
    }
}
