using Farmino.Data.Exceptions;
using Farmino.Data.Extensions;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Value_Objects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmino.Data.Models.Entities
{
    public class PersonalData
    {
        [Key]
        public Guid Id { get; protected set; }
        [Required]
        public string FirstName { get; protected set; }
        [Required]
        public string LastName { get; protected set; }
        [Required]
        public string PhoneNumber { get; protected set; }
        [Required] 
        public Guid UserId { get; protected set; }
        [ForeignKey("UserId")]
        public User User { get; protected set; }
        public Address Address { get; protected set; }

        protected PersonalData()
        {}
        public PersonalData(string firstName, string lastName, 
            string phoneNumber, Guid userId, Address address)
        {
            Id = Guid.NewGuid();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhoneNumber(phoneNumber);
            SetUserId(userId);
            SetAddress(address);
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DataExceptions(DataErrorCodes.InvalidFirstName,
                    "FirstName cannot be empty");
            }
            if(firstName == FirstName)
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
            if(phoneNumber == PhoneNumber)
            {
                return;
            }

            PhoneNumber = phoneNumber;
        }

        public void SetUserId(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new DataExceptions(DataErrorCodes.InvalidUserId,
                    "Foregin key is empty");
            }

            UserId = userId;
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }
    }
}
