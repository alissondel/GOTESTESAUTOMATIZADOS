﻿## Description

Projeto de exemplo utilizando Selenium WebDriver com C# para automacao de testes em navegadores web.

## Installation packages nuget
```bash
$ dotnet add package Selenium.WebDriver
$ dotnet add package Microsoft.Extensions.Configuration --version 10.0.2
$ dotnet add package Microsoft.Extensions.Configuration.Binder --version 10.0.2
$ dotnet add package Microsoft.Extensions.Configuration.Json --version 10.0.2
$ dotnet add package DotNetSeleniumExtras.WaitHelpers
```

# Execute os testes
```bash
$ dotnet test
# or
$ dotnet test --filter "Category=name_category"
```

## License

Project is [MIT licensed](LICENSE).
