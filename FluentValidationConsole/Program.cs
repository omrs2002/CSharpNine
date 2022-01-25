// See https://aka.ms/new-console-template for more information
using FluentValidation;
using FluentValidation.Results;
using FluentValidationConsole.Models;
using FluentValidationConsole.Models.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


var host = new HostBuilder()
     .ConfigureServices(services =>
     {
         var serviceProvider = services.BuildServiceProvider();
         services.AddTransient<IValidator<User>, UserValidator>();
         services.AddTransient<IUserService, UserService>();

         Console.WriteLine("//////////////////////////////////");
         Console.WriteLine("Dependeny Validation");

         if (serviceProvider != null)
         {
             var userService = serviceProvider.GetRequiredService<UserService>();
             var resu = userService.ValidateUser(new User { Id = 1, Name = "" });
         }

     })
     .Build();




Console.WriteLine("Hello, World!");


//test validator

Customer customer = new Customer()
{
    Address = new Address
    {
        County = "962"
    },
    Orders = new List<Order>()
    {
        new Order() { Total = 0},
        new Order() { Total = 5600}
    }
};
CustomerValidator validator = new CustomerValidator();

ValidationResult result = validator.Validate(customer);

Console.WriteLine("IsValid",result.IsValid.ToString());

Console.WriteLine(result.ToString());
Console.WriteLine("//////////////////////////////////");
Console.WriteLine("Complex Properties");
//Validate Person


Person person = new Person
{
    AddressLines = new List<string> { "address 1",""}
};
PersonValidator Pvalidator = new PersonValidator();
ValidationResult Presult = Pvalidator.Validate(person);

Console.WriteLine("Person Validation");
Console.WriteLine(Presult.ToString());
Console.WriteLine("//////////////////////////////////");
Console.WriteLine("Rules Validate");

var validatorR = new CutomerRuleValidator();
var _customer = new Customer();
var cus_result = validatorR.Validate(_customer, options => options.IncludeRuleSets("Names"));
Console.WriteLine(cus_result.ToString());







Console.ReadKey();
