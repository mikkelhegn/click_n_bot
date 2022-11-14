using Fermyon.Spin.Sdk;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;


namespace DotNetBot
{

    public static class Handler
    {
        [HttpHandler]
        public static HttpResponse HandleHttpRequest(HttpRequest request)
        {

            // https://github.com/fermyon/spin-dotnet-sdk#fast-startup-using-wizer
            if (request.Url == Warmup.DefaultWarmupUrl)
            {
                Console.WriteLine("/warmupz endpoint hit...");

                return new HttpResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "text/plain" },
                },
                    BodyAsString = "warmup",
                };
            };

            String slackCommand = request.Body.AsString();
            Console.WriteLine($"Request data: {slackCommand}");

            Dictionary<string, StringValues> slackSlashCommand = DeserializeForm(slackCommand);
            String UserName = slackSlashCommand.GetValueOrDefault("user_name");

            SlackSlashResponse response = new SlackSlashResponse()
            {
                Text = $"Hi {UserName}, this is your friendly dotnet bot 🤗.",
                ResponseType = ResponseType.InChannel
            };

            Console.WriteLine($"Response text: {response.Text}");

            return new HttpResponse
            {
                StatusCode = HttpStatusCode.OK,
                Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
            },
                BodyAsString = JsonSerializer.Serialize<SlackSlashResponse>(response),
            };
        }

        private static Dictionary<string, StringValues> DeserializeForm(string content)
        {
            using var reader = new FormReader(content);
            return reader.ReadForm();
        }

        private struct SlackSlashResponse
        {
            [JsonPropertyName("response_type")]
            public ResponseType ResponseType { get; set; }
            [JsonPropertyName("text")]
            public String Text { get; set; }
        }

        enum ResponseType
        {
            Ephemeral,
            InChannel,
        }
    }
}
