using System.ComponentModel.DataAnnotations;

namespace PIS.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Kategori adı 100 karakterden uzun olamaz.")]
        public string? CategoryName { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();  // navigational property
    }
}
