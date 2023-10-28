namespace YouTubeSummariser.WebApp.Configurations;

public class PromptSettings
{
    public const string Name = "Prompt";
    public string System { get; set; }
    public int MaxTokens { get; set; }
    public float Temperature { get; set; }
}
