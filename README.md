# Black Ops III - Workshop to User
A simple conversion script to move Steam Workshop content to local usermaps and mods. Written in C# (for Windows) and Bash (for Linux).

## How to Use
Note: Whilst the windows script will work under `wine`, the bash script is recommended for Linux hosts.
1. Navigate to the **Releases** tab and download the binary for either Windows or Linux.
2. Place the pre-built binary in your Black Ops 3 root directory.
3. Run the script and enjoy!

## How to Build
### The C# Script (Windows)
1. Download and install [.NET](https://dotnet.microsoft.com/en-us/download) for your given Operating System.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the project directory and execute the following command:
```
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=true
```
4. The built executable can be found in the bin/Release/net6.0/win-x64/publish directory.

### The Bash Script (Linux)
1. Download and install the `shc` package.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the project directory and execute the following command:
```
shc -p linux_workshop-to-user.sh
```
4. This will leave you with two files, the prebuilt binary being the one ending with ".x"; Rename accordingly (if you so choose).


## License

GPL v3.0
