[![GitHub release](https://img.shields.io/github/release/FortnoxAB/csharp-api-sdk.svg)]() [![nuget](https://img.shields.io/nuget/v/Fortnox.NET.SDK.svg)](https://www.nuget.org/packages/Fortnox.NET.SDK/) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

<img src="https://raw.githubusercontent.com/FortnoxAB/csharp-api-sdk/master/Repository/fortnox2.jpg" style="width:150%;">

## Fortnox .NET SDK
Official .NET SDK package for developing integrations towards Fortnox REST API. Please note that this package is not totally aligned with the main API, however we are pretty close and will strive to keep up the pace. For more information please visit the official documentation <a href="https://developer.fortnox.se/documentation/">https://developer.fortnox.se/</a>.


## Get started
* Register as a <a href="https://developer.fortnox.se/" target="_blank">Fortnox Developer</a>
* Install nuget package Fortnox.NET.SDK
* Start coding

```CSharp
   var customerConnector = new CustomerConnector();
   var customer = new Customer();
   customer.CustomerNumber = "1";
   customer.Name = "Stefan Andersson";
   customerConnector.Create(customer);
```

```VB
   Dim customerConnector As New CustomerConnector()
   Dim customer As New Customer()
   customer.CustomerNumber = "1";
   customer.Name = "Stefan Andersson";
   customerConnector.Create(customer);
```


## Get help
* For help regarding this package and more code examples visit our <a href="https://github.com/FortnoxAB/csharp-api-sdk/wiki">wiki</a>.
* For help regarding the main API please visit https://developer.fortnox.se/
* For help regarding release information visit our <a href="https://github.com/FortnoxAB/csharp-api-sdk/releases">changelog</a>.
* For other help about our package please file a <a href="https://github.com/FortnoxAB/csharp-api-sdk/issues">issue</a>.



## Get licence

The MIT License (MIT)

Copyright (c) 2017 Fortnox AB, Jesper Svensson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
