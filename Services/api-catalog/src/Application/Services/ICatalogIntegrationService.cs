namespace Application.Services;

public interface IIntegrationServices
{
    Task<Stream> GetImageFromBlobStorage(string pictureName, string pictureUri);
}
