namespace Pancheria.Models.Pancho
{
    public class Pancho
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Length > 30)
                {
                    throw new ArgumentException("Name cannot be null or empty and have a max of 30 characters.");
                }
                _name = value;
            }
        }
        public bool IsVegan { get; set; }
        public decimal Price { get; set; }
        public List<string> Condiment { get; set; } = new List<string>();
    }
}
