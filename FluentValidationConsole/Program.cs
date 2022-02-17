// See https://aka.ms/new-console-template for more information
using FluentValidation;
using FluentValidation.Results;
using FluentValidationConsole.Models;
using FluentValidationConsole.Models.DependencyInjection;
using FluentValidationConsole.Models.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var host = new HostBuilder()
     .ConfigureServices(services =>
     {
         //services.AddScoped<IValidator<User>, UserValidator>();
         services.AddValidatorsFromAssemblyContaining<UserValidator>();
         services.AddTransient<IUserService, UserService>();
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

Console.WriteLine("IsValid", result.IsValid.ToString());

Console.WriteLine(result.ToString());
Console.WriteLine("//////////////////////////////////");
Console.WriteLine("Complex Properties");
//Validate Person


Person person = new Person
{
    AddressLines = new List<string> { "address 1", "" }
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


Console.WriteLine("//////////////////////////////////");
Console.WriteLine("Dependeny Validation");


var userService = host.Services.GetRequiredService<IUserService>();
var resu = userService.ValidateUser(new User { Id = 1, Name = "" });
Console.WriteLine(resu.Result);

Console.WriteLine("//////////////////////////////////");
Console.WriteLine("Custom Validation");
var _personPetsvalidator = new PersonPetsValidator();

var _personWithNoPets = new Person();
var cust_pets_result = _personPetsvalidator.Validate(_personWithNoPets);
Console.WriteLine(cust_pets_result.ToString());

_personPetsvalidator = new PersonPetsValidator(1,10);
cust_pets_result = _personPetsvalidator.Validate(_personWithNoPets);
Console.WriteLine(cust_pets_result.ToString());


Console.ReadKey();
