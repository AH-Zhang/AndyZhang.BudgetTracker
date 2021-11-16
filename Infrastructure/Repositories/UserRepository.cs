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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetUserByID(int id)
        {
            return await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
