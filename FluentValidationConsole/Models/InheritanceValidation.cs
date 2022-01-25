using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationConsole.Models
{

    public interface IContact
    {
        string Name { get; set; }
        string Email { get; set; }
    }

    // A Person is a type of contact, with a name and a DOB.
    public class PersonA : IContact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }

    // An organisation is another type of contact,
    // with a name and the address of their HQ.
    public class Organisation : IContact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Address Headquarters { get; set; }
    }

    // Our model class that we'll be validating.
    // This might be a request to send a message to a contact.
    public class ContactRequest
    {
        public IContact Contact { get; set; }

        public string MessageToSend { get; set; }
    }


    public class PersonAValidator : AbstractValidator<PersonA>
    {
        public PersonAValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.DateOfBirth).GreaterThan(DateTime.MinValue);
        }
    }

    public class OrganisationValidator : AbstractValidator<Organisation>
    {
        public OrganisationValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Headquarters).SetValidator(new AddressValidator());
        }
    }

    public class ContactRequestValidator : AbstractValidator<ContactRequest>
    {
        public ContactRequestValidator()
        {

            RuleFor(x => x.Contact).SetInheritanceValidator(v =>
            {
                v.Add<Organisation>(new OrganisationValidator());
                v.Add<PersonA>(new PersonAValidator());
            });

        }
    }






}
