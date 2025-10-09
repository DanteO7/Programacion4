using System.ComponentModel.DataAnnotations;

namespace PancheriaJP.Models.Ingrediente.Dto
{
    public class CreateUpdateIngredienteDTO
    {
        [Required]
        [MaxLength(40, ErrorMessage = "El nombre no puede superar los 40 caracteres")]
        public string Nombre { get; set; } = null!;
    }
}
