using System.Text;

namespace BuildingBlocks.Modules.Extensions;

/// <summary>
/// ByteExtensions.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    /// Converst an byte array to string.
    /// </summary>
    /// <param name="blob"></param>
    /// <returns>string.</returns>
    public static string AsString(this byte[] blob)
    {
        return Encoding.Default.GetString(blob);
    }
}
