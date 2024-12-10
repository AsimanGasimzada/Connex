using Microsoft.AspNetCore.Http;

namespace Connex.Business.Extensions;

public static class FileValidator
{
    public static bool ValidateSize(this IFormFile file, int mb)
    {
        return file.Length <= mb * 1024 * 1024;
    }

    public static bool ValidateType(this IFormFile file, string type = "image")
    {
        return file.ContentType.Contains(type);
    }

    public static async Task<string> FileCreateAsync(this IFormFile file, string path)
    {
        string filename = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf('.'));

        path = Path.Combine(path, filename);

        using (FileStream stream = new(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filename;
    }

    public static void DeleteFile(this string fileName, string path)
    {
        path = Path.Combine(path, fileName);

        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
