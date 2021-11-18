using ApplicationCore.Entities;
using ApplicationCore.Model;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenditureRepository _expenditureRepository;

        public UserService(IUserRepository userRepository, IIncomeRepository incomeRepository, IExpenditureRepository expenditureRepository)
        {
            _userRepository = userRepository;
            _expenditureRepository = expenditureRepository;
            _incomeRepository = incomeRepository;
        }

        public async Task<bool> AddUser(UserRequestModel userRequestModel)
        {
            var user = await _userRepository.Add(new User
            {
                Email = userRequestModel.Email,
                Password = userRequestModel.Password,
                Fullname = userRequestModel.FullName,
                JoinedOn = userRequestModel.JoinedOn
            }) ;

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddExpenditure(ExpenditureRequestModel expenditureRequestModel)
        {
            var exp = await _expenditureRepository.Add(new Expenditure
            {
                UserId = expenditureRequestModel.UserId,
                Amount = expenditureRequestModel.Amount,
                Description = expenditureRequestModel.Description,
                ExpDate = expenditureRequestModel.ExpDate,
                Remarks = expenditureRequestModel.Remarks
            });

            if (exp == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddIncome(IncomeRequestModel incomeRequestModel)
        {
            var income = await _incomeRepository.Add(new Income
            {
                UserId = incomeRequestModel.UserId,
                Amount = incomeRequestModel.Amount,
                Description = incomeRequestModel.Description,
                IncomeDate = incomeRequestModel.IncomeDate,
                Remarks = incomeRequestModel.Remarks
            });

            if (income == null)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetUserByID(userId);
            await _userRepository.Delete(user);
        }

        public async Task DeleteExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.GetExpenditure(id);
            await _expenditureRepository.Delete(expenditure);
        }

        public async Task DeleteIncome(int id)
        {
            var income = await _incomeRepository.GetIncome(id);
            await _incomeRepository.Delete(income);
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures()
        {
            var expenditureResponseList = new List<ExpenditureResponseModel>();
            var expenditureList = await _expenditureRepository.ListAll();

            foreach (var expenditure in expenditureList)
            {
                expenditureResponseList.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return expenditureResponseList;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
        {
            var incomeResponseList = new List<IncomeResponseModel>();
            var incomeList = await _incomeRepository.ListAll();

            foreach (var income in incomeList)
            {
                incomeResponseList.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }

            return incomeResponseList;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var userResponseList = new List<UserResponseModel>();
            var userList = await _userRepository.ListAll();

            foreach (var user in userList)
            {
                userResponseList.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.Fullname,
                    JoinedOn = user.JoinedOn
                });
            }

            return userResponseList;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllUserExpenditures(int userId)
        {
            var expenditureResponseList = new List<ExpenditureResponseModel>();
            var expenditureList = await _expenditureRepository.GetAllUserExpenditure(userId);

            foreach (var expenditure in expenditureList)
            {
                expenditureResponseList.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return expenditureResponseList;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllUserIncomes(int userId)
        {
            var incomeResponseList = new List<IncomeResponseModel>();
            var incomeList = await _incomeRepository.GetAllUserIncome(userId);

            foreach (var income in incomeList)
            {
                incomeResponseList.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }

            return incomeResponseList;
        }

        public async Task<UserResponseModel> GetUser(int id)
        {
            var user = await _userRepository.GetUserByID(id);

            if (user == null)
            {
                return null;
            }

            var userResponse = new UserResponseModel
            {
                Email = user.Email,
                FullName = user.Fullname,
                JoinedOn = user.JoinedOn
            };

            foreach (var income in user.Incomes)
            {
                userResponse.Incomes.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                }) ;
            }

            foreach (var expenditure in user.Expenditures)
            {
                userResponse.Expenditures.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return userResponse;
        }

        public async Task UpdateUser(UserRequestModel userRequestModel, int userId)
        {
            var user = await _userRepository.GetUserByID(userId);
            user.Fullname = userRequestModel.FullName;
            user.Email = userRequestModel.Email;
            user.Password = userRequestModel.Password;

            await _userRepository.Update(user);
        }

        public async Task UpdateExpenditure(ExpenditureRequestModel expenditureRequestModel, int id)
        {
            var expenditure = await _expenditureRepository.GetExpenditure(id);
            expenditure.Amount = expenditureRequestModel.Amount;
            expenditure.Description = expenditureRequestModel.Description;
            expenditure.Remarks = expenditureRequestModel.Remarks;

            await _expenditureRepository.Update(expenditure);
        }

        public async Task UpdateIncome(IncomeRequestModel incomeRequestModel, int id)
        {
            var income = await _incomeRepository.GetIncome(id);
            income.Amount = incomeRequestModel.Amount;
            income.Description = incomeRequestModel.Description;
            income.Remarks = incomeRequestModel.Remarks;

            await _incomeRepository.Update(income);
        }
    }
}
