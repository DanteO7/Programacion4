using System.ComponentModel.DataAnnotations;

namespace PancheriaJP.Models.Pancho.Dto
{
    public class CreatePanchoDTO
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } = null!;

        [Required]
        public bool IsVegano { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Precio { get; set; }

        [Required]
        public List<string> Aderezos { get; set; } = new();

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public List<int> IngredientesIds {  get; set; } = new();
    }
}
