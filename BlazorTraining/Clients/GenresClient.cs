using BlazorTraining.Models;

namespace BlazorTraining.Clients
{
    public class GenresClient
    {
        private readonly Genre[] genres = [
            new(){
                Id = 1,
                Name = "Fighting"
            },
            new(){
                Id = 2,
                Name="RPG"
            },
            new(){
                Id = 3,
                Name ="ARPG"
            }, new(){
                Id = 4,
                Name ="FPS"
            }
        ];

        public Genre[] GetGenres() => genres;
    }
}
