

namespace ImagePluginFramework.Models;

using System.Collections.Generic;

public class Image
{
    // Properties
    public string Name { get; set; } = "";        // initialized to avoid CS8618
    public int Width { get; set; }
    public int Height { get; set; }
    public byte[] Data { get; set; } = Array.Empty<byte>(); // Image bytes
    public List<IImageEffect> Effects { get; private set; } = new();

    // Constructors
    public Image() { } // parameterless constructor

    public Image(string name, int width, int height)
    {
        Name = name;
        Width = width;
        Height = height;
    }

    public Image(string name, int width, int height, byte[] data)
    {
        Name = name;
        Width = width;
        Height = height;
        Data = data;
    }

    // Apply all effects stored in this image
    public void ApplyEffects()
    {
        foreach (var effect in Effects)
        {
            effect.Apply(this);
        }
    }

    // Add an effect to the list
    public void AddEffect(IImageEffect effect)
    {
        if (effect != null)
        {
            Effects.Add(effect);
        }
    }
}
