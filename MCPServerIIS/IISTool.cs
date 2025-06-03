using Microsoft.Web.Administration;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace MCPServerIIS
{
    [McpServerToolType]
    public static class IISTool
    {
        [McpServerTool, Description("Echoes the message back to the client.")]
        public static string Echo(string message) => $"Hello {message} from MCP Server IIS";
        [McpServerTool, Description("Gets the list of IIS web server app pools")]
        public static string GetAppPools()
        {
            using (var serverManager = new ServerManager())
            {
                var appPools = serverManager.ApplicationPools
                    .Select(pool => new
                    {
                        pool.Name,
                        pool.State,
                        pool.ManagedRuntimeVersion,
                        pool.WorkerProcesses
                    })
                    .ToList();
                return JsonSerializer.Serialize(appPools);
            }
        }
        [McpServerTool, Description("Restart the IIS web server app pool")]
        public static string RecycleIISAppPool(string iisAppPoolName)
        {
            using (var serverManager = new ServerManager())
            {
                var appPool = serverManager.ApplicationPools.Where(pool => pool.Name == iisAppPoolName).FirstOrDefault();
                if(appPool == null)
                {
                    return $"App pool {iisAppPoolName} not found.";
                }
                var state =  appPool.Recycle();
                return $"App pool {iisAppPoolName} recycled and state is {state}";
            }
        }

        [McpServerTool, Description("Gets the list of IIS web server worker processes also known as w3wp")]
        public static string GetWorkerProcesses()
        {
            using (var serverManager = new ServerManager())
            {
                var appPools = serverManager.WorkerProcesses
                    .Select(pool => new
                    {
                        pool.ProcessId,
                        pool.AppPoolName,
                        pool.State
                    })
                    .ToList();
                return JsonSerializer.Serialize(appPools);
            }
        }
        [McpServerTool, Description("Gets the memory usage of a process in bytes")]
        public static long GetProcessMemory(string processId)
        {
            var process = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(processId));
            var memoryUsage = process.WorkingSet64;
            return memoryUsage;
        }
    }
}