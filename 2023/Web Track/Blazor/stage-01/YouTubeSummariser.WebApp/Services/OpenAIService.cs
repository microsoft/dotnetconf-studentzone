using Azure.AI.OpenAI;

using YouTubeSummariser.WebApp.Configurations;

namespace YouTubeSummariser.WebApp.Services;

/// <summary>
/// This provides interfaces to the <see cref="OpenAIService"/> class.
/// </summary>
public interface IOpenAIService
{
    /// <summary>
    /// Gets the completion from OpenAI.
    /// </summary>
    /// <param name="prompt">Prompt value.</param>
    /// <param name="languageCode">Language code for the cue.</param>
    /// <returns>Returns the completion.</returns>
    Task<string> GetCompletionsAsync(string prompt, string languageCode = "en");
}

/// <summary>
/// This represents the service entity for OpenAI.
/// </summary>
public class OpenAIService : IOpenAIService
{
    private readonly OpenAISettings _openAISettings;
    private readonly PromptSettings _promptSettings;
    private readonly OpenAIClient _openai;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAIService"/> class.
    /// </summary>
    /// <param name="openAISettings"><see cref="OpenAISettings"/> instance.</param>
    /// <param name="promptSettings"><see cref="PromptSettings"/> instance.</param>
    /// <param name="openai"><see cref="OpenAIClient"/> instance.</param>
    public OpenAIService(OpenAISettings openAISettings, PromptSettings promptSettings, OpenAIClient openai)
    {
        this._openAISettings = openAISettings ?? throw new ArgumentNullException(nameof(openAISettings));
        this._promptSettings = promptSettings ?? throw new ArgumentNullException(nameof(promptSettings));
        this._openai = openai ?? throw new ArgumentNullException(nameof(openai));
    }

    /// <inheritdoc/>
    public async Task<string> GetCompletionsAsync(string prompt, string languageCode = "en")
    {
        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatMessage(ChatRole.System, this._promptSettings.System),
                    new ChatMessage(ChatRole.System, $"Here's the transcript. Summarise it in 5 bullet point items in the given language code of \"{languageCode}\"."),
                    new ChatMessage(ChatRole.User, prompt),
                },
            MaxTokens = this._promptSettings.MaxTokens,
            Temperature = this._promptSettings.Temperature,
        };

        var deploymentId = this._openAISettings.DeploymentId;

        var completion = default(string);
        try
        {
            var result = await this._openai
                                   .GetChatCompletionsAsync(deploymentId, chatCompletionsOptions)
                                   .ConfigureAwait(false);
            completion = result.Value.Choices[0].Message.Content;
        }
        catch
        {
            throw;
        }

        return completion;
    }
}
