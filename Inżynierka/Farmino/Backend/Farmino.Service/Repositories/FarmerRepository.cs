﻿using Farmino.Data.Models.Aggregations;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly FarminoDbContext _context;
        public FarmerRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _context.Farmers.AddAsync(farmer);
        }

        public async Task<Farmer> GetAsync(string login)
            => await _context.Farmers.Include(x => x.User).Include(x => x.Offers)
            .FirstOrDefaultAsync(x => x.User.Login == login);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
