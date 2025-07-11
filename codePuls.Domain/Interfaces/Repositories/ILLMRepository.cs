using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codePuls.Domain.Interfaces.Repositories
{
    public interface ILLMRepository
    {
        Task<string> LLMCall(string question);
    }
}
