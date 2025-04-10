namespace GraphQL.API.Models;

public class User
{
    public Guid Id { get; set; }
    public required string EmailAddress { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Created {  get; set; }
}
