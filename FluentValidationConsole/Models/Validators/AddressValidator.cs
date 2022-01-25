using FluentValidation;

namespace FluentValidationConsole.Models
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Postcode).NotNull();
            //etc
        }
    }

}
