using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public DateTime? JoinedOn { get; set; }

        public IEnumerable<Expenditure> Expenditures { get; set; }

        public IEnumerable<Income> Incomes { get; set; }
    }
}
