using ImagePluginFramework.Models;

namespace ImagePluginFramework.Plugins
{
    public class BlurEffect : IImageEffect
    {
        public string Name => "Blur";

        public string Parameter { get; set; } = string.Empty;

        public byte[] Apply(byte[] input)
        {
            Console.WriteLine($"Applying {Name} with {Parameter}");
            return input;
        }
    }
}
