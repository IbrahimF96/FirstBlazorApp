using FirstBlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
            
        }

        public DbSet<AnimeCard> AnimeCards { get; set; }
    }
}
