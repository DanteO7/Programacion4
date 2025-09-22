namespace introduccion.Models.Cine
{
    public class Cine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsOpen { get; set; }

    }
}
