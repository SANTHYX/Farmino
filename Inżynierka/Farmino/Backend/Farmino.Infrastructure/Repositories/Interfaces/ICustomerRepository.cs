﻿using Farmino.Data.Models.Aggregations;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetAsync(string userName);
        Task SaveChangesAsync();
    }
}
