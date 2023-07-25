namespace WebApplication1.Models
{
    public class Laptops
    {
        // fields
        public int Id { get; set; }
        public string Name { get; set; }
        public Brands Brand { get; set; }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be below 0.");
                }
                else
                {
                    _price = value;
                }
            }
        }
        private int _yearOfMake;
        public int YearOfMake
        {
            get { return _yearOfMake; }
            set
            {
                // I googled when the first laptop was made, and thats where i got 1981
                if (value < 1981 && value > 2024)
                {
                    throw new ArgumentOutOfRangeException("value");
                } else
                {
                    _yearOfMake = value;
                }
            }
        }
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                } else
                {
                    _quantity = value;
                }
            }
        }
        public string Type { get; set; }
        public int ViewCount { get; set; }

        public Laptops() { }    
        public Laptops(int id, string name, Brands brand, decimal price, int yearOfMake, int quantity, string type, int viewCount = 0)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
            YearOfMake = yearOfMake;
            Quantity = quantity;
            Type = type;
            ViewCount = viewCount;
        }
    }
}
