using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Domain.Entities
{
    public class ValidationResult
    {
        public string? ValidatedQuery { get; set; }
        public string? ValidationMessage { get; set; }

        public bool Success { get; set; }
    }
}
