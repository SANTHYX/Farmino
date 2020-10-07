using System;

namespace Farmino.Data.Models
{
    public class Address
    {
        public Guid Id { get; protected set; }
        public string City { get; protected set; }
        public string PostalCode { get; protected set; }
        public string Street { get; protected set; }
        public int StreetNumber { get; protected set; }

        public Address(string city, string postalCode, string street, int streetNumber)
        {
            Id = Guid.NewGuid();
            SetCity(city);
            SetPostalCode(postalCode);
            SetStreet(street);
            SetStreetNumber(streetNumber);
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new Exception("City field is empty");
            }
            if (city == City)
            {
                return;
            }

            City = city;
        }
        public void SetPostalCode(string postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
            {
                throw new Exception("City field is empty");
            }
            if (postalCode == PostalCode)
            {
                return;
            }

            PostalCode = postalCode;
        }
        public void SetStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
            {
                throw new Exception("Street field is empty");
            }
            if (street == Street)
            {
                return;
            }

            Street = street;
        }
        public void SetStreetNumber(int streetNumber)
        {
            if(streetNumber <= 0)
            {
                throw new Exception("StreetNumber is invalid");
            }
            if(streetNumber == StreetNumber)
            {
                return;
            }

            StreetNumber = streetNumber;
        }
    }
}
