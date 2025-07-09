using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Domain.Entities
{
    public class SqlExecutionResult
    {
        public bool Success { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
    }
}
