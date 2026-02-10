// Ethan Wood - Section 2
// ErrorViewModel.cs - View model for the error page (displays request ID for debugging)

namespace Mission6_Wood.Models;

public class ErrorViewModel
{
    // Unique request identifier; shown on error page to help with debugging
    public string? RequestId { get; set; }

    // True when RequestId has a value, so the view can conditionally show the request ID section
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}