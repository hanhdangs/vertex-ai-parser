namespace Vertex.Parser
{
    public class GeminiBaseRequest
    {
        public required string Prompt { get; set; }
        public required string FileMimeType { get; set; }
        public required FileStream FileData { get; set; }
    }
}
