namespace PancheriaJP.Models.Pancho.Dto
{
    public class PanchoAderezoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Precio { get; set; }
        public List<string> Aderezos { get; set; } = new();
    }
}
