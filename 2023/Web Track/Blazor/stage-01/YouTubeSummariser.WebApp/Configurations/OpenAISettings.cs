namespace YouTubeSummariser.WebApp.Configurations;

/// <summary>
/// This represents the settings entity for the OpenAI API.
/// </summary>
public class OpenAISettings
{
    /// <summary>
    /// Gets the name of the configuration.
    /// </summary>
    public const string Name = "OpenAI";

    /// <summary>
    /// Gets or sets the API endpoint.
    /// </summary>
    public virtual string? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the API key.
    /// </summary>
    public virtual string? ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the model deployment ID.
    /// </summary>
    public virtual string? DeploymentId { get; set; }
}
