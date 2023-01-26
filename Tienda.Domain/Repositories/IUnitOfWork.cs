using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IBrandRepository Brands { get; }
        ICategoryRepository Categories { get; }
        int Save();
    }
}
