using Microsoft.AspNetCore.Http;

namespace MedWorking.Core.Common.Constants;

public static class FileStreamConvert
{
    public static async Task<byte[]> ConvertFileToStream(IFormFile files)
    {
        using (var memoryStream = new MemoryStream())
        {
            await files.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
