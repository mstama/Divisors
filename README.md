# Divisors

Common divisors of two numbers.
Sample solution showing elapsed time in different algorithms to find common divisors of two given numbers.

[![Build status](https://ci.appveyor.com/api/projects/status/p3y52hvfrhggk4uh?svg=true)](https://ci.appveyor.com/project/mstama/divisors)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/6abd987d2c014f178c5112ca7193b86f)](https://www.codacy.com/app/marcostamashiro/Divisors?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=mstama/Divisors&amp;utm_campaign=Badge_Grade)
[![Build Status](https://travis-ci.org/mstama/Divisors.svg?branch=master)](https://travis-ci.org/mstama/Divisors)
[SonarCloud](https://sonarcloud.io/dashboard/index/divisors-master)

### How to build

* [Install](https://www.microsoft.com/net/download/core#/current) .NET Core 1.1
* Restore the packages **(required once)**. In the solution folder, where **Divisors.sln** is, folder execute the followin command:

```terminal
dotnet restore
```

* In the project folder, where the **Divisors.csproj** is, execute the following command:

```terminal
dotnet build -c release
```

### How to run

* Running using the project file. In the project folder, where the **Divisors.csproj** is, execute the following command:

```terminal
dotnet run input.txt
```

* Running using the binary. Execute the following command with the binary file:

```terminal
dotnet Divisors.dll input.txt
```

### How to test

* Executing unit tests. In the unit tests project folder, where the **UnitTests.csproj** is, execute the following

```terminal
dotnet test
```

### Acknowledgements
ProgressConsole is built based on the following open source code:
[ASCII Console Progress Bar] (https://gist.github.com/DanielSWolf/0ab6a96899cc5377bf54#file-progressbar-cs)