namespace WebAPI1_MSI.Models
{
    public record AccessTokenResponse
    {
        public string Token { get; init; }
        public DateTimeOffset ExpiresOn { get; init; }
    }
}
