namespace YouTubeSummariser.WebApp.Configurations;

public class OpenAISettings
{
    public const string Name = "OpenAI";
    public string Endpoint { get; set; }
    public string ApiKey { get; set; }
    public string DeploymentId { get; set; }
}
