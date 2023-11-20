using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("genre_Id")]
        public int genre_Id { get; set; }

        //Navigation Property
        public virtual Genre?  Genres { get; set; }
        public List<Customer>? Customers { get; set; }  
        
        //add attributes

        public DateTime? MovieAdded { get; set; }
        public string? Photo { get; set; }

       


    }
}
