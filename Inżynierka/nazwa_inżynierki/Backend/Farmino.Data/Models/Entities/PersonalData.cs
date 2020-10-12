using Farmino.Data.Extensions;
using Farmino.Data.Models.Aggregations;
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

        protected PersonalData()
        {}
        public PersonalData(string firstName, string lastName, 
            string phoneNumber, Guid userId)
        {
            Id = Guid.NewGuid();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhoneNumber(phoneNumber);
            SetUserId(userId);
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception("FirstName cannot be empty");
            }
            if(firstName == FirstName)
            {
                return;
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception("LastName cannot be empty");
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
                throw new Exception("Number is invalid");
            }
            if (!phoneNumber.IsNumber())
            {
                throw new Exception("Number is too short or too long, " +
                    "number should contain 9 numbers");
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
                throw new Exception("Foregin key is empty");
            }

            UserId = userId;
        }
    }
}
