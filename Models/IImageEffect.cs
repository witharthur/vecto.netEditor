namespace ImagePluginFramework.Models
{
    public interface IImageEffect
    {
        string Name { get; }
        string Parameter { get; set; }
        Image Apply(Image input);
    }
}
