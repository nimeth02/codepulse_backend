using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Domain.Constants
{
    public  class SecurityConstants
    {
        public static readonly string[] ForbiddenQuestionPatterns =
    {
        "delete", "remove", "erase", "drop", "clear",
        "update", "modify", "edit", "alter",
        "insert", "add", "create", "new",
        "exec", "execute", "run", "call", "procedure",
        "grant", "revoke", "permission", "role",
        "password", "credit card", "ssn", "secret"
    };

        public static readonly string[] ForbiddenSqlOperations =
        {
        "INSERT", "UPDATE", "DELETE", "CREATE", "ALTER", "DROP",
        "TRUNCATE", "EXEC", "EXECUTE", "CALL", "BEGIN", "COMMIT",
        "ROLLBACK", "GRANT", "REVOKE"
    };
        public static readonly string[] RestrictedTables =
{
        "UserCredentials", "SystemSettings", "AuditLogs"
    };

        public static readonly string[] RestrictedColumns =
        {
        "Password", "CreditCard", "SSN"
    };


    }
}
