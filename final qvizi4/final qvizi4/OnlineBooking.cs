using System;
using System.Collections.Generic;

namespace final_qvizi4
{
    // OnlineBooking კლასის განსაზღვრა შეკვეთის ინფორმაციისთვის
    public class OnlineBooking
    {
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal DiscountedTotal { get; private set; }
        public decimal BonusPoints { get; private set; }
        public bool IsDiscountApplied { get; private set; }

        // კონსტრუქტორი ველების ინიციალიზაციისთვის და ფასდაკლებების გაანგარიშების წამოწყება
        public OnlineBooking(Client client, List<Product> products, DateTime orderDate)
        {
            Client = client;
            Products = products;
            OrderDate = orderDate;
            CalculateDiscounts();
        }

        // ფასდაკლების და ბონუსების გაანგარიშების მეთოდი
        private void CalculateDiscounts()
        {
            DateTime birthDate = Client.BirthDate;
            int clientAge = OrderDate.Year - birthDate.Year;
            if (birthDate.Date > OrderDate.AddYears(-clientAge)) clientAge--;

            // აქცია: 29 წლის ასაკში 29 თებერვალს შეუსრულდა, 29%-იანი ფასდაკლება
            if (OrderDate.Month == 2 && OrderDate.Day == 29 && clientAge == 29)
            {
                DiscountedTotal = CalculateTotal() * 0.71m; // 29% discount
                IsDiscountApplied = true;
            }
            else
            {
                DiscountedTotal = CalculateTotal();
                IsDiscountApplied = false;
            }

            // აქცია: 00:29 საათზე შეკვეთის განთავსება, 29 ლარის ბონუს ქულა
            if (OrderDate.Hour == 0 && OrderDate.Minute == 29)
            {
                BonusPoints = 29;
            }
            else
            {
                BonusPoints = 0;
            }
        }

        // საერთო ღირებულების გაანგარიშება
        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.TotalValue;
            }
            return total;
        }

        // მეთოდი ლექტორის დეტალების დასაბეჭდად
        public override string ToString()
        {
            string productDetails = "";
            foreach (var product in Products)
            {
                productDetails += $"\tProduct: {product.Name}, Code: {product.Code}, Quantity: {product.Quantity}, Price: {product.Price}, Total: {product.TotalValue}\n";
            }
            return $"Client: {Client.FirstName} {Client.LastName}, Personal Number: {Client.PersonalNumber}\n" +
                   $"Order Date: {OrderDate}\n" +
                   $"Products:\n{productDetails}" +
                   $"Total: {CalculateTotal()}, Discounted Total: {DiscountedTotal}, Bonus Points: {BonusPoints}\n" +
                   $"Discount Applied: {IsDiscountApplied}\n";
        }
    }
}
