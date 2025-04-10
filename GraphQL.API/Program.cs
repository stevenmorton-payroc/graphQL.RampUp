using GraphQL.API.GraphQL.Mutations;
using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Subscriptions;
using GraphQL.API.GraphQL.Types;
using GraphQL.API.Repositories;
using GraphQL.API.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddSingleton<UserRepository>()
    .AddSingleton<UserService>();

services
    .AddGraphQLServer()
    .AddType<UserType>()
    .AddType<CreateUserSuccess>()
    .AddType<CreateUserError>()
    .AddType<DeleteUserSuccess>()
    .AddType<DeleteUserError>()
    .AddQueryType<UserQuery>()
    .AddMutationType<UserMutation>()
    .AddSubscriptionType<UserSubscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting()
   .UseWebSockets();

app.MapGraphQL();

app.Run();
