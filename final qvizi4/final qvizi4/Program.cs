using System;
using System.Collections.Generic;

namespace final_qvizi4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<OnlineBooking> bookings = new List<OnlineBooking>();

            // შექმნა მაგალითისთვის კლიენტები
            Client client1 = new Client("John", "Doe", "123456789", new DateTime(1991, 2, 29));
            Client client2 = new Client("Jane", "Smith", "987654321", new DateTime(1995, 3, 15));

            // შექმნა მაგალითისთვის პროდუქტები
            List<Product> products = new List<Product>
            {
                new Product("Laptop", "LP1001", 1, 1500),
                new Product("Mouse", "MS2002", 2, 25)
            };

            // შექმნა მაგალითისთვის შეკვეთები შემთხვევითი თარიღებით
            for (int i = 0; i < 30; i++)
            {
                DateTime randomDate = new DateTime(2024, 2, 29, rand.Next(0, 24), rand.Next(0, 60), rand.Next(0, 60));
                Client client = i % 2 == 0 ? client1 : client2;
                bookings.Add(new OnlineBooking(client, products, randomDate));
            }

            // შეამოწმეთ ფასდაკლების შესაბამისობა და დაბეჭდეთ დეტალები
            foreach (var booking in bookings)
            {
                if (booking.IsDiscountApplied || booking.BonusPoints > 0)
                {
                    Console.WriteLine("Eligible for discount or bonus:");
                    Console.WriteLine(booking);
                }
            }
        }
    }
}


//ონლაინ მაღაზიას, რომელიც კომპიუტერული სფეროსთვის დამახასიათებელი პროდუქტების რეალიზაციითაა დაკავებული ყოველ წელიწადს აქვს ფასდაკლების აქცია. 

//აქცია მდგომარეობს შემდეგში: 

//29 % -იანი ფასდაკლებით სარგებლობს მომხმარებელი, რომელსაც 29 თებერვალს შეუსრულდა 29 წელი (ოქროს დაბადების დღე).
// თუ მომხმარებელი ონლაინ-შეკვეთას განახორციელებს 00:29 წუთზე, 29 ლარის ბონუს ქულა დაერიცხება საბალანსო ანგარიშზე,
// ხოლო თუ იგივე დღეს განხორციელებული შეკვეთების საერთო რაოდენობა უდრის 29-ს,
// მომდევნო 4 წლის განმავლობაში მომხმარებელი ისარგებლებს 29%-იანი ფასდაკლებით.


//შექმენით კლასი OnlineBooking, რომლის წევრი მონაცემებია კლიენტი (სახელი, გვარი, პირადი ნომერი), პროდუქტ(ებ)ი 
//(დასახელება, კოდი, რაოდენობა, ფასი, ღირებულება = რაოდენობა * ფასზე), შეკვეთის თარიღი (დღე/თვე/წელი საათი:წუთი: წამი). 

//შეკვეთის თარიღი გაათამაშეთ შემთხვევითობის პრინციპით.

//შექმენით კლასის რამდენიმე ობიექტი და განათავსეთ ისინი მიმდევრობაში. 

//იპოვეთ ის შეკვეთ(ებ)ი, რომელზეც გავრცელდა ფასდაკლების აქცია და ეკრანზე გამოიტანე დეტალური ინფორმაცია განხორციელებული ტრანზაქციის შესახებ.