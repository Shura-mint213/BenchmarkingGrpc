using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using Repositories.MsSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.MsSql
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _db;
        public OrderRepository(NorthwindContext db)
        {
            _db = db;
        }

        /// <summary>
        ///  <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public Task<List<Order>> GetAsync()
        {
            return _db.Orders.ToListAsync();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="skip"><inheritdoc/></param>
        /// <param name="take"><inheritdoc/></param>
        /// <returns> <inheritdoc/></returns>
        public Task<List<Order>> GetAsync(int skip, int take)
        {
            return _db.Orders
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
