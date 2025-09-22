namespace introduccion.Models.Cine.DTO
{
    public class CreateCineDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsOpen { get; set; }
    }
}
