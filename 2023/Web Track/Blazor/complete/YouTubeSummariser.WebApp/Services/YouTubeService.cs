using Aliencube.YouTubeSubtitlesExtractor.Abstractions;

using Azure.AI.OpenAI;

using YouTubeSummariser.WebApp.Configurations;

namespace YouTubeSummariser.WebApp.Services;

public interface IYouTubeService
{
    string GetVideoId(string youtubeLink);
    Task<string> GetVideoSubtitleAsync(string videoId, string videoLanguageCode = "en");
    Task<string> GetVideoSummaryAsync(string subtitle, string summaryLanguageCode = "en");
}

public class YouTubeService : IYouTubeService
{
    private readonly IYouTubeVideo _youTubeVideo;
    private readonly OpenAIClient _openAIClient;
    private readonly OpenAISettings _openaiSettings;
    private readonly PromptSettings _promptSettings;

    public YouTubeService(IYouTubeVideo youTubeVideo, OpenAIClient openAIClient, OpenAISettings openaiSettings, PromptSettings promptSettings)
    {
        _youTubeVideo = youTubeVideo ?? throw new ArgumentNullException(nameof(youTubeVideo));
        _openAIClient = openAIClient ?? throw new ArgumentNullException(nameof(openAIClient));
        _openaiSettings = openaiSettings ?? throw new ArgumentNullException(nameof(openaiSettings));
        _promptSettings = promptSettings ?? throw new ArgumentNullException(nameof(promptSettings));
    }

    public string GetVideoId(string youtubeLink)
    {
        return _youTubeVideo.GetVideoId(youtubeLink);
    }

    public async Task<string> GetVideoSubtitleAsync(string youtubeLink, string videoLanguageCode = "en")
    {
        var subtitle = await _youTubeVideo.ExtractSubtitleAsync(youtubeLink, videoLanguageCode);
        var aggregated = subtitle.Content.Select(p => p.Text).Aggregate((a, b) => $"{a}\n{b}");
        return aggregated;
    }

    public async Task<string> GetVideoSummaryAsync(string subtitle, string summaryLanguageCode = "en")
    {
        var deploymentId = _openaiSettings.DeploymentId;
        var systemPrompt = _promptSettings.System;

        var options = new ChatCompletionsOptions
        {
            MaxTokens = _promptSettings.MaxTokens,
            Temperature = _promptSettings.Temperature,
            Messages =
            {
                new ChatMessage { Role = ChatRole.System, Content = systemPrompt},
                new ChatMessage { Role = ChatRole.System, Content = $"Here's the transcript. Summarise it in 5 bullet point items in the given language code of \"{summaryLanguageCode}\"."},
                new ChatMessage { Role = ChatRole.User, Content = subtitle},
            }
        };

        ChatCompletions completion = await _openAIClient.GetChatCompletionsAsync(deploymentId, options);

        return completion.Choices[0].Message.Content;
    }
}
