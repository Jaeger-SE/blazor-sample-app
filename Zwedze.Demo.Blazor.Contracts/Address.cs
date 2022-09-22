namespace Zwedze.Demo.Blazor.Contracts;

/// <summary>
///     An Address.
/// </summary>
public record Address
{
    public string Country { get; init; }
    public string City { get; init; }

    /// <remarks>
    ///     Some post code may be: X-1030
    /// </remarks>
    public string PostCode { get; init; }

    public string Street { get; init; }

    /// <remarks>
    ///     Some house number may be: 14B
    /// </remarks>
    public string StreetNumber { get; init; }
}