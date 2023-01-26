using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Domain.Repositories;
using Tienda.Infraestructure.Data;

namespace Tienda.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaContext _context;
        private IProductRepository _products;
        private IBrandRepository _brands;
        private ICategoryRepository _categories;

        public UnitOfWork(TiendaContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_context);
                }
                return _categories;
            }
        }

        public IBrandRepository Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new BrandRepository(_context);
                }
                return _brands;
            }
        }
        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_context);
                }
                return _products;
            }
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
