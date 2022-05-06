using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkWeb.Models
{
    public class Assassin : DefaultModel
    {
        [Required]
        public decimal MinReward { get; set; }
        [Required]
        public decimal MaxReward { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}