using AutoMapper;
using FirstBlazorApp.Data;
using FirstBlazorApp.DTOs;
using FirstBlazorApp.Enums;
using FirstBlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Services
{
    public class AnimeCardService : IAnimeCardService
    {
        private readonly IDbContextFactory<GameDataContext> _dbFactory;
        private readonly IMapper _mapper;

        public AnimeCardService(IDbContextFactory<GameDataContext> dbFactory, IMapper mapper)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AnimeCardDTO>> GetCardsAsync()
        {
            using var context = _dbFactory.CreateDbContext();
            var cards = await context.AnimeCards.ToListAsync();

            if (!cards.Any())
            {
                await SeedInitialCards(context);
                cards = await context.AnimeCards.ToListAsync();
                context.Dispose();
            }

            List<AnimeCardDTO> _cardDtos = _mapper.Map<List<AnimeCardDTO>>(cards);
            return _cardDtos;
        }

        private async Task SeedInitialCards(GameDataContext gameDataContext)
        {
            var defaultAnimeCards = new List<AnimeCard>
                {
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp12821652.jpg", Anime = AnimeSeries.OnePiece },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp4789300.jpg", Anime = AnimeSeries.Naruto },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp6088968.jpg", Anime = AnimeSeries.DragonBallZ },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp8006814.jpg", Anime = AnimeSeries.Bleach },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp9137385.jpg", Anime = AnimeSeries.JujutsuKaisen },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp7854208.jpg", Anime = AnimeSeries.DemonSlayer },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp12821652.jpg", Anime = AnimeSeries.OnePiece },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp4789300.jpg", Anime = AnimeSeries.Naruto },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp6088968.jpg", Anime = AnimeSeries.DragonBallZ },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp8006814.jpg", Anime = AnimeSeries.Bleach },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp9137385.jpg", Anime = AnimeSeries.JujutsuKaisen },
                    new AnimeCard { Id = Guid.NewGuid(), ImageURL = "https://wallpapercave.com/dwp1x/wp7854208.jpg", Anime = AnimeSeries.DemonSlayer }
                };

            await gameDataContext.AnimeCards.AddRangeAsync(defaultAnimeCards);
            await gameDataContext.SaveChangesAsync();
        }

    }
}
