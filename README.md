# MCP Server IIS
Model Context Protocol (MCP) Server for IIS web server management

# How to run
- Checkout source
- Compile and run either via Visual Studio or VS Code
	- `dotnet build`
	- `dotnet run`

# How to test
- Register the server into MCP hosts such as VS Code, [Claude Desktop](https://claude.ai/)
- Use the URL shown by `dotnet run` with `/sse` appended (e.g., `http://localhost:5000/sse`).

## Prerequisites

- Windows with IIS installed and configured
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio or Visual Studio Code


# Limitations
- Works only with local IIS. No remote support
- Limited capabilities as tool
- The transport used is SSE not the StdIO

# Tools & Technologies
- .NET 8 with C#
- Model Context Protocol (MCP)
- Nuget packages
	- ModelContextProtocol
	- Microsoft.Web.Administration
	- Microsoft.Extensions.Hosting
