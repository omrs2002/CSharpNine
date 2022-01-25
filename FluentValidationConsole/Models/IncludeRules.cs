using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationConsole.Models
{
    public class PersonAgeValidator : AbstractValidator<Person>
    {
        public PersonAgeValidator()
        {
            RuleFor(x => x.DateOfBirth).Must(BeOver18);
        }

        protected bool BeOver18(DateTime date)
        {
            return date.Year >=  DateTime.Today.Year - 18;
        }
    }

    public class PersonNameValidator : AbstractValidator<Person>
    {
        public PersonNameValidator()
        {
            RuleFor(x => x.Surname).NotNull().Length(0, 255);
            RuleFor(x => x.Forename).NotNull().Length(0, 255);
        }
    }


    public class PersonCValidator : AbstractValidator<Person>
    {
        public PersonCValidator()
        {
            Include(new PersonAgeValidator());
            Include(new PersonNameValidator());
        }
    }


}
