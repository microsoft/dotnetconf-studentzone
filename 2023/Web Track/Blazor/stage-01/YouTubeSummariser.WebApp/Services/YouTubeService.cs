using Aliencube.YouTubeSubtitlesExtractor.Abstractions;

namespace YouTubeSummariser.WebApp.Services;

/// <summary>
/// This provides interfaces to the <see cref="YouTubeService"/> class.
/// </summary>
public interface IYouTubeService
{
    /// <summary>
    /// Gets the transcript from YouTube video.
    /// </summary>
    /// <param name="videoUrl">YouTube video URL.</param>
    /// <param name="languageCode">Language code of the transcript.</param>
    /// <returns>Returns the transcript.</returns>
    Task<string> GetTranscriptAsync(string videoUrl, string languageCode = "en");
}

/// <summary>
/// This represents the service entity for YouTube.
/// </summary>
public class YouTubeService : IYouTubeService
{
    private readonly IYouTubeVideo _youtube;

    /// <summary>
    /// Initializes a new instance of the <see cref="YouTubeService"/> class.
    /// </summary>
    /// <param name="youtube"><see cref="IYouTubeVideo"/> instance.</param>
    public YouTubeService(IYouTubeVideo youtube)
    {
        this._youtube = youtube ?? throw new ArgumentNullException(nameof(youtube));
    }

    /// <inheritdoc/>
    public async Task<string> GetTranscriptAsync(string videoUrl, string languageCode = "en")
    {
        var subtitle = await this._youtube
                                 .ExtractSubtitleAsync(videoUrl, languageCode)
                                 .ConfigureAwait(false);
        if (subtitle == null)
        {
            return string.Empty;
        }

        var transcript = subtitle.Content?
                                 .Select(p => p.Text)
                                 .Aggregate((a, b) => $"{a}\n{b}");

        return transcript ?? string.Empty;
    }
}
