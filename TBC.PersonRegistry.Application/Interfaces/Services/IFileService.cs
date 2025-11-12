namespace TBC.PersonRegistry.Application.Interfaces.Services;

public interface IFileService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName);
}

