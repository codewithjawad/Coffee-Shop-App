using System;
namespace ConsoleApp2
{
    internal class CoffeeShop
    {
        public interface IOrderProcessor
        {
            void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich);
        }

        public class Shop : IOrderProcessor
        {
            private double coffeePrice;
            private double sandwichPrice;

            public double GetCoffeePrice()
            {
                return coffeePrice;
            }

            public void SetCoffeePrice(double value)
            {
                if (value < 0)
                {
                    Console.WriteLine("Coffee price cannot be negative.");
                }
                coffeePrice = value;
            }

            public double GetSandwichPrice()
            {
                return sandwichPrice;
            }

            public void SetSandwichPrice(double value)
            {
                if (value < 0)
                {
                    throw new ArgumentException("Sandwich price cannot be negative.");
                }
                sandwichPrice = value;
            }

            public void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich)
            {
                if (string.IsNullOrEmpty(customerName))
                {
                    Console.WriteLine("Customer name cannot be empty");
                    return;
                }

                double total = CalculateTotal(wantsCoffee, wantsSandwich);

                Console.WriteLine($"Order processed for {customerName}");
                Console.WriteLine($"Total amount to pay: {total:C}");
                ProcessPayment(total);
            }

            private double CalculateTotal(bool wantsCoffee, bool wantsSandwich)
            {
                double total = 0;

                if (wantsCoffee)
                {
                    total += coffeePrice;
                }
                if (wantsSandwich)
                {
                    total += sandwichPrice;
                }

                return total;
            }

            public void ProcessPayment(double amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("Payment amount cannot be negative.");
                }
                else
                {
                    Console.WriteLine($"Processing payment of {amount}");
                }
            }

            public void UpdateMenu(double newCoffeePrice, double newSandwichPrice)
            {
                SetCoffeePrice(newCoffeePrice);
                SetSandwichPrice(newSandwichPrice);
            }
        }
    }
}
