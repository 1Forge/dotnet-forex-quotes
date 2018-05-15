# dotnet-forex-quotes

dotnet-forex-quotes is a .NET library for fetching realtime forex quotes.
Any contributions or issues opened are greatly appreciated.

# Table of Contents
- [Requirements](#requirements)
- [Known Issues](#known-issues)
- [Installation](#installation)
- [Usage](#usage)
    - [List of Symbols available](#get-the-list-of-available-symbols)
    - [Get quotes for specific symbols](#get-quotes-for-specified-symbols)
    - [Convert from one currency to another](#convert-from-one-currency-to-another)
    - [Check if the market is open](#check-if-the-market-is-open)
- [Support / Contact](#support-and-contact)
- [License / Terms](#license-and-terms)

## Requirements
* An API key which you can obtain for free at http://1forge.com/forex-data-api

## Known Issues
Please see the list of known issues here: [Issues](https://github.com/1Forge/dotnet-forex-quotes/issues)

## Installation
Need to add to Nuget package manager.

## Usage

### Initialize the client
```c#
var client = new ForexDataClient("YOUR_API_KEY");
```

### Get the list of available symbols:
```c#
var symbols = client.GetSymbols();
foreach (var symbol in symbols)
{
    Console.WriteLine(symbol);
}
```

### Get quotes for specified symbols:
```c#
var quotes = client.GetQuotes(new string[] {"EURUSD", "GBPJPY", "BTCUSD"});
foreach (var quote in quotes)
{
    Console.WriteLine(quote);
}
```

### Convert from one currency to another:
```c#
var conversion = client.Convert("EUR", "USD", 100);
Console.WriteLine(conversion);
```

### Check if the market is open:
```c#
var marketStatus = client.GetMarketStatus();
if (marketStatus.marketIsOpen)
{
    Console.WriteLine("The market is open!");
}
else
{
    Console.WriteLine("The market is closed!");
}
```

### Quota used
```c#
var quota = client.GetQuota();
Console.WriteLine(quota);
```

```

## Support and Contact
Please contact me at contact@1forge.com if you have any questions or requests.

## License and Terms
This library is provided without warranty under the MIT license.