using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkWeb.Models
{
    public class Thief : DefaultModel
    {
        [Required]
        public decimal Fee { get; set; }
    }
}