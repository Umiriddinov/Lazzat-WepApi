using Dapper;
using Lazzat.DataAccess.Interfaces.Followers;
using Lazzat.DataAccess.Utils;
using Lazzat.Domain.Entities.Categories;
using Lazzat.Domain.Entities.Follower;
using System.Collections.Generic;

namespace Lazzat.DataAccess.Repositories.Followers;

public class FollowerRepository : BaseRepositories, IFollowRepositories
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from follower";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Follow entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO follower(email, created_at, updated_at)" +
                "VALUES(@Email,@CreatedAt, @UpdatedAt); ";
            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM follower WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Follow>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM followe order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Follow>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Follow>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Follow?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM follower where id=@Id";
            var result = await _connection.QuerySingleAsync<Follow>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Follow entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.follower" +
                $" SET email = @Email, created_at = @CreatedAt, updated_at = @UpdatedAt" +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
