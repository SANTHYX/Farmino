using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Farmino.Data.Models
{
    public class Address
    {
        [NotNull, Required]
        public Guid Id { get; protected set; }
        [Required]
        public string City { get; protected set; }
        [Required]
        public string PostalCode { get; protected set; }
        [Required]
        public string Street { get; protected set; }
        [Required]
        public int StreetNumber { get; protected set; }
        [Required]
        public DateTime UpdatedOn { get; protected set; }
        [Required]
        public DateTime CreatedOn { get; protected set; }

        public Address(string city, string postalCode, string street, int streetNumber)
        {
            Id = Guid.NewGuid();
            SetCity(city);
            SetPostalCode(postalCode);
            SetStreet(street);
            SetStreetNumber(streetNumber);
            CreatedOn = UpdatedOn = DateTime.Now;
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
            UpdatedOn = DateTime.Now;
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
            UpdatedOn = DateTime.Now;
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
            UpdatedOn = DateTime.Now;
        }
        public void SetStreetNumber(int streetNumber)
        {
            if (streetNumber <= 0)
            {
                throw new Exception("StreetNumber is invalid");
            }
            if (streetNumber == StreetNumber)
            {
                return;
            }

            StreetNumber = streetNumber;
            UpdatedOn = DateTime.Now;
        }
    }
}
