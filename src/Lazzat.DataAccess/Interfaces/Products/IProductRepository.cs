using Lazzat.DataAccess.Commons.Interfaces;
using Lazzat.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazzat.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, Product>, IGetAll<Product>
{
}
