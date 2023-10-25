using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using YouTubeSummariser.WebApp.Services;

namespace YouTubeSummariser.WebApp.Components.UI;

public partial class YouTubeSummariserComponent : ComponentBase
{
    /// <summary>
    /// Gets or sets the <see cref="IYouTubeService"/> instance.
    /// </summary>
    [Inject]
    protected IYouTubeService? YouTube { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="IOpenAIService"/> instance.
    /// </summary>
    [Inject]
    protected IOpenAIService? OpenAI { get; set; }

    /// <summary>
    /// Gets or sets the YouTube link URL.
    /// </summary>
    protected string? YouTubeLinkUrl { get; set; }

    /// <summary>
    /// Gets or sets the video language code.
    /// </summary>
    protected string? VideoLanguageCode { get; set; } = "en";

    /// <summary>
    /// Gets or sets the summary language code.
    /// </summary>
    protected string? SummaryLanguageCode { get; set; } = "en";

    /// <summary>
    /// Gets or sets the summary.
    /// </summary>
    protected string? Summary { get; set; }

    /// <summary>
    /// Handles the event when the "Summarise!" button is clicked.
    /// </summary>
    /// <param name="ev"><see cref="MouseEventArgs"/> instance.</param>
    protected async Task CompleteAsync(MouseEventArgs ev)
    {
        if (string.IsNullOrWhiteSpace(this.YouTubeLinkUrl))
        {
            return;
        }

        this.Summary = default;

        var response = default(string);
        try
        {
            var transcript = await this.YouTube.GetTranscriptAsync(this.YouTubeLinkUrl, this.VideoLanguageCode);
            if (string.IsNullOrWhiteSpace(transcript) == true)
            {
                this.Summary = "The given YouTube video doesn't provide transcripts.";

                return;
            }

            response = await this.OpenAI.GetCompletionsAsync(transcript, this.SummaryLanguageCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            response = ex.Message;
        }

        this.Summary = response;
    }

    /// <summary>
    /// Handles the event when the "Clear!" button is clicked.
    /// </summary>
    /// <param name="ev"><see cref="MouseEventArgs"/> instance.</param>
    protected async Task ClearAsync(MouseEventArgs ev)
    {
        this.YouTubeLinkUrl = default;
        this.VideoLanguageCode = "en";
        this.SummaryLanguageCode = "en";
        this.Summary = default;

        await Task.CompletedTask;
    }
}
