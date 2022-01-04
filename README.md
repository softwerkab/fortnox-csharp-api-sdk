[![GitHub release](https://img.shields.io/github/release/FortnoxAB/csharp-api-sdk.svg)]() [![nuget](https://img.shields.io/nuget/v/Fortnox.NET.SDK.svg)](https://www.nuget.org/packages/Fortnox.NET.SDK/) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Fortnox .NET SDK
.NET SDK package for developing integrations towards Fortnox REST API. The package is developed and maintained by Softwerk AB.

For more information about the API, please visit the official documentation at <a href="https://developer.fortnox.se/documentation/">https://developer.fortnox.se/</a>.

## Get started
* Register as a <a href="https://developer.fortnox.se/" target="_blank">Fortnox developer</a>
* Install the NuGet package [Fortnox.NET.SDK](https://www.nuget.org/packages/Fortnox.NET.SDK/)
* Start coding

```csharp
var fortnoxAuthClient = new FortnoxAuthClient();
var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;
var tokenInfo = await authWorkflow.RefreshTokenAsync("your_refresh_token", "your_client_id", "your_client_secret");
var authorization = new StandardAuth(tokenInfo.AccessToken);
var client = new FortnoxClient(authorization);

var customer = new Customer()
{
    CustomerNumber = "1",
    Name = "Stefan Andersson"
};

customer = await client.CustomerConnector.CreateAsync(customer);
```

## Get help
* For help regarding this package and more code examples visit our <a href="https://github.com/FortnoxAB/csharp-api-sdk/wiki">wiki</a>.
* For help regarding the main API please visit https://developer.fortnox.se/
* For help regarding release information visit our <a href="https://github.com/FortnoxAB/csharp-api-sdk/releases">changelog</a>.
* For other help about our package please file an <a href="https://github.com/FortnoxAB/csharp-api-sdk/issues">issue</a>.
