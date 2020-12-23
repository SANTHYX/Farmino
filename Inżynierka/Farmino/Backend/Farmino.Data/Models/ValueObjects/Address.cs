using Farmino.Data.Exceptions;

namespace Farmino.Data.Models.ValueObjects
{
    public class Address
    {
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string PostalCode { get; protected set; }
        public int HouseNumber { get; protected set; }

        public Address(string city, string street, string postalCode, int houseNumber)
        {
            SetCity(city);
            SetStreet(street);
            SetPostalCode(postalCode);
            SetHouseNumber(houseNumber);
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new DataExceptions(DataErrorCodes.InvalidCity,
                    "City cannot be empty");
            }
            if (city == City)
            {
                return;
            }

            City = city;
        }

        public void SetStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
            {
                throw new DataExceptions(DataErrorCodes.InvalidStreet,
                    "Street cannot be empty");
            }
            if (street == Street)
            {
                return;
            }

            Street = street;
        }

        public void SetPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                throw new DataExceptions(DataErrorCodes.InvalidPostalCode,
                    "PostalCode cannot be empty");
            }
            if (postalCode == PostalCode)
            {
                return;
            }

            PostalCode = postalCode;
        }

        public void SetHouseNumber(int houseNumber)
        {
            if (houseNumber <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidHouseNumber,
                    "HouseNumber is invalid");
            }
            if (houseNumber == HouseNumber)
            {
                return;
            }

            HouseNumber = houseNumber;
        }

        public static Address Create(string city, string street, 
            string postalCode, int houseNumber)
            => new Address(city, street, postalCode, houseNumber);
    }
}
