namespace final_qvizi4
{
    // Product კლასის განსაზღვრა პროდუქტის ინფორმაციისთვის
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue => Quantity * Price;

        // კონსტრუქტორი ველების ინიციალიზაციისთვის
        public Product(string name, string code, int quantity, decimal price)
        {
            Name = name;
            Code = code;
            Quantity = quantity;
            Price = price;
        }
    }
}
