using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Model
{
    public class Bookshelf
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int BookshelfNumber{ get; set; }
    }
}