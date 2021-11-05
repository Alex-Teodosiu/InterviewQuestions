using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Model
{
    public class Row
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int RowNumber{ get; set; }
        public Bookshelf Bookshelf{ get; set; }
    }
}