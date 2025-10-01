namespace construccionesMaterIa.Models.Camion
{
    public class Camion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public bool isInRecorrido { get; set; } 
        public List<string>? Materiales { get; set; }
        public int Personas { get; set; }
        public DateTime? Salida { get; set; }
        public DateTime? Entrada { get; set; }
    }
}

