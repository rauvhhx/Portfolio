
using System;

namespace CafeOrderSystem
{
    public class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }

        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            Price = CalculatePrice();
        }

        public decimal CalculatePrice()
        {
            decimal price = 0;

            switch (Drink)
            {
                case DrinkType.Coffee:
                    switch (Size)
                    {
                        case DrinkSize.Small: price = 3m; break;
                        case DrinkSize.Medium: price = 4m; break;
                        case DrinkSize.Large: price = 5m; break;
                    }
                    break;

                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small: price = 2m; break;
                        case DrinkSize.Medium: price = 3m; break;
                        case DrinkSize.Large: price = 4m; break;
                    }
                    break;

                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small: price = 4m; break;
                        case DrinkSize.Medium: price = 5m; break;
                        case DrinkSize.Large: price = 6m; break;
                    }
                    break;

                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small: price = 1m; break;
                        case DrinkSize.Medium: price = 1.5m; break;
                        case DrinkSize.Large: price = 2m; break;
                    }
                    break;
            }

            return price;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş #{OrderNumber} statusu: {newStatus}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Sifariş #{OrderNumber}: {CustomerName} - {Drink} ({Size}) - Qiymət: {Price} AZN - Status: {Status}");
        }
    }
}
