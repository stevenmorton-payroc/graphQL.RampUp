using GraphQL.API.Models;

namespace GraphQL.API.GraphQL.Subscriptions;

public class UserSubscription
{
    [Subscribe]
    [Topic]
    public User OnUserCreated([EventMessage] User newUser)
        => newUser;

    [Subscribe]
    [Topic]
    public Guid OnUserDeleted([EventMessage] Guid deletedUserId)
        => deletedUserId;
}
