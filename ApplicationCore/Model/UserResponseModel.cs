using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class UserResponseModel
    {
        public UserResponseModel()
        {
            Incomes = new List<IncomeResponseModel>();
            Expenditures = new List<ExpenditureResponseModel>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime? JoinedOn { get; set; }

        public List<IncomeResponseModel> Incomes { get; set; }
        public List<ExpenditureResponseModel> Expenditures { get; set; }
    }
}
