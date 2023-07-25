namespace WebApplication1.Models
{
    static class Database
    {
        private static int _pk_laptop = 1001;
        private static int _pk_brand = 3001;
        public static HashSet<Laptops> Laptops { get; set; } = new HashSet<Laptops>();
        public static HashSet<Brands> Brands { get; set; } = new HashSet<Brands> { };

        static Database()
        {
            _seedMethodBrands();
            _seedMethodLaptops();
        }

        // Methods
        public static void CreateLaptop(string name, Brands brand, double price, int yearOfMake, int quantity, string type)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException("type");
            }

            Laptops newLaptop = new Laptops(_pk_laptop++, name, brand, price, yearOfMake, quantity, type);
            Laptops.Add(newLaptop);
        }
        private static void _seedMethodLaptops()
        {
            CreateLaptop("XPS", Brands.ElementAt(0), 500.00, 2021, 5, "New");
            CreateLaptop("Vostro", Brands.ElementAt(0), 850.00, 2020, 3, "Refurbished");
            CreateLaptop("Inspiron", Brands.ElementAt(0), 900.00, 2020, 2, "Rental");

            CreateLaptop("Envy", Brands.ElementAt(1), 1200.00, 2022, 3, "New");
            CreateLaptop("Omen", Brands.ElementAt(1), 1000.00, 2020, 2, "Refurbished");
            CreateLaptop("Pavillion", Brands.ElementAt(1), 950.50, 2021, 1, "Rental");

            CreateLaptop("Legion", Brands.ElementAt(2), 1050.00, 2022, 3, "New");
            CreateLaptop("ThinkPad", Brands.ElementAt(2), 700.00, 2023, 6, "Refurbished");
            CreateLaptop("Yoga", Brands.ElementAt(2), 1200.00, 2021, 4, "Rental");

        }
        public static void CreateBrand(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentOutOfRangeException("name");
            } else
            {
                Brands newBrand = new Brands(_pk_laptop++, name);
                Brands.Add(newBrand);
            }
        }
        private static void _seedMethodBrands()
        {
            CreateBrand("Dell");
            CreateBrand("HP");
            CreateBrand("Lenovo");
        }
    }
}
