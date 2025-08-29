using ImagePluginFramework.Models;

namespace ImagePluginFramework.Plugins
{
    public class ResizeEffect : IImageEffect
    {
        public string Name => "Resize";   // теперь интерфейс реализован полностью

        public string Parameter { get; set; } = string.Empty;

        public byte[] Apply(byte[] input)
        {
            Console.WriteLine($"Applying {Name} with {Parameter}");
            return input;
        }
    }
}
