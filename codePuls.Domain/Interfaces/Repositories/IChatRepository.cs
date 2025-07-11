using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codePuls.Domain.Entities;

namespace codePuls.Domain.Interfaces.Repositories
{
    public interface IChatRepository
    {
         string GetDatabaseSchema();
         Task<bool> ValidateQuestion(string question);
         SqlExecutionResult ExecuteSqlQuery(string sql);

         void ValidateSqlQuery(ChatState chatState);

         Task GenerateSqlQuery(ChatState chatState);

         Task ProcessResult(ChatState chatState);
    }
}
