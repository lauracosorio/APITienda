using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ApiTienda.Models
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public DbSet<TiendaItem> TiendaItems { get; set; }
    }
}
