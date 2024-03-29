﻿using AutoMapper;
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
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/OnePiece.png", Anime = AnimeSeries.OnePiece },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/Naruto.png", Anime = AnimeSeries.Naruto },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/DBZ.png", Anime = AnimeSeries.DragonBallZ },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/Bleach.png", Anime = AnimeSeries.Bleach },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/JujustuKaisen.png", Anime = AnimeSeries.JujutsuKaisen },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/DemonSlayer.png", Anime = AnimeSeries.DemonSlayer },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/OnePiece.png", Anime = AnimeSeries.OnePiece },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/Naruto.png", Anime = AnimeSeries.Naruto },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/DBZ.png", Anime = AnimeSeries.DragonBallZ },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/Bleach.png", Anime = AnimeSeries.Bleach },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/JujustuKaisen.png", Anime = AnimeSeries.JujutsuKaisen },
                    new AnimeCard { Id = Guid.NewGuid(), ImageSource = "/images/DemonSlayer.png", Anime = AnimeSeries.DemonSlayer }
                };

            await gameDataContext.AnimeCards.AddRangeAsync(defaultAnimeCards);
            await gameDataContext.SaveChangesAsync();
        }

    }
}
