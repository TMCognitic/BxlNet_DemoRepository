using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Ado
{
    public static class DbConnectionExtensions
    {
        public static int ExecuteNonQuery(this DbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            EnsureValidConnection(connection);
            using (DbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static object? ExecuteScalar(this DbConnection connection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            EnsureValidConnection(connection);
            using (DbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                object? result = command.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this DbConnection connection, string query, Func<IDataRecord, TResult> mapper, bool isStoredProcedure = false, object? parameters = null)
        {
            EnsureValidConnection(connection);
            using (DbCommand command = CreateCommand(connection, query, isStoredProcedure, parameters))
            {
                using(DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return mapper(reader);
                    }
                }
            }
        }

        private static DbCommand CreateCommand(DbConnection connection, string query, bool isStoredProcedure, object? parameters)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;

            if (isStoredProcedure)
                command.CommandType = CommandType.StoredProcedure;

            if(parameters is not null)
            {
                Type type = parameters.GetType();

                foreach(PropertyInfo property in type.GetProperties().Where(p=> p.CanRead))
                {
                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = property.Name;
                    parameter.Value = property.GetValue(parameters) ?? DBNull.Value;

                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private static void EnsureValidConnection(DbConnection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);

            if (connection.State is not ConnectionState.Open)
                throw new InvalidOperationException("La connection doit être ouverte pour exécuter une requête...");
        }
    }
}
