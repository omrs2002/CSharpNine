using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationConsole.Models.Validators
{

    public static class MyCustomValidators
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainMoreThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder
                .Must(list => list.Count > num)
                .WithMessage($"The list must contains {num} item at least!");


        }

        //using Custom message placeholders
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {

            return ruleBuilder
                .Must((rootObject, list, context) => {
                context.MessageFormatter
                  .AppendArgument("MaxElements", num)
                  .AppendArgument("TotalElements", list.Count);

                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items. The list contains {TotalElements} element");
        }

        public static IRuleBuilderOptionsConditions<T, IList<TElement>> ListMustBetweenXandY<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int min,int max)
        {

            return ruleBuilder
                .Custom((list, context) => {
                if (list.Count < min || list.Count > max)
                {
                    context.AddFailure($"The list must between {min} and {max}");
                }
            });
        }


    }

    public class PersonPetsValidator : AbstractValidator<Person>
    {
        public PersonPetsValidator()
        {
            //RuleFor(x => x.Pets).Must(list => list.Count > 1).WithMessage("The list must contain 1 item at least");
            RuleFor(x => x.Pets).ListMustContainMoreThan(5);
            RuleFor(x => x.Pets).ListMustContainFewerThan(10);
        }
        
        public PersonPetsValidator(int min,int max)
        {
            RuleFor(x => x.Pets).ListMustBetweenXandY(min,max);
        }
    }

}
