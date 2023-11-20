using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("MembershiptypeId")]
        public int? membershiptypeId { get; set; }

        //Navigation Property
        public virtual Membershiptype? Membershiptypes { get; set; }
        public List<Movie>? Movies { get; set; }




    }
}
