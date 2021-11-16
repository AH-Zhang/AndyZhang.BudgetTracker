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

    public class ExpenditureRepository : BaseRepository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Expenditure>> GetAllUserExpenditure(int userId)
        {
            return await _dbContext.Expenditures.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<Expenditure> GetExpenditure(int id)
        {
            return await _dbContext.Expenditures.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}
