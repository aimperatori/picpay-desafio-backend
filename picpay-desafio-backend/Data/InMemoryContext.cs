
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Models;

namespace picpay_desafio_backend.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> opt) : base(opt)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
    }
}
