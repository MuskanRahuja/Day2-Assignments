using System;
using System.Collections.Generic;

namespace ProductManagement
{
    class Product
    {
        public int PCode { get; }
        public string PName { get; set; }
        public int QtyInStock { get; set; }
        public double DiscountAllowed { get; set; }
        public string Brand { get; }

        public Product(int pCode, string pName, int qtyInStock, double discountAllowed, string brand)
        {
            PCode = pCode;
            PName = pName;
            QtyInStock = qtyInStock;
            DiscountAllowed = discountAllowed;
            Brand = brand;
        }

        public void DisplayProductDetails()
        {
            Console.WriteLine("Product Code: " + PCode);
            Console.WriteLine("Product Name: " + PName);
            Console.WriteLine("Quantity in Stock: " + QtyInStock);
            Console.WriteLine("Discount Allowed: " + DiscountAllowed + "%");
            Console.WriteLine("Brand: " + Brand);
        }

        public double CalculateTotalAmount(int quantity)
        {
            // Apply a 50% discount on all products if today is 26th January
            DateTime today = DateTime.Today;
            if (today.Month == 1 && today.Day == 26)
            {
                return (QtyInStock >= quantity) ? (QtyInStock - quantity) * (1 - DiscountAllowed / 100) : 0;
            }
            else
            {
                return -1; // Discount not applicable on other days
            }
        }
    }

    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            while (true)
            {
                Console.WriteLine("Who are you? (1 for Admin, 2 for Customer, 0 to exit)");
                int userType = int.Parse(Console.ReadLine());

                if (userType == 0)
                {
                    break;
                }
                else if (userType == 1)
                {
                    Console.WriteLine("Admin Menu:");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Display Products");
                    int adminChoice = int.Parse(Console.ReadLine());

                    if (adminChoice == 1)
                    {

                        Console.Write("Enter Product Code: ");
                        int pCode = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string pName = Console.ReadLine();
                        Console.Write("Enter Quantity in Stock: ");
                        int qtyInStock = int.Parse(Console.ReadLine());
                        Console.Write("Enter Discount Allowed (%): ");
                        double discountAllowed = double.Parse(Console.ReadLine());
                        Console.Write("Enter Brand: ");
                        string brand = Console.ReadLine();

                        Product newProduct = new Product(pCode, pName, qtyInStock, discountAllowed, brand);
                        products.Add(newProduct);

                        Console.WriteLine("Product added successfully!");
                    }
                    else if (adminChoice == 2)
                    {

                        foreach (Product product in products)
                        {
                            Console.WriteLine("Product Details:");
                            product.DisplayProductDetails();
                            Console.WriteLine();
                        }
                    }
                }
                else if (userType == 2)
                {
                    Console.WriteLine("Customer Menu:");
                    Console.WriteLine("Enter the product name you want to purchase:");
                    string productName = Console.ReadLine();
                    int quantity = 0;
                    Product selectedProduct = null;

                    foreach (Product product in products)
                    {
                        if (product.PName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                        {
                            selectedProduct = product;
                            Console.WriteLine("Product Details:");
                            product.DisplayProductDetails();
                            Console.Write("Enter the quantity you want to purchase: ");
                            quantity = int.Parse(Console.ReadLine());
                            break;
                        }
                    }

                    if (selectedProduct == null)
                    {
                        Console.WriteLine("Product not found.");
                    }
                    else
                    {
                        double totalAmount = selectedProduct.CalculateTotalAmount(quantity);
                        if (totalAmount >= 0)
                        {
                            Console.WriteLine("Total Amount to Pay: $" + totalAmount);
                        }
                        else
                        {
                            Console.WriteLine("Discount not applicable today.");
                        }
                    }
                }
            }
        }
    }
}
