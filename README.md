# Black Ops 3 - Workshop to Local
A simple transfer script to move Steam Workshop content to local usermaps and mods. Written in Python (Universal) and C++ & Shell (for Linux).

## How to Use
NOTE: The universal Python script requires [Python](https://www.python.org/downloads/) to be installed.
1. Navigate to the **[Releases](https://github.com/RebelPolygon/CODW2L/releases/latest)** tab and download the script / binary for your respective platform
2. Place the script / pre-built binary in your Black Ops 3 root directory
3. Execute your respective script and enjoy!
4. (Optional) Prevent re-downloads by unsubscribing from workshop content post-transfer

## How to Build

NOTE: The universal Python script and shell script do not require compilation, and can be run as-is.
### The Python Script (Universal)
1. Download and install `pyinstaller` using pip.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the `src` folder in the project directory and execute the following command:
```
pyinstaller --onefile CODW2L.py
```
4. The built executable will be within a `dist` directory.

### The C++ Script (Linux)
1. Download and install the `gcc` package.
2. Clone the repository or download the source code from the "Code" tab.
3. Navigate to the `src` folder in the project directory and execute the following command:
```
g++ -o CODW2L linux.cpp
```
4. The built executable will be within the same directory as the .cpp file

## License

This project is licensed under [GPL v3.0](LICENSE)
