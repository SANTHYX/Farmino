using Farmino.Data.Exceptions;
using System;

namespace Farmino.Data.Models.ValueObjects
{
    public class Weight
    {
        public string Unit { get; protected set; }
        public double Value { get; protected set; }

        public Weight(string unit, double value)
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

        public void SetUnit(string unit)
        {
            throw new NotImplementedException();
        }
    }
}
