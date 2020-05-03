using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObseverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Jan",
                    Email = "jan@gmail.com",
                    FavouriteCategories = new List<Category> { Category.A, Category.B }
                },
                new Customer()
                {
                    Name = "Maciej",
                    Email = "maciej@gmail.com",
                    FavouriteCategories = new List<Category> { Category.C, Category.D }
                }
            };

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "ProductA",
                    Price = 3.3m,
                    Discount = 5.5m,
                    Category = Category.A
                },
                new Product()
                {
                    Name = "ProductB",
                    Price = 45.6m,
                    Discount = 6m,
                    Category = Category.B
                },
                new Product()
                {
                    Name = "ProductC",
                    Price = 7.7m,
                    Discount = 10m,
                    Category = Category.C
                },
                new Product()
                {
                    Name = "ProductD",
                    Price = 11.5m,
                    Discount = 3.6m,
                    Category = Category.D
                }
            };

            //Adding new observers for the products
            products.ForEach(product => product.Subscribe(customers.ToArray()));

            //Trying to notify of a change
            Console.WriteLine("First product change");
            products.ForEach(product => product.Discount += 0.2m);
        }
    }
}
