using System.Net.Http;
using System.Net.Http.Json;

namespace ImagePluginFramework.Models;

public class PluginManager
{
    private Dictionary<string, Type> _plugins = new();
    private readonly HttpClient _http;

    // Constructor receives HttpClient from DI
    public PluginManager(HttpClient http)
    {
        _http = http;
    }

    // Load plugins from wwwroot/pluginconfig.json
    public async Task LoadPluginsAsync()
    {
        var config = await _http.GetFromJsonAsync<PluginConfig>("pluginconfig.json");

        if (config == null) return;

        foreach (var plugin in config.AvailablePlugins)
        {
            var type = Type.GetType(plugin.Type);
            if (type != null && typeof(IImageEffect).IsAssignableFrom(type))
            {
                _plugins[plugin.Name] = type;
            }
        }
    }

    // Create an effect by name, passing optional parameter
    public IImageEffect? CreateEffect(string name, string parameter = "")
    {
        if (_plugins.TryGetValue(name, out var type))
        {
            // Create instance and pass parameter to constructor
            return (IImageEffect)Activator.CreateInstance(type, parameter)!;
        }
        return null;
    }
}

// Classes for JSON deserialization
public class PluginConfig
{
    public List<PluginItem> AvailablePlugins { get; set; } = new();
}

public class PluginItem
{
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";
}
