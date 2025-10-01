using construccionesMaterIa.Config;
using construccionesMaterIa.Models.Camion;

namespace construccionesMaterIa.Services
{
    public interface ICamionService
    {
        List<Camion> GetAllActive();
        Camion CreateOne(Camion camion);
        Camion StartTravel(int id, int cantidadPersonas);
        Camion FinishTravel(int id);
    }
    public class CamionService : ICamionService
    {
        private readonly ApplicationDbContext _db;
        public CamionService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<Camion> GetAllActive()
        {
            return _db.Camiones.ToList();
        }
        public Camion CreateOne(Camion camion)
        {
            _db.Camiones.Add(camion);
            _db.SaveChanges();
            return camion;
        }

        public Camion StartTravel(int id, int cantidadPersonas)
        {
            var camion = _db.Camiones.FirstOrDefault(p => p.Id == id);
            if (camion == null)
            {
                throw new Exception("Camion not found");
            }
            camion.isInRecorrido = true;
            camion.Salida = DateTime.Now;
            camion.Personas = cantidadPersonas;

            return camion;
        }

        public Camion FinishTravel(int id)
        {
            var camion = _db.Camiones.FirstOrDefault(p => p.Id == id);
            if (camion == null)
            {
                throw new Exception("Camion not found");
            }
            camion.isInRecorrido = false;
            camion.Salida = DateTime.Now;

            return camion;
        }

    }
}
