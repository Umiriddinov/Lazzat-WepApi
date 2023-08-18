using Dapper;
using Lazzat.DataAccess.Interfaces.Categories;
using Lazzat.DataAccess.Utils;
using Lazzat.Domain.Entities.Categories;

namespace Lazzat.DataAccess.Repositories.Categories;

public class CategoriesRepository : BaseRepositories, ICaregoryRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from categories";
            var result = await _connection.QuerySingleAsync<long>(query);
            
            return result;
        }
        catch
        {

            return 0;
        }
        finally { 
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO categories(name, created_at, updated_at) " +
                "VALUES (@Name, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Delete from categories where id = @Id";
            var result = await _connection.ExecuteAsync(query,new {Id = id});

            return result;
        }
        catch
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories order by id desc " +
                    $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Category>(query)).ToList();

            return result;
        }
        catch
        {

            return new List<Category>();
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Select * From categories where id = @Id";
            var result = await _connection.QuerySingleAsync<Category>(query, new {Id = id});

            return result;
        }
        catch 
        {

            return null;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE categories SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt" +
                $" where id = {id}";
            var result = await _connection.ExecuteAsync(query,entity);

            return result;  
        }
        catch
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }
}
