using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AppointmentTypeValidator : AbstractValidator<AppointmentType>
    {
        public AppointmentTypeValidator()
        {
            RuleFor(a => a.Type).NotEmpty();
            RuleFor(w => w.Type).MaximumLength(50);
        }
    }
}
