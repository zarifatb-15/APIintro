namespace WebApplication1.Extensions;

public static class FileManager
{
    public static string SaveFile(this IFormFile file, string rootPath)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string path = Path.Combine(rootPath, fileName);
        using (var stream = new FileStream(path, FileMode.Create))
            file.CopyTo(stream); 
        return fileName;

    }
    public static bool IsImage(this IFormFile file)
    {

        return file.ContentType.Contains("image/");

    }
    public static bool IsValidSize(this IFormFile file, int maxInMb)
    {
        return file.Length <= maxInMb * 1024 * 1024;
    }
}
