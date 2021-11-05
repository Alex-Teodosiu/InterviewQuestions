using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Model
{
    public class Book
    {
        [Required]
        public string ISBN { get; set; }
        public Room Room{ get; set; }
    }
}