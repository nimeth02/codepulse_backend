using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codePuls.Domain.Interfaces;
using codePuls.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace codePuls.Infrastructure.Extensions
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ApplicationDbContext _context;

        public TransactionManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
