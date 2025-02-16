using BlazorTraining.Models;

namespace BlazorTraining.Clients
{
    public class GamesClient
    {
        private readonly GameSummary[] games = [
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

        public GameSummary[] GetGames() => [.. games];
    }
}
