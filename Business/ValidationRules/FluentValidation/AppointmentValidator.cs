using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();
            RuleFor(a => a.Surname).NotEmpty();
            RuleFor(a => a.Description).NotEmpty();
            RuleFor(a => a.Adress).NotEmpty();
            RuleFor(a => a.Price).NotEmpty();
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
