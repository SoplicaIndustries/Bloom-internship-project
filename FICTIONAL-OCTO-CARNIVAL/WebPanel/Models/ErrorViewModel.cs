namespace WebPanel.Models
{
    public class ErrorViewModel
    {
#pragma warning disable CS8632 // Adnotacja dla typów referencyjnych dopuszczaj¹cych wartoœæ null powinna byæ u¿ywana tylko w kodzie z kontekstem adnotacji „#nullable”.
        public string? RequestId { get; set; }
#pragma warning restore CS8632 // Adnotacja dla typów referencyjnych dopuszczaj¹cych wartoœæ null powinna byæ u¿ywana tylko w kodzie z kontekstem adnotacji „#nullable”.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}