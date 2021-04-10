using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvansistUsuario.Models.DAL;
using AvansistUsuario.Models.Entities;
using AvansistUsuario.Models.Abstract;

namespace AvansistUsuario.Controllers
{
    public class UsuariosController : Controller
    {        
        private readonly IUsuarioService _usuarioService;
        

        public UsuariosController(IUsuarioService usuarioService)
        {           
            _usuarioService = usuarioService;
            
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var listaEmpleados = await _usuarioService.ObtenerListaUsuarios();
            return View(listaEmpleados);
        }
        
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioService.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["listaEstados"] = new SelectList(await _usuarioService.ObtenerListaEstados(), "EstadoId", "Nombre");
            ViewData["listaRoles"] = new SelectList(await _usuarioService.ObtenerListaRoles(), "RolId", "Nombre");
            return View(usuario);
        }

        // GET: Usuarios/Create
        public async Task<IActionResult> Create()
        {            
            ViewData["listaRoles"] = new SelectList(await _usuarioService.ObtenerListaRoles(), "RolId", "Nombre");
            ViewData["listaEstados"] = new SelectList(await _usuarioService.ObtenerListaEstados(), "EstadoId", "Nombre");
            return View();
        }
        
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Apellido,Correo,Contrasena,ConfContrasena,EstadoId,RolId")] Usuario usuario)
        {
            //var usuarioTemp = await _usuarioService.ObtenerUsuarioPorCorreo(usuario.Correo);
            if (ModelState.IsValid)
            {
                //var usuarioTemp = await _usuarioService.ObtenerUsuarioPorCorreo(usuario.Correo);
                
                    await _usuarioService.GuardarUsuario(usuario);
                    return RedirectToAction(nameof(Index));
                
                
            }
            
                //ViewData["errorCorreo"] = "Se encuentra un usuario registrado con este correo";
                return View(usuario);
        }
        
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioService.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["listaRoles"] = new SelectList(await _usuarioService.ObtenerListaRoles(), "RolId", "Nombre");
            ViewData["listaEstados"] = new SelectList(await _usuarioService.ObtenerListaEstados(), "EstadoId", "Nombre");
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Apellido,Correo,Contrasena,ConfContrasena,EstadoId,RolId")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _usuarioService.EditarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioService.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }
            await _usuarioService.EliminarUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }
        /*
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
        */
    }
}
