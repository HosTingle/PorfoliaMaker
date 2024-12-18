﻿using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
   
            RuleFor(u=>u.FullName).NotEmpty();
            RuleFor(u=>u.FullName).MinimumLength(2);
            RuleFor(u=>u.Email).NotEmpty();
            RuleFor(u => u.Bio.Length).GreaterThanOrEqualTo(10).When(u => u.UserId == 1);
        }
       
    }
}
