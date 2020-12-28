using Farmino.Data.Exceptions;
using Farmino.Data.Extensions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Profile
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Address Address { get; protected set; }

        protected Profile() { }

        public Profile(string firstName, string lastName, string phoneNumber)
        {
            Id = Guid.NewGuid();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhoneNumber(phoneNumber);
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DataExceptions(DataErrorCodes.InvalidFirstName,
                    "FirstName cannot be empty");
            }
            if (firstName == FirstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DataExceptions(DataErrorCodes.InvalidLastName, 
                    "LastName cannot be empty");
            }
            if (lastName == LastName)
            {
                return;
            }

            LastName = lastName;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new DataExceptions(DataErrorCodes.InvalidPhoneNumber,
                    "Number is invalid");
            }
            if (!phoneNumber.IsNumber())
            {
                throw new DataExceptions(DataErrorCodes.InvalidPhoneNumber,
                    "Number is too short or too long,number should contain 9 numbers");
            }
            if (phoneNumber == PhoneNumber)
            {
                return;
            }

            PhoneNumber = phoneNumber;
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}
