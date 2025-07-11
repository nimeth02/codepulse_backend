using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Domain.Entities
{
    public class ChatState
    {
        public ChatState()
        {
            Result = new SqlExecutionResult();
            Validation= new ValidationResult();
        }
        public Guid ProjectId { get; set; }
        public string Question { get; set; }

        public string Schema { get; set; }

        public ValidationResult Validation { get; set; }

        public string Context { get; set; }

        public SqlExecutionResult Result { get; set; }

        public string Response { get; set; }

    }
}
