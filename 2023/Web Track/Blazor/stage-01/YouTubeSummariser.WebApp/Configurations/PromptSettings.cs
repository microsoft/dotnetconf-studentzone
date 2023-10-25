namespace YouTubeSummariser.WebApp.Configurations;

/// <summary>
/// This represents the settings entity for the prompt.
/// </summary>
public class PromptSettings
{
    /// <summary>
    /// Gets the name of the configuration.
    /// </summary>
    public const string Name = "Prompt";

    /// <summary>
    /// Gets or sets the system prompt.
    /// </summary>
    public virtual string? System { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of tokens to use for completion.
    /// </summary>
    public virtual int? MaxTokens { get; set; }

    /// <summary>
    /// Gets or sets the temperature of the completion.
    /// </summary>
    public virtual float? Temperature { get; set; }
}
