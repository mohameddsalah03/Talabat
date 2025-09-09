namespace Talabat.Shared.Models
{
    public class StripeSettings
    {
        public string SecretKey { get; set; } = null!;
        public string PublisableKey { get; set; } = null!;
        public string WebhookSecret { get; set; } = null!;
    }
}
