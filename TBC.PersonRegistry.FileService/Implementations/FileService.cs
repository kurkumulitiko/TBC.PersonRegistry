using TBC.PersonRegistry.Application.Interfaces.Services;


namespace TBC.PersonRegistry.FileService.Implementations;


public class FileService : IFileService
{
    private readonly string address;
    public FileService(string address)
    {
        this.address = address;
    }



    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        Directory.CreateDirectory(address);

        var filePath = Path.Combine(address, fileName);
        using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await fileStream.CopyToAsync(stream).ConfigureAwait(false);
        return filePath;
    }
}

