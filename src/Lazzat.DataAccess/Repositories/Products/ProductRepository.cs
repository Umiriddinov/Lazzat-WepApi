using Dapper;
using Lazzat.DataAccess.Interfaces.Products;
using Lazzat.DataAccess.Utils;
using Lazzat.Domain.Entities.Categories;
using Lazzat.Domain.Entities.Product;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Lazzat.DataAccess.Repositories.Products;

public class ProductRepository : BaseRepositories, IProductRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from products";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO products(category_id, name, description, image_path, created_at, updated_at) " +
                "VALUES (@CategoryId, @Name, @Description, @ImagePath, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE FROM products WHERE id=@Id";
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

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM products order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Product>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM products where id=@Id";
            var result = await _connection.QuerySingleAsync<Product>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE products SET category_id = @CategoryId, name = @Name, description = @Description," +
                $" image_path = @ImagePath, created_at = @CreatedAt, updated_at = @UpdatedAt" +
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
