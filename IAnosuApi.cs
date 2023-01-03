namespace AnosuApi;

public interface IAnosuApi
{
    public Task<byte[]> LookupImageAsync(string keyword);

    public byte[] LookupImage(string keyword)
    {
        Task<byte[]> imageTask = this.LookupImageAsync(keyword);
        imageTask.Wait();
        return imageTask.Result;
    }
}