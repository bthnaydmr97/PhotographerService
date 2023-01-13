using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    //Tek bir instances oluşturur ve tekrardan newlememiz için Static yaparız.
    //Bunu business katmanında her metot için kullanabiliriz Fakat Code Refactoring ile Universal core katmanına taşırız.
    //Bu şekilde toollar tek bir sefer instance oluşturulur. Uygulamam belleği hep bunu kullanır.
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
