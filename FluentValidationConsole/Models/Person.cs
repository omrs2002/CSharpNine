namespace FluentValidationConsole.Models
{
    public class Person
    {

        public DateTime DateOfBirth { get; set; }
        

        //Collections:
        //Collections of Simple Types
        //You can use the RuleForEach method to apply the same rule to multiple items in a collection:
        public List<string> AddressLines { get; set; } = new List<string>();
        public string Surname { get; internal set; }
        public string Forename { get; internal set; }


        public IList<Pet> Pets { get; set; } = new List<Pet>();

    }

}
