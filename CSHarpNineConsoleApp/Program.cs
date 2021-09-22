//using static System.IO.File;
//using static System.Console;
//args = new string[] { "CSHarpNineConsoleApp.deps.json", "sadfasdf" };


//var text = await ReadAllTextAsync(args[0]);
//WriteLine(text);



using System;
using System.Collections.Generic;

namespace CSHarpNineConsoleApp
{
    public enum DurationUnit
    { Seconds, Minutes, Hours, Days, Unknown }


    class Program
    {
      

        static void Main(string[] args)
        {


            //01 - Init-only properties
            Student st = new()
            {StudentName = "Omar Abuhadid from record class"};
            st.PrintUserInfo();
            //////////////////////////////////

            //02- record:
            Person pp = new("Omar", "Abuhadid");
            

            Console.WriteLine($"{pp.FirstName} {pp.LastName} ");

            //using with
            var pers1 = pp with
            {
                FirstName = "Patrick"
            };

            //////////////////////////////////
            //03- positional record:
            PositionalPerson pp2 = new("Omar", "Abuhadid")
            {
                MiddleName = "Abd"
            };
            Console.WriteLine($"{pp.FirstName} {pp.LastName} ");
            (var FirstName2, var LastName2) = pp2;
            
            
            //////////////////////////////////
            //04- using with old way:
            //When invoking it, you could only specify the properties that you want to change:
            var modifiedPerson = pp2.With( middleName: "Patrick");

            

            Console.WriteLine($"{modifiedPerson.FirstName} {modifiedPerson.MiddleName} {modifiedPerson.LastName} ");
            //////////////////////////////////
            ///check value eq:
            //with normal class:
            var st1 = new Student { StudentName = "Omar" };
            var st2 = new Student { StudentName = "Omar" };
            var areEqual2 = st1.Equals(st2); // = false

            //record class:
            var person1 = new Person("John", "Doe");
            var person2 = new Person("John", "Doe");
            var areEqual = person1.Equals(person2); // = true


            /////////////////////////////
            //Pattern matching
            var duration = DateTime.Now.AddHours(2).Subtract(DateTime.Now);

            var unit = duration.TotalMinutes switch
            {
                //C# 8
                //double d when d < 1 => DurationUnit.Seconds,
                //double d when d < 60 => DurationUnit.Minutes,
                //double d when d < 24 * 60 => DurationUnit.Hours,
                //double d when d >= 24 * 60 => DurationUnit.Days,
                //_ => DurationUnit.Unknown

                //C# 9
                < 1 => DurationUnit.Seconds,
                < 60 => DurationUnit.Minutes,
                < 24 * 60 => DurationUnit.Hours,
                >= 24 * 60 => DurationUnit.Days,
                _ => DurationUnit.Unknown

            };
            int num1 = 0;
            int test = num1 switch
            {
                > 0 and < 10 => 1,
                 60 or 70 => 99,
                _ => 1
            };
            //////////////////////////////
            //Target-typed expressions:
            Person person = new("John", "Doe");
            var person3 = new Person("John", "Doe");
            var persons = new List<Person>() { new("John", "Doe"), new("Jane", "Doe") };
            var persons2 = new List<Person>() { person , person3 };

            //The second type of target - typed expressions is the target - typed conditional expression.
            //Its main benefit is that certain conditional expressions which required a cast before C# 9,
            //now simply work without it:
            // compiles in C# 9 only, doesn’t work in earlier versions
            var input = "asgasfg";
            int? length = string.IsNullOrEmpty(input) ? null : input.Length;


            //////////////////////////////
            //Liskove:
            Fruit fruit = new Orange();
            Console.WriteLine(fruit.GetColor());
            fruit = new Apple();
            Console.WriteLine(fruit.GetColor());


            Console.Write("Again?(y):");
            var exit = Console.ReadKey();
            if (exit.KeyChar.ToString().ToUpper() == "Y")
                Main(args);
        }
    }
}