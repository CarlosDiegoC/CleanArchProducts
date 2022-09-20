using System.ComponentModel.DataAnnotations;

namespace CleanArchProducts.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The name is require.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}