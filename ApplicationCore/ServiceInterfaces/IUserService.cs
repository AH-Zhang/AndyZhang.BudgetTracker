using ApplicationCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(UserRequestModel userRequestModel);
        Task UpdateUser(UserRequestModel userRequestModel, int userId);
        Task DeleteUser(int userId);
        Task<UserResponseModel> GetUser(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUsers();

        Task<bool> AddIncome(IncomeRequestModel incomeRequestModel);
        Task UpdateIncome(IncomeRequestModel incomeRequestModel, int id);
        Task DeleteIncome(int id);
        Task<IEnumerable<IncomeResponseModel>> GetAllUserIncomes(int userId);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomes();

        Task<bool> AddExpenditure(ExpenditureRequestModel expenditureRequestModel);
        Task UpdateExpenditure(ExpenditureRequestModel expenditureRequestMode, int id);
        Task DeleteExpenditure(int id);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllUserExpenditures(int userId);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures();

    }
}
