﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.Surname).NotEmpty();
            RuleFor(e => e.PhoneNumber).NotEmpty();
            RuleFor(e => e.PhoneNumber).MaximumLength(11);
            RuleFor(e => e.PhoneNumber).MinimumLength(11);
            RuleFor(e => e.PhoneNumber).Must(StartWithPhone).WithMessage("0 ile başlamalısınız.");
        }

        private bool StartWithPhone(string arg)
        {
            return arg.StartsWith("0");
        }
    }
}
