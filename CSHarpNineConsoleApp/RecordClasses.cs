using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp
{
    //example of record classes
    public record Person(string FirstName, string LastName);

    //Positional records
    public record PositionalPerson(string FirstName, string LastName)
    {
        public string? MiddleName { get; init; }

        public PositionalPerson With(
                string? firstName = null,
                string? lastName = null,
                string? middleName = null)
        {
            return new PositionalPerson(
                firstName != null ? firstName : this.FirstName,
                lastName != null ? lastName : this.LastName)
            {
                MiddleName = middleName != null ? middleName : this.MiddleName
            };
        }


    }





}
