namespace WebPanel.Models
{
    public class ErrorViewModel
    {
#pragma warning disable CS8632 // Adnotacja dla typ�w referencyjnych dopuszczaj�cych warto�� null powinna by� u�ywana tylko w kodzie z kontekstem adnotacji �#nullable�.
        public string? RequestId { get; set; }
#pragma warning restore CS8632 // Adnotacja dla typ�w referencyjnych dopuszczaj�cych warto�� null powinna by� u�ywana tylko w kodzie z kontekstem adnotacji �#nullable�.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}