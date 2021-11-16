using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Income>> GetAllUserIncome(int userId)
        {
            return await _dbContext.Incomes.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<Income> GetIncome(int id)
        {
            return await _dbContext.Incomes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
