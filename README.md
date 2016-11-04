# Yekssim
The simplest .NET Misskey Liblary

## Install
Available on NuGet

```
PM> Install-Package Yekssim
```

## Usage

### Authorizing
```csharp
var session = await new MisskeyAuth("app_secret").Authorize();
session.OpenAuthPageInDefaultBrowser(); // or string uri = session.AuthPageUri
var token = await session.GetToken();
```

### Posting
```csharp
token.Request("posts/create", new Dictionary<string, string> {
    { "text", "Hello!" }
})
```
