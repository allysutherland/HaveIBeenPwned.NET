# HaveIBeenPwned.NET
A .NET Standard client for haveibeenpwned.com RESTful API. For full description of the haveibeenpwned API, please see [API Documentation](https://haveibeenpwned.com/api/v2).

This project targets [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/library)

## Platform support

|Platform|Version|
| ------------------- | :----------:|
|.NET Standard|2.0|

## Nuget Package
  PM> Install-Package HaveIBeenPwned.NET

## Usage

For full examples please see the HaveIBeenPwnedClientUnitTest project.

#### Password Breaches

```c#
using HaveIBeenPwned.Client;

IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();
bool isPwnedPassword = await client.IsPasswordPwned("password123");

Console.WriteLine(isPwnedPassword);
```

#### Paste Accounts

```c#
using HaveIBeenPwned.Client;
using HaveIBeenPwned.Model;

IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();
List<Paste> pastes = await client.GetPasteAccount("test@test.com");

foreach (Paste paste in pastes) {
    Console.WriteLine(paste.Title);    
    Console.WriteLine(paste.Source);
}
```

#### Get All Breached Sites Details

```c#
using HaveIBeenPwned.Client;
using HaveIBeenPwned.Model;

IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();
List<Breach> breaches = await client.GetAllBreaches();

foreach (Breach breach in breaches) {
    Console.WriteLine(breach.Name);    
    Console.WriteLine(breach.Description);
}
```

#### Get a Single Breached Site

```c#
using HaveIBeenPwned.Client;
using HaveIBeenPwned.Model;

IHaveIBeenPwnedClient client = new HaveIBeenPwnedClient();
Breach breach = await client.GetBreach("Adobe");

Console.WriteLine(breach.Name);
Console.WriteLine(breach.Description);
```

## License
The MIT License (MIT) see [License file](LICENSE)
