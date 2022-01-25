using FluentValidation;

namespace FluentValidationConsole.Models
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleForEach(x => x.AddressLines).NotNull().NotEmpty().WithMessage("Address {CollectionIndex} is required."); 
        }
    }

}
