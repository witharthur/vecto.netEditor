using System;

namespace ImagePluginFramework.Plugins
{
    public interface IImageEffect
    {
        string Name { get; }
        string Parameter { get; set; }
        byte[] Apply(byte[] imageData);
    }

    public class GrayscaleEffect : IImageEffect
    {
        public string Name => "Grayscale";

        public string Parameter { get; set; } = string.Empty;

        public byte[] Apply(byte[] imageData)
        {
            // пока просто заглушка
            Console.WriteLine("Apply grayscale (dummy)");
            return imageData;
        }
    }
}
