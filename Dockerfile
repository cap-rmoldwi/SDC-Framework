
FROM microsoft/windowsservercore:10.0.14393.206 AS build
SHELL ["powershell"]

# Note: Get MSBuild 12.
RUN Invoke-WebRequest "https://download.microsoft.com/download/9/B/B/9BB1309E-1A8F-4A47-A6C5-ECF76672A3B3/BuildTools_Full.exe" -OutFile "$env:TEMP\BuildTools_Full.exe" -UseBasicParsing
RUN &  "$env:TEMP\BuildTools_Full.exe" /Silent /Full
# Todo: delete the BuildTools_Full.exe file in this layer

# Note: Add .NET + ASP.NET
RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45

# Note: Add NuGet
RUN Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile "C:\windows\nuget.exe" -UseBasicParsing
WORKDIR "C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0"

# Note: Install Web Targets
RUN &  "C:\windows\nuget.exe" Install MSBuild.Microsoft.VisualStudio.Web.targets -Version 12.0.4
RUN mv 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\MSBuild.Microsoft.VisualStudio.Web.targets.12.0.4\tools\VSToolsPath\*' 'C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\'
# Note: Add Msbuild to path
RUN setx PATH '%PATH%;C:\\Program Files (x86)\\MSBuild\\12.0\\Bin\\msbuild.exe'
CMD ["C:\\Program Files (x86)\\MSBuild\\12.0\\Bin\\msbuild.exe"]

# FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SDC.Schema/*.csproj ./
# COPY SDC.Schema/*.config ./
# RUN nuget restore
COPY SDC.Schema/. ./SDC.Schema/
WORKDIR /app/SDC.Schema
# RUN "C:\windows\nuget.exe" restore SDC.Schema.csproj
RUN 'C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe'
# RUN 'C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe' /p:Configuration=release  
#publish -c release -o /app *.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /inetpub/wwwroot
COPY --from=build /app ./SDC.Schema
# ENTRYPOINT ["dotnet", "SDC.Schema.dll"]
