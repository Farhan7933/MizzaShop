using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mizza.DataRepo
{
    public static class ExtnWorks
    {
        public static List<T> GetDatas<T>(this T item, DataTable dt)  where T : new()
        {
            List<T> MizzaDataList = new List<T>();
            foreach(DataRow dr in dt.Rows)
            {
                var record = CreateItemFromRow<T>(dr);
                MizzaDataList.Add(record);
            }

            return MizzaDataList;
        }

        public static T CreateItemFromRow<T>(DataRow row)  where T : new()
        {
            T item = new T();
            foreach (DataColumn col in row.Table.Columns)
            {
                PropertyInfo propInfo = item.GetType().GetProperty(col.ColumnName);
                if (propInfo != null && row[col] != DBNull.Value)
                {
                    propInfo.SetValue(item, row[col], null);
                }
            }

            return item;
        }

        public static SqlCommand GetProcedureQuery<T>(this T item, SqlCommand sqlCommand)
        {
            foreach(var prop in item.GetType().GetProperties())
            {
                if (prop.GetValue(item).IsNullOrDefault()) continue;
                sqlCommand.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(item));
            }

            return sqlCommand;
        }

        public static MySqlCommand GetProcedureQuery<T>(this T item, MySqlCommand mySqlCommand)
        {
            foreach (var prop in item.GetType().GetProperties())
            {
                if (prop.GetValue(item).IsNullOrDefault()) continue;
                mySqlCommand.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(item));
            }

            return mySqlCommand;
        }

        public static bool IsNullOrDefault<T>(this T argument)
        {
            // deal with normal scenarios
            if (argument == null)
            {
                return true;
            }
            if (object.Equals(argument, default(T)))
            {
                return true;
            }

            // deal with non-null nullables
            Type methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null)
            {
                return false;
            }

            // deal with boxed value types
            Type argumentType = argument.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                object obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }
    }
}