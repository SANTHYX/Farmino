using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using System;

namespace Farmino.Data.Models.ValueObjects
{
    public class Weight
    {
        public WeightUnits Unit { get; protected set; }
        public double Value { get; protected set; }

        protected Weight() { } 

        public Weight(int unit, double value)
        {
            SetUnit(unit);
            SetValue(value);
        }

        public void SetValue(double value)
        {
            if (value <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightValue, 
                    "Weight value of product cannot be less or equal zero");
            }
            if (Value == value)
            {
                return;
            }

            Value = value;
        }

        public void SetUnit(int unit)
        {
            if (!Enum.IsDefined(typeof(WeightUnits), unit))
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "This unit are not existing in our system");
            }
            if (Unit == (WeightUnits)unit)
            {
                return;
            }

            Unit = (WeightUnits)unit;
        }

        public static Weight Create(int unit, double value)
            => new Weight(unit, value);
    }
}
