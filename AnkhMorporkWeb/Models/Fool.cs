using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkWeb.Models
{
    public class Fool : DefaultModel
    {
        [Required]
        public string Type { get; set; }
        public decimal Fee { get; set; }
        
    }
}