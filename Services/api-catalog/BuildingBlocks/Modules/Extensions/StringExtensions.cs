using System.Text;

namespace BuildingBlocks.Modules.Extensions;

/// <summary>
/// StringExtensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Convert a string to byte array.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static byte[] AsByteArray(this string text)
    {
        return Encoding.ASCII.GetBytes(text);
    }
}
