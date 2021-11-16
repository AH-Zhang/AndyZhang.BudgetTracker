using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IIncomeRepository: IBaseRepository<Income>
    {
        Task<IEnumerable<Income>> GetAllUserIncome(int userId);
        Task<Income> GetIncome(int id);
    }
}
