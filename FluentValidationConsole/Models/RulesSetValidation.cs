using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationConsole.Models
{
    public class CutomerRuleValidator : AbstractValidator<Customer>
    {
        public CutomerRuleValidator()
        {
            RuleSet("Names", () =>
            {
                RuleFor(x => x.Surname).NotNull();
                RuleFor(x => x.Forename).NotNull();
            });

            RuleFor(x => x.Id).NotEqual(0);
        }
    }

}
