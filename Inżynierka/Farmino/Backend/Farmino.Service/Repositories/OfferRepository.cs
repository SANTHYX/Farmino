﻿using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly FarminoDbContext _context;

        public OfferRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Offer offer)
        {
            await _context.Offers.AddAsync(offer);
        }

        public void EditAsync(Offer offer)
        {
            _context.Offers.Update(offer);
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
            => await _context.Offers.Include(x => x.Product).Include(x => x.Farmer).ToListAsync();
            

        public async Task<Offer> GetAsync(Guid id)
            => await _context.Offers.Include(x => x.Product).Include(y => y.Farmer).FirstOrDefaultAsync(z => z.Id == id);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
