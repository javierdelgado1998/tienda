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
    public class BrandRepository: GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(TiendaContext context) : base(context)
        {

        }
    }
}
