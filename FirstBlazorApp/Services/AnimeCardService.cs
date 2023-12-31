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
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimeCardService(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AnimeCardDTO>> GetCardsAsync()
        {
            var cards = await _context.AnimeCards.ToListAsync();

            if (!cards.Any())
            {
                await SeedInitialCards();
                cards = await _context.AnimeCards.ToListAsync();
            }

            List<AnimeCardDTO> _cardDtos = _mapper.Map<List<AnimeCardDTO>>(cards);
            return _cardDtos;
        }

        private async Task SeedInitialCards()
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

            _context.AnimeCards.AddRange(defaultAnimeCards);
            await _context.SaveChangesAsync();
        }

    }
}
