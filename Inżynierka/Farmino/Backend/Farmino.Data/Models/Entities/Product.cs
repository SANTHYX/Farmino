using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;

namespace Farmino.Data.Models.Entities
{
    public class Product
    {
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public Weight Weight { get; protected set; }
        public Offer Offer { get; protected set; }

        protected Product() { }

        public Product(decimal price, int quantity, Weight weight)
        {
            SetPrice(price);
            SetQuantity(quantity);
            Weight = weight;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductPrice,
                    "Price cannot be less or equal zero");
            }
            if (Price == price)
            {
                return;
            }

            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductQuantity,
                    "Product quantity cannot be less than zero");
            }
            if (Quantity == quantity)
            {
                return;
            }

            Quantity = quantity;
        }

        public void DecreaseQuantity(int value)
        {
            if (Quantity - value < 0)
            {
                throw new DataExceptions("");
            }

            Quantity -= value;
        }

        public static Product Create(decimal price, int quantity, Weight weight)
            => new Product(price, quantity, weight);
    }
}
