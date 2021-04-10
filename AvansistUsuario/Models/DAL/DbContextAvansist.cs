using AvansistUsuario.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansistUsuario.Models.DAL
{
    public class DbContextAvansist : DbContext
    {
        public DbContextAvansist(DbContextOptions<DbContextAvansist> options)
            :base (options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
