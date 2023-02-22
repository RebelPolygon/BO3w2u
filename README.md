# Black Ops 3 - Workshop to Local
A simple conversion script to move Steam Workshop content to local usermaps and mods. Written in C# (for Windows) and C++ & Bash (for Linux).

## How to Use
NOTE: For Linux users, whilst the windows script will work under `wine`, the native C++ is recommended.
1. Navigate to the **[Releases](https://github.com/RebelPolygon/CODW2L/releases/latest)** tab and download the binary for either Windows or Linux.
2. Place the pre-built binary in your Black Ops 3 root directory.
3. Execute and enjoy!

## How to Build
### The C# Script (Windows)
1. Download and install [.NET](https://dotnet.microsoft.com/en-us/download) for your given Operating System.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the project directory and execute the following command:
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
4. The built executable can be found in the bin/Release/net7.0/win-x64/publish directory.

### The C++ Script (Linux)
1. Download and install the `gcc` package.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the project directory and execute the following command:
```
g++ -o CODW2L linux.cpp
```
4. The build executable will be within the same directory as the .cpp file

## License

GPL v3.0
