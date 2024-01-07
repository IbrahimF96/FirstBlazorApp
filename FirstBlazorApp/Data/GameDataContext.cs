using FirstBlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Data
{
    public class GameDataContext : DbContext
    {
        public GameDataContext(DbContextOptions<GameDataContext> options) 
            : base(options)
        {
            
        }

        public DbSet<AnimeCard> AnimeCards { get; set; }

        public DbSet<HighScore> HighScores { get; set; }
    }
}
