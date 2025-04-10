using GraphQL.API.Models;

namespace GraphQL.API.GraphQL.Types;

[UnionType]
public interface ICreateUserResult { }

public class CreateUserSuccess(User user) : ICreateUserResult
{
    public User User { get; } = user;
}

public class CreateUserError(string message, string code) : ICreateUserResult
{
    public string Message { get; } = message;
    public string Code { get; } = code;
}