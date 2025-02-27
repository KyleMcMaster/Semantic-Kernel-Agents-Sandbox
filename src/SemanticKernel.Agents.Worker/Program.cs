using Microsoft.SemanticKernel;
using Agents.Sandbox.Worker;

var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

// Create a kernel with OpenAI chat completion capabilities
string? apiKey = builder.Configuration.GetRequiredSection("OpenAISettings:Key").Value;
string? model = builder.Configuration.GetRequiredSection("OpenAISettings:Model").Value;
var kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(
        modelId: model!, // TODO: refactor to Options<T> pattern
        apiKey: apiKey!)
    .Build();
builder.Services.AddScoped(_ => kernel);

var host = builder.Build();
host.Run();
