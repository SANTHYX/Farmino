using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using System;
using System.Text.Json.Serialization;

namespace Farmino.Data.Models.Entities
{
    public class Product
    {
        public decimal BasePrice { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeightUnits BaseWeightUnit { get; protected set; }
        public Offer Offer { get; protected set; }

        protected Product() { }

        public Product(decimal price, WeightUnits weight)
        {
            SetBasePrice(price);
            SetUnit(weight);
        }

        public void SetUnit(WeightUnits weightUnit)
        {
            if (!Enum.IsDefined(typeof(WeightUnits), weightUnit))
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid product weight unit");
            }

            BaseWeightUnit = weightUnit;
        }

        public void SetBasePrice(decimal price)
        {
            if (price <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductPrice,
                    "BasePrice cannot be less or equal zero");
            }
            if (BasePrice == price)
            {
                return;
            }

            BasePrice = price;
        }

        public static Product Create(decimal price, WeightUnits weight)
            => new Product(price, weight);
    }
}
