using System.ComponentModel.DataAnnotations;

namespace PancheriaJP.Models.Pancho.Dto
{
    public class UpdatePanchoDTO
    {
        [MaxLength(30)]
        public string? Nombre { get; set; } = null!;

        public bool? IsVegano { get; set; }

        [Range(0.01, double.MaxValue)]
        public double? Precio { get; set; }

        public List<Ingrediente.Ingrediente>? Inrgredientes { get; set; } = null!;

        public int? CategoriaId { get; set; }
        public List<int> IngredientesIds { get; set; } = new();
    }
}
