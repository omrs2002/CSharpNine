using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FluentValidationConsole.Models
{


    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname).NotNull().NotEqual("") ;
            RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
            

            RuleForEach(x => x.Orders).SetValidator(new OrderValidator());

        }



    }

}
