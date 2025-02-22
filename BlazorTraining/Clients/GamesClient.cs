﻿using BlazorTraining.Models;

namespace BlazorTraining.Clients
{
    public class GamesClient
    {
        private readonly List<GameSummary> games = [
            new(){
                Id = 1,
                Name ="Dark souls",
                Genre = "RPG",
                Price = 549.00M,
                ReleaseDate = new DateOnly(2011, 9, 22)
            },
            new(){
                Id = 2,
                Name = "Pokemon Platinum",
                Genre = "RPG",
                Price = 800.00M,
                ReleaseDate = new DateOnly(2008, 9, 13)
            },
            new(){
                Id= 3,
                Name = "Monster Hunter Rise",
                Genre = "ARPG",
                Price = 490.00M,
                ReleaseDate = new DateOnly(2021, 3, 26)
            }
        ];

        private readonly Genre[] genres = new GenresClient().GetGenres();

        public GameSummary[] GetGames() => [.. games];

        public void AddGame(GameDetails game)
        {
            Genre genre = GetGenreById(game.GenreId);

            var gameSummary = new GameSummary
            {
                Id = games.Count() + 1,
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };

            games.Add(gameSummary);
        }

        public GameDetails GetGame(int id)
        {
            GameSummary? game = GetGameSummaryById(id);

            var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public void UpdateGame(GameDetails updatedGame)
        {
            var genre = GetGenreById(updatedGame.GenreId);
            GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = genre.Name;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
        }

        public void DeleteGame(int id)
        {
            var game = GetGameSummaryById(id);
            games.Remove(game);
        }

        private GameSummary GetGameSummaryById(int id)
        {
            GameSummary? game = games.Find(game => game.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            return game;
        }

        private Genre GetGenreById(string? id)
        {
            ArgumentException.ThrowIfNullOrEmpty(id);
            return genres.Single(genre => genre.Id == int.Parse(id));
        }

    }
}
