using CardDigitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CardDigitalAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Boleto>? Boletos { get; set; }
        public DbSet<Buyer>? Buyers { get; set; }
        public DbSet<Card>? Cards { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Payment>? Payments { get; set; }



    }
}
