using FluentValidation;
using System.Threading.Tasks;

namespace FluentValidationConsole.Models.DependencyInjection
{

    public interface IUserService
{
        Task ValidateUser(User user);
    }

    public class UserService : IUserService
    {
        private readonly IValidator<User> _validator;

        public UserService(IValidator<User> validator)
        {
            _validator = validator;
        }

        public async Task ValidateUser(User user)
        {
            var validationResult = await _validator.ValidateAsync(user);
        }
    }

}
