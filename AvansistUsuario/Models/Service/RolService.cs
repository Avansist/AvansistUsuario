using AvansistUsuario.Models.Abstract;
using AvansistUsuario.Models.DAL;
using AvansistUsuario.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.Service
{
    public class RolService : IRolService
    {
        private readonly DbContextAvansist _context;
        public RolService(DbContextAvansist context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> ObtenerListaRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
