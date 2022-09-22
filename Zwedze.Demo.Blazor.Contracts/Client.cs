namespace Zwedze.Demo.Blazor.Contracts;

/// <summary>
///     A Client.
/// </summary>
public record Client
{
    public ClientId ClientId { get; set; }
    public string Name { get; init; }
    public Address Address { get; init; }
    public string Phone { get; set; }
}