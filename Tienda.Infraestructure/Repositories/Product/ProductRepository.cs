using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Models;
using Tienda.Domain.Repositories;
using Tienda.Infraestructure.Data;

namespace Tienda.Infraestructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TiendaContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Product>> GetMostExpensiveProducts(int quantity) => await _context.Products
            .OrderByDescending(p => p.Price)
            .Take(quantity)
            .ToListAsync();

    }
}
