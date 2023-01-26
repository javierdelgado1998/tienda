﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Domain.Models
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
