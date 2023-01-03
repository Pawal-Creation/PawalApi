using System.Web;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

namespace PawalApi;

public class PawalRestfulApi:IPawalApi
{
    private IHttpClientFactory clientFactory_;

    private string url_;

    public PawalRestfulApi(IHttpClientFactory clientFactory)
    {
        this.clientFactory_ = clientFactory;
        this.url_ = "https://image.anosu.top/pixiv/direct?r18=1";
    }

    public async Task<byte[]> LookupImageAsync(string keyword)
    {
        keyword = HttpUtility.UrlEncode(keyword);
        StringBuilder builder = new StringBuilder();
        builder.Append(this.url_);
        if(keyword.Length != 0)
        {
            builder.Append("&keyword=");
            builder.Append(keyword);
        }
        string url = builder.ToString();
        HttpClient client = this.clientFactory_.CreateClient();
        var response = await client.GetAsync(url);
        if(response.StatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException($"Unexcepted status code {response.StatusCode}");
        }
        string contentType = (response.Content.Headers.ContentType is not null ? response.Content.Headers.ContentType.MediaType:string.Empty) ?? string.Empty;
        if(contentType.Length == 0 || !contentType.StartsWith("image"))
        {
            return new byte[0];
        }
        var image = await response.Content.ReadAsByteArrayAsync();
        return image;
    }
}