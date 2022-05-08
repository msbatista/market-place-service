namespace WebApi.ViewModels.ValidationModels;

/// <summary>
/// Represents an object with the request errors details.
/// </summary>
public class ProblemDetailsModel
{
    /// <summary>
    /// Request http status.
    /// </summary>
    /// <value>int.</value>
    public int Status { get; set; }
    /// <summary>
    /// Error title.
    /// </summary>
    /// <value>string</value>
    public string? Title { get; set; }
    /// <summary>
    /// Error detail.
    /// </summary>
    /// <value>string.</value>
    public string? Detail { get; set; }
}
