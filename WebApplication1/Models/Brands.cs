namespace WebApplication1.Models
{
    public class Brands
    {
        //fields
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Laptops> Laptops { get; set; } = new List<Laptops>();

        public Brands() { }
        public Brands( int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
