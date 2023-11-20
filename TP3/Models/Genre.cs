namespace TP3.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }

        //Navigation Property
        public List<Movie>? Movies { get; set; }
    }
}
