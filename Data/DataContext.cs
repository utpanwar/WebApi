using Controllers.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Character> Character { get; set; }
        public DbSet<User> Users { get; set; }
    }
}