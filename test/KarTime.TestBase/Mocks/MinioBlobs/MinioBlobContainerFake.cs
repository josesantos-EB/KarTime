using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;

namespace KarTime.Mocks.MinioBlobs;

public class MinioBlobContainerFake<T> : IBlobContainer<T> where T : class
{
    public Task SaveAsync(string name, Stream stream, bool overrideExisting = false,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(true);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(true);
    }

    public Task<Stream> GetAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult<Stream>(new MemoryStream());
    }

    public Task<Stream?> GetOrNullAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult<Stream?>(null);
    }
}