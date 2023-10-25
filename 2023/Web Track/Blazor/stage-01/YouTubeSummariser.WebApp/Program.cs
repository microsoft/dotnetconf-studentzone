using Aliencube.YouTubeSubtitlesExtractor;
using Aliencube.YouTubeSubtitlesExtractor.Abstractions;

using Azure;
using Azure.AI.OpenAI;

using YouTubeSummariser.WebApp.Components;
using YouTubeSummariser.WebApp.Configurations;
using YouTubeSummariser.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var openAISettings = builder.Services.BuildServiceProvider()
                            .GetService<IConfiguration>()
                            .GetSection(OpenAISettings.Name)
                            .Get<OpenAISettings>();
builder.Services.AddSingleton(openAISettings);

var promptSettings = builder.Services.BuildServiceProvider()
                            .GetService<IConfiguration>()
                            .GetSection(PromptSettings.Name)
                            .Get<PromptSettings>();
builder.Services.AddSingleton(promptSettings);

var endpoint = new Uri(openAISettings.Endpoint);
var credential = new AzureKeyCredential(openAISettings.ApiKey);
var client = new OpenAIClient(endpoint, credential);
builder.Services.AddScoped<OpenAIClient>(_ => client);

builder.Services

    .AddScoped<IYouTubeService, YouTubeService>()
    .AddScoped<IOpenAIService, OpenAIService>()
    .AddScoped<IYouTubeVideo, YouTubeVideo>()
    .AddHttpClient()

    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
