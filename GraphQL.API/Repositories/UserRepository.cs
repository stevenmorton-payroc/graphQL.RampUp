using System.Collections.Concurrent;
using GraphQL.API.Models;

namespace GraphQL.API.Repositories;

public class UserRepository
{
    private readonly ConcurrentDictionary<Guid, User> _userStore = [];

    public IEnumerable<User> GetAllUsers()
    {
        return _userStore.Values;
    }

    public User? GetUserById(Guid id)
    {
        _userStore.TryGetValue(id, out var user);
        return user;
    }

    public User? CreateUser(User user)
    {
        user.Id = Guid.NewGuid();
        user.Created = DateTime.UtcNow;

        if (_userStore.TryAdd(user.Id, user))
        {
            return user;
        }

        return null;
    }

    public bool DeleteUser(Guid id)
    {
        return _userStore.TryRemove(id, out _);
    }
}
