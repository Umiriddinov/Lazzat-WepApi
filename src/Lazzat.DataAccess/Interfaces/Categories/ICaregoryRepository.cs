using Lazzat.DataAccess.Commons.Interfaces;
using Lazzat.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazzat.DataAccess.Interfaces.Categories;

public interface ICaregoryRepository : IRepository<Category, Category>,IGetAll<Category>
{
}
