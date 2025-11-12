namespace TBC.PersonRegistry.Application.Commons.Extensions;

public static class IsValidImageExtension
{
    public static bool FileValidityCheck(this string fileName)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp" };
        var extension = Path.GetExtension(fileName)?.ToLowerInvariant();
        return !string.IsNullOrEmpty(extension) && allowedExtensions.Contains(extension);
    }
}
