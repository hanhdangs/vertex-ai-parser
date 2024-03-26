using Google.Api.Gax.Grpc;
using Google.Cloud.AIPlatform.V1;
using Google.Protobuf;
using System.Text;


namespace Vertex.Parser
{
    public class GeminiQuickstart
    {
        private readonly string _projectId;
        private readonly string _location;
        private readonly string _publisher;
        private readonly string _model;
        public GeminiQuickstart(string projectId,
                                    string location = "asia-southeast1",
                                    string publisher = "google",
                                    string model = "gemini-1.0-pro-vision")
        {
            _projectId = projectId;
            _location = location;
            _publisher = publisher;
            _model = model;
        }

        public async Task<string> GenerateContent(GeminiBaseRequest request)
        {
            // Create client
            var predictionServiceClient = new PredictionServiceClientBuilder
            {
                Endpoint = $"{_location}-aiplatform.googleapis.com"
            }.Build();

            // Initialize request argument(s)
            var content = new Content
            {
                Role = "USER"
            };
            content.Parts.AddRange(
            [
                new() {
                    Text = request.Prompt
                },
                new() {
                    InlineData = new() {
                        MimeType = request.FileMimeType,
                        Data = ByteString.FromStream(request.FileData)
                    }
                }
            ]);

            var generateContentRequest = new GenerateContentRequest
            {
                Model = $"projects/{_projectId}/locations/{_location}/publishers/{_publisher}/models/{_model}",
                GenerationConfig = new GenerationConfig
                {
                    Temperature = 0.0f,
                    TopP = 1,
                    TopK = 32,
                    MaxOutputTokens = 2048
                }
            };
            generateContentRequest.Contents.Add(content);

            // Make the request, returning a streaming response
            using PredictionServiceClient.StreamGenerateContentStream response = predictionServiceClient.StreamGenerateContent(generateContentRequest);

            StringBuilder fullText = new();

            // Read streaming responses from server until complete
            AsyncResponseStream<GenerateContentResponse> responseStream = response.GetResponseStream();
            await foreach (GenerateContentResponse responseItem in responseStream)
            {
                if (responseItem.Candidates[0].Content.Parts.Count == 0)
                {
                    continue;
                }
                fullText.Append(responseItem.Candidates[0].Content.Parts[0].Text);
            }

            return fullText.ToString();
        }
    }
}