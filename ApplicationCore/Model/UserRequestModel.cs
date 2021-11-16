﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class UserRequestModel
    {
        public UserRequestModel()
        {
            JoinedOn = DateTime.Now;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
