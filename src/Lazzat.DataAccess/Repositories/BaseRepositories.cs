using Dapper;
using Lazzat.DataAccess.Handlars;
using Npgsql;

namespace Lazzat.DataAccess.Repositories;

public class BaseRepositories
{
    protected NpgsqlConnection _connection;

    public BaseRepositories()
    {
        SqlMapper.AddTypeHandler(new DataOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=Lazzat-db; User Id=postgres; Password=@20112606;");
    }

}
