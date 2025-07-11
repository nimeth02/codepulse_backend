using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace codePuls.Infrastructure.Exeptions
{
    public static class DatabaseErrorHelper
    {

        public static bool IsTransientDatabaseError(Exception ex)
        {
            if (ex is SqlException sqlException)
            {
                // SQL Server specific transient errors
                var sqlTransientErrors = new[]
                {
            4060,  // Cannot open database
            40197, // The service has encountered an error
            40501, // The service is currently busy
            40613, // Database X is not currently available
            49918, // Cannot process request
            49919, // Cannot process create or update request
            49920, // Too many operations in progress
            11001  // Host not found
        };

                return sqlTransientErrors.Contains(sqlException.Number);
            }

            if (ex is TimeoutException)
            {
                return true; // Always treat timeouts as transient
            }

            if (ex is DbUpdateException dbUpdateEx)
            {
                // Recursively check inner exception
                return IsTransientDatabaseError(dbUpdateEx.InnerException);
            }

            return false;
        }
    }
}
