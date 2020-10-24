using Farmino.Data.Models.Entities;
using Farmino.Data.Models.Value_Objects;
using Farmino.Service.Exceptions;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly FarminoDbContext _context;

        public PersonalDataService(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task SetPersonalDataAsync(string login, string firstName,
            string lastName, string phoneNumber, Address address)
        {
            if (_context.Users.Where(x => x.Login == login).Any())
            {
                var user = await _context.Users.
                    FirstOrDefaultAsync(x => x.Login == login);
                if (!_context.PersonalDatas.Where(x => x.UserId == user.Id).Any())
                {
                    _context.PersonalDatas.Add(new PersonalData(firstName, lastName,
                    phoneNumber, user.Id, address));
                    await _context.SaveChangesAsync();
                }
                else throw new ServiceExceptions(ServiceErrorCodes.AlreadyConnected,
                    "Connection already exist");
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect PersonalData on User that doesnt exist ");
        }

        public async Task EditGeneralDataAsync(string login, string firstName,
            string lastName, string phoneNumber)
        {
            if (_context.Users.Where(x => x.Login == login).Any())
            {
                var user = await _context.Users.
                    FirstOrDefaultAsync(x => x.Login == login);
                var personalData = await _context.PersonalDatas.
                    FirstOrDefaultAsync(x => x.UserId == user.Id);

                personalData.SetFirstName(firstName);
                personalData.SetLastName(lastName);
                personalData.SetPhoneNumber(phoneNumber);

                _context.PersonalDatas.Update(personalData);
                await _context.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                "Cannot connect PersonalData on User that doesnt exist ");
        }

        public async Task EditPersonalAddressAsync(string login, string city, string street,
            string postalCode, int houseNumber)
        {
            if (_context.Users.Where(x=>x.Login == login).Any())
            {
                var user = await _context.Users.
                     FirstOrDefaultAsync(x => x.Login == login);
                var personalData = await _context.PersonalDatas.
                    FirstOrDefaultAsync(x => x.UserId == user.Id);

                personalData.SetAddress(Address.Create(city, street, 
                    postalCode, houseNumber));

                _context.PersonalDatas.Update(personalData);
                await _context.SaveChangesAsync();
            }
                
        }
    }
}
