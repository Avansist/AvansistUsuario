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
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextAvansist _context;

        public UsuarioService(DbContextAvansist context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerListaUsuarios()
        {
            return await _context.Usuarios.Include(rol=>rol.Rol).Include(estatus=>estatus.Estado).ToListAsync();
        }

        public async Task<IEnumerable<Estado>> ObtenerListaEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task<IEnumerable<Rol>> ObtenerListaRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id);
            return usuario;
        }

        public async Task<Usuario> ObtenerUsuarioPorCorreo(string correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(co => co.Correo == correo);
            
        }

        public async Task GuardarUsuario(Usuario usuario)
        {
            try
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditarUsuario(Usuario usuario)
        {
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task EliminarUsuario(Usuario usuario)
        {
            try
            {
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
