using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Model
{
    public class Room
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int RoomNumber{ get; set; }
        public Row Row { get; set; }
    }
}