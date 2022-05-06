using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkWeb.Models
{
    public class Player : DefaultModel
    {
        [Required]
        public decimal Money { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required] 
        public int Beer { get; set; }
        [Required] 
        public int MeetingsWithThief { get; set; }
        [Required] 
        public string CurrentGuild { get; set; }
        public string LastMeeting { get; set; }
        [Required] 
        public string CurrentMeeting { get; set; }
    }
}