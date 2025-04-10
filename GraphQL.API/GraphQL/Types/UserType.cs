using GraphQL.API.Models;

namespace GraphQL.API.GraphQL.Types;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
       descriptor.Ignore(u => u.Created);
    }
}
