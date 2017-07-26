# Create and configura a docker image to run the program
FROM microsoft/dotnet:latest
ADD . /app/
WORKDIR /app/
RUN dotnet restore
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/Divisors.dll", "input.txt"]