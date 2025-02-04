using Microsoft.EntityFrameworkCore;
using MSFercorp.Pago.Models;

namespace MSFercorp.Pago.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }

    }
}
