using codePuls.Application.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace codePuls.Infrastructure.Exeptions
{
    public static class RepositoryExceptionFactory
    {
        public static RepositoryException Create(string operation, Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                return new RepositoryException("SQL error", sqlEx)
                {
                    Operation = operation,
                    IsTransient = DatabaseErrorHelper.IsTransientDatabaseError(sqlEx),
                    ErrorCode = sqlEx.Number.ToString(),
                    ErrorType = "SqlException"
                };
            }

            if (ex is TimeoutException timeoutEx)
            {
                return new RepositoryException("Timeout occurred", timeoutEx)
                {
                    Operation = operation,
                    IsTransient = true,
                    ErrorCode = "Timeout",
                    ErrorType = "TimeoutException"
                };
            }

            if (ex is DbUpdateException dbUpdateEx)
            {
                return new RepositoryException("Database update error", dbUpdateEx)
                {
                    Operation = operation,
                    IsTransient = DatabaseErrorHelper.IsTransientDatabaseError(dbUpdateEx),
                    ErrorCode = dbUpdateEx.HResult.ToString(),
                    ErrorType = "DbUpdateException"
                };
            }

            return new RepositoryException("Unexpected database error", ex)
            {
                Operation = operation,
                IsTransient = false,
                ErrorCode = ex.HResult.ToString(),
                ErrorType = ex.GetType().Name
            };
        }
    }

}
