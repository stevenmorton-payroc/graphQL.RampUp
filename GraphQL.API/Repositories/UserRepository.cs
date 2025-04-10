using System.Collections.Concurrent;
using GraphQL.API.Models;

namespace GraphQL.API.Repositories;

public class UserRepository
{
    public ConcurrentDictionary<Guid, User> UserStore { get; } = [];

    public IEnumerable<User> GetAllUsers()
    {
        return UserStore.Values;
    }

    public User? GetUserById(Guid id)
    {
        UserStore.TryGetValue(id, out var user);
        return user;
    }

    public User? CreateUser(User user)
    {
        user.Id = Guid.NewGuid();
        user.Created = DateTime.UtcNow;

        if (UserStore.TryAdd(user.Id, user))
        {
            return user;
        }

        return null;
    }

    public bool DeleteUser(Guid id)
    {
        return UserStore.TryRemove(id, out _);
    }
}
