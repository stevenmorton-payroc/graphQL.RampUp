using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Services;
using HotChocolate.Subscriptions;

namespace GraphQL.API.GraphQL.Mutations;

public class UserMutation
{
    public async Task<ICreateUserResult> CreateUser(
        [Service] UserService userService,
        [Service] ITopicEventSender eventSender,
        string emailAddress,
        string firstName,
        string lastName)
    {
        ICreateUserResult createUserResult = userService.CreateUser(
            emailAddress,
            firstName,
            lastName);

        if (createUserResult is CreateUserSuccess createUserSuccess)
        {
            await eventSender.SendAsync(
                nameof(UserSubscription.OnUserCreated),
                createUserSuccess.User);
        }

        return createUserResult;
    }

    public async Task<IDeleteUserResult> DeleteUser(
        [Service] UserService userService,
        [Service] ITopicEventSender eventSender,
        Guid id)
    {
        IDeleteUserResult deleteUserResult = userService.DeleteUser(id);

        if (deleteUserResult is DeleteUserSuccess deleteSuccess)
        {
            await eventSender.SendAsync(
                nameof(UserSubscription.OnUserDeleted),
                deleteSuccess.Id);
        }

        return deleteUserResult;
    }
}
