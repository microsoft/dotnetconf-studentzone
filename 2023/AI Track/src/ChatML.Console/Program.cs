// See https://aka.ms/new-console-template for more information
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.TextEmbedding;

using Microsoft.SemanticKernel.Plugins.Memory;
using Microsoft.SemanticKernel.Connectors.Memory.Qdrant;

var AZURE_OPENAI_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
var AZURE_OPENAI_KEY = Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY");
var AZURE_OPENAI_EMBEDDING_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDING_DEPLOYMENT");
var AZURE_OPENAI_CHAT_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_DEPLOYMENT");
var QDRANT_HOST = Environment.GetEnvironmentVariable("QDRANT_HOST");

IKernel kernel = new KernelBuilder().WithAzureChatCompletionService(AZURE_OPENAI_CHAT_DEPLOYMENT, AZURE_OPENAI_ENDPOINT, AZURE_OPENAI_KEY).Build();
var pluginDirectory =  System.IO.Directory.GetCurrentDirectory() + "/Plugins";
var answerPlugin = kernel.ImportSemanticFunctionsFromDirectory(pluginDirectory,"AnswerPlugin");

var qdrantMemoryBuilder = new MemoryBuilder();
var textEmbedding = new AzureTextEmbeddingGeneration(AZURE_OPENAI_EMBEDDING_DEPLOYMENT, AZURE_OPENAI_ENDPOINT, AZURE_OPENAI_KEY);
qdrantMemoryBuilder.WithTextEmbeddingGeneration(textEmbedding);
qdrantMemoryBuilder.WithQdrantMemoryStore(QDRANT_HOST, 1536);

var builder = qdrantMemoryBuilder.Build();

string MemoryCollectionName = "kb_collection";

Console.WriteLine("Welcoment to ChatML Console! I am your ML assistant. Please ask me any question about ML and AI. If you want to exit, please type ctrl + c.");

while(true){

    Console.Write("Ask: ");
    String? question = Console.ReadLine();

    if (question == null )
    {
        Console.WriteLine("Bot : Please input a question.");
        return;
    }


    var searchResults =  builder.SearchAsync(MemoryCollectionName, question, limit: 1, minRelevanceScore: 0.8);
    await foreach (var item in searchResults)
    {
        var answer = await kernel.RunAsync(item.Metadata.Text, answerPlugin["Summary"]);
        Console.WriteLine("Bot: " + answer.ToString());
    }
}

