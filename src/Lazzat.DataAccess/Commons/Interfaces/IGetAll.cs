using Lazzat.DataAccess.Utils;

namespace Lazzat.DataAccess.Commons.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
