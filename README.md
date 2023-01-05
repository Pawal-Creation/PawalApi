# PawalApi

涩图api

## 使用方法

与`Microsoft.Extensions.DependencyInjection`一起使用
```csharp

IServiceCollection services = new ServiceCollection();
services.AddAnosuApi();

IServiceProvider provider = services.BuildServiceProvider();
IPawalApi api = provider.GetRequiredService<IPawalApi>();

byte[] image = await api.LookupImageAsync(keyword);

if(image.Length == 0)
{
    //not found
}

```