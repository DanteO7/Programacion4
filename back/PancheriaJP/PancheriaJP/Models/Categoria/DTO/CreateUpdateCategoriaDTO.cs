using System.ComponentModel.DataAnnotations;

namespace PancheriaJP.Models.Categoria.Dto
{
    public class CreateUpdateCategoriaDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre no puede superar los 20 caracteres")]
        public string Nombre { get; set; } = null!;
    }
}
