using Farmino.Data.Exceptions;
using Farmino.Data.Extensions;

namespace Farmino.Data.Models.ValueObjects
{
    public class OrderDetails
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public Address Address { get; protected set; }

        protected OrderDetails() { }

        public OrderDetails(string firstName, string lastName, string phoneNumber, Address address)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhoneNumber(phoneNumber);
            Address = address;
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

        public static OrderDetails Create(string firstName, string lastName, string phoneNumber, Address address)
            => new OrderDetails(firstName, lastName, phoneNumber, address);
    }
}
