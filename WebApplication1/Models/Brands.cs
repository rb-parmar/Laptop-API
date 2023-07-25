namespace WebApplication1.Models
{
    public class Brands
    {
        //fields
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<Laptops> Laptops { get; set; } = new HashSet<Laptops>();

        public Brands() { }
        public Brands( int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
