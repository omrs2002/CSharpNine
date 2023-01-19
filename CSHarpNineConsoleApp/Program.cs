//using static System.IO.File;
//using static System.Console;
//args = new string[] { "CSHarpNineConsoleApp.deps.json", "sadfasdf" };


//var text = await ReadAllTextAsync(args[0]);
//WriteLine(text);



using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSHarpNineConsoleApp.CorrectDIP;

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


            ////////////////////
            //use DIP:
            var emp = new EmployeeBusinessLogic();
            var res = emp.GetEmployeeDetails(1);
            Console.WriteLine(res.ToString());


            ////////////////////
            //use lymbda expression
            /*
             Func, Action, or Predicate delegates.
             1- The Func delegate takes zero, one or more input parameters, and returns a value (with its out parameter).
             2- Action takes zero, one or more input parameters, but does not return anything.
             3- Predicate is a special kind of Func. It represents a method that contains a set of criteria mostly defined inside an if condition and checks whether the passed parameter meets those criteria or not.
             */

            //public delegate TResult Func<int T, out TResult>(T arg);

            //zero input parameter & string return type
            Func<string> SomeMethodName = () => {  return "Func<string>"; };
            Console.WriteLine(SomeMethodName());
            //2 input parameter & int return type
            
            Func<int, int, int> getBigInteger = (x, y) => { if (x > y) return x; else return y; };
            Console.WriteLine(getBigInteger(10, 15));

            
            Action<int, int> getBigAction = (x, y) => { Console.WriteLine($"Deleg : {x} - {y}"); };
            getBigAction(1,3);

            //Func with an Anonymous Method:
            Func<int, int, int> Addition = delegate (int param1, int param2) {return param1 + param2;};
            int result = Addition(10, 20);
            Console.WriteLine($"Addition = {result}");

            //Func with Lambda Expression:
            Func<int, int, int> AdditionLym = (param1, param2) => param1 + param2;
            result = AdditionLym(10, 20);
            Console.WriteLine($"Addition = {result}");

            ////////////////////////////////////////////////////////////
            ///Actions:
            Action<int, int> Addition6 = AddNumbersAction;
            Addition(10, 20);
            Console.WriteLine($"Addition = {result}");

            ////////////////////////////////////////////////////////////
            ///Predicate delegate:
            ///Syntax difference between predicate & func is that here in predicate, 
            ///you don't specify a return type because it is always a bool.
            Predicate<string> CheckIfApple = IsApple;
            
            bool Apple_result = CheckIfApple("I Phone X");
            if (Apple_result)
                Console.WriteLine("It's an IPhone");

            //A predicate with Lambda expressions:
            Predicate<string> CheckIfApple2 = modelName => {
                if (modelName == "I Phone X") return true;
                else return false;
            };
            bool result_5 = CheckIfApple2("I Phone X");
            if (result_5)
                Console.WriteLine("It's an IPhone");
            ////////////////////////////////////////////////////////////
            ///Expression delegate:
            
            // A simple delegated operation which perform string join.  
            Func<string, string, string> StringJoin = (str1, str2) => string.Concat(str1, str2);
            StringJoin("123","456");

            //use lybda expression:
            Expression<Func<string, string, string>> StringJoinExpr = (str1, str2) => string.Concat(str1, str2);
            //get function from expression
            //Func<string, string, string> funX = StringJoinExpr.Compile();
            //get expression from function (return it back):
            //Expression<Func<string, string, string>> expression = Expression.Lambda<Func<string, string, string>>(Expression.Call(funX.Method));

            Console.WriteLine("Print 3D array:");
            UseArrays.Create3DArray();
            Console.Write("Again?(y):");
            var exit = Console.ReadKey();
            if (exit.KeyChar.ToString().ToUpper() == "Y")
                Main(args);
        }

        private static bool IsApple(string modelName)
        {
            if (modelName == "I Phone X")
                return true;
            else
                return false;
        }

        static int result;
            public static void AddNumbersAction(int param1, int param2) 
            {
                result = param1 + param2;
                Console.WriteLine(result);
            }




    }
}