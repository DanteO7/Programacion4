using PancheriaJP.Models.Categoria;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PancheriaJP.Models.Pancho
{
    public class Pancho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool IsVegano { get; set; }
        public double Precio { get; set; }
        public List<Ingrediente.Ingrediente> Ingredientes { get; set; } = new();
        public Categoria.Categoria Categoria { get; set; } = null!;

        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
    }

    public class PanchoIngrediente
    {
        public int PanchoId { get; set; }
        public int IngredienteId { get; set; }
    }
}
