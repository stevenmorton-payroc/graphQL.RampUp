using GraphQL.API.Models;
using GraphQL.API.Services;

namespace GraphQL.API.GraphQL.Queries;

public class UserQuery
{
    public IEnumerable<User> GetUsers([Service] UserService userService)
        => userService.GetAllUsers();

    public User? GetUserById([Service] UserService userService, Guid id)
        => userService.GetUserById(id);
}
