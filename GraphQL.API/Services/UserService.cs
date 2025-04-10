using GraphQL.API.GraphQL.Types;
using GraphQL.API.Models;
using GraphQL.API.Repositories;

namespace GraphQL.API.Services
{
    public class UserService(UserRepository userRepository)
    {
        public readonly UserRepository _repository = userRepository;

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public User? GetUserById(Guid id)
        {
            return _repository.GetUserById(id);
        }

        public ICreateUserResult CreateUser(
            string emailAddress,
            string firstName,
            string lastName)
        {
            User newUser = new()
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName
            };

            User? createdUser = _repository.CreateUser(newUser);

            if (createdUser is null)
            {
                return new CreateUserError(
                    "Failed to create user",
                    "USER_CREATE_FAIL");
            }

            return new CreateUserSuccess(createdUser);
        }

        public IDeleteUserResult DeleteUser(Guid id)
        {
            bool success = _repository.DeleteUser(id);

            if (!success)
            {
                return new DeleteUserError(
                    "Failed to delete user",
                    "USER_DELETE_FAIL");
            }

            return new DeleteUserSuccess(id);
        }
    }
}
