using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    //Dto içinde kullanılabilir.
    public class DailyRecordValidator : AbstractValidator<DailyRecord>
    {
        public DailyRecordValidator()
        {
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d => d.Surname).NotEmpty();
            RuleFor(d => d.Price).NotEmpty();
            RuleFor(d => d.Price).GreaterThan(0);
            RuleFor(d => d.Description).NotEmpty();

            //yanlış kural ama böyle de yazılabilir. To do. Değiştirilecek.
            //RuleFor(d => d.Price).NotEmpty().When(d => d.IsPaid == false);

        }
    }
}
