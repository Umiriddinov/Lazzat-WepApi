﻿using Dapper;
using System.Data;

namespace Lazzat.DataAccess.Handlars;

public class DataOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value)
    {
        if (value is not null) {
            var datetime = DateTime.Parse(value.ToString()!);
            return DateOnly.FromDateTime(datetime);
        }
        else return new DateOnly();
    }

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.Value = (object)("" +  value.Year + "-" + value.Month + "-" + value.Day);
    }
}
