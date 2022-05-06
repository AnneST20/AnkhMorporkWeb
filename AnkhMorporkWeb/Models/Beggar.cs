using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkWeb.Models
{
    public class Beggar : DefaultModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required]
        public bool Beer { get; set; }
    }
}