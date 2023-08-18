using Lazzat.DataAccess.Utils;

namespace Lazzat.DataAccess.Commons.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search, PaginationParams  @params);
}
