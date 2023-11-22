using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.CQS.Queries
{
    public class QueryResult<T> : IQueryResult<T>
        where T : class
    {
        public static IQueryResult<T> Success(T result)
        {
            return new QueryResult<T>(true, result, null);
        }

        public static IQueryResult<T> Failure(string message)
        {
            return new QueryResult<T>(false, null, message);
        }

        public T? Result { get; init; }

        public bool IsSuccess { get; init; }

        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        public string? ErrorMessage {  get; init; }

        private QueryResult(bool isSuccess, T? result, string? errorMessage)
        {
            Result = result;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
