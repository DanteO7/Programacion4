using Pancheria.Models.Pancho;
using Pancheria.Models.Pancho.DTO;

namespace Pancheria.Services
{
    public interface IPanchoServices
    {
        List<PanchoDTO> GetAll();
        Pancho GetOneById(int id);
        List<PanchoAderezoDTO> GetAllByCondiment(string condiment);
    }
    public class PanchoServices : IPanchoServices
    {
        private List<Pancho> _panchos = new List<Pancho>()
        {
            new Pancho()
            {
                Id = 1,
                Name = "Pancho Clasico",
                IsVegan = false,
                Price = 500,
                Condiment = new List<string>() { "Mostaza", "Ketchup", "Mayonesa" }
            },
            new Pancho()
            {
                Id = 2,
                Name = "Pancho Vegano",
                IsVegan = true,
                Price = 700,
                Condiment = new List<string>() { "Mostaza", "Ketchup", "Mayonesa Vegana" }
            },
            new Pancho()
            {
                Id = 3,
                Name = "Pancho Especial",
                IsVegan = false,
                Price = 900,
                Condiment = new List<string>() { "Mostaza", "Ketchup", "Mayonesa", "Cebolla Caramelizada", "Panceta" }
            }
        };
        public List<PanchoDTO> GetAll()
        {
            return _panchos.Select(p => new PanchoDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
        public Pancho GetOneById(int id)
        {
            var pancho = _panchos.FirstOrDefault(p => p.Id == id);
            if (pancho == null)
            {
                throw new Exception($"Pancho not found with ID = {id}");
            }
            return pancho;
        }

        public List<PanchoAderezoDTO> GetAllByCondiment(string condiment)
        {
            var panchos = _panchos.Where(p => p.Condiment.Any(c => c.Equals(condiment, StringComparison.OrdinalIgnoreCase))).ToList();
            return panchos.Select(p => new PanchoAderezoDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Condiment = p.Condiment
            }).ToList();
        }
    }
}
