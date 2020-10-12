using Farmino.Data.Models.Entities;
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
            string lastName, string phoneNumber)
        {
            if (_context.Users.Where(x => x.Login == login).Any())
            {
                var user = await _context.Users.
                    FirstOrDefaultAsync(x => x.Login == login);
                _context.PersonalDatas.Add(new PersonalData(firstName, lastName,
                    phoneNumber, user.Id));
                await _context.SaveChangesAsync(); 
            }
            else throw new Exception("Cannot connect PersonalData with " +
                "User that doesnt exist ");
        }

        public async Task EditPersonalDataAsync(string login, string firstName,
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
            else throw new Exception("Cannot edit PersonalData with " +
                "User that doesnt exist ");
        }
    }
}
