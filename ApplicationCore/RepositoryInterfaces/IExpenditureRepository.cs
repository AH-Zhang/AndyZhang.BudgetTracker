using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IExpenditureRepository: IBaseRepository<Expenditure>
    {
        Task<IEnumerable<Expenditure>> GetAllUserExpenditure(int userId);
        Task<Expenditure> GetExpenditure(int id);
    }
}
