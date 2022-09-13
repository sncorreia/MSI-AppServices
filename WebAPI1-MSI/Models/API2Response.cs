namespace WebAPI1_MSI.Models
{
    public record API2Response
    {
        public DateTime API2CreatedAt { get; init; }
        public string Description { get; init; }
        public int ComingFromAPI { get; init; }
    }
}
