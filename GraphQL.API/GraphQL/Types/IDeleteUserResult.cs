namespace GraphQL.API.GraphQL.Types;

[UnionType]
public interface IDeleteUserResult { }

public class DeleteUserSuccess(Guid id) : IDeleteUserResult
{
    public Guid Id { get; } = id;
}

public class DeleteUserError(string message, string code) : IDeleteUserResult
{
    public string Message { get; } = message;
    public string Code { get; } = code;
}
