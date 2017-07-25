# Divisors
Common divisors

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

ASCII Console Progress Bar Code from: https://gist.github.com/DanielSWolf/0ab6a96899cc5377bf54#file-progressbar-cs