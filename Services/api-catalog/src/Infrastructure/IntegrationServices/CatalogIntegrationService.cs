using Application.Services;

namespace Infrastructure.IntegrationServices;

public sealed class CatalogIntegrationService : IIntegrationServices
{
    public Task<Stream> GetImageFromBlobStorage(string pictureName, string pictureUri)
    {
        throw new NotImplementedException();
    }
}
