using Vertex.Parser;

// Replace <project_id> by your project id
var PROJECT_ID = "<project_id>";
var directory = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}examples{Path.DirectorySeparatorChar}" ;

var gemini = new GeminiQuickstart(PROJECT_ID);

// Extract data from pdf
Console.WriteLine("Extract data from PDF...");
var extractRequestPdf = new GeminiBaseRequest
{
    FileData = File.OpenRead($"{directory}agl-example.pdf"),
    FileMimeType = MimeType.Pdf,
    Prompt = "What's in the file"    
};
var extractedDataPdf = await gemini.GenerateContent(extractRequestPdf);
Console.WriteLine(extractedDataPdf);
Console.WriteLine("_____________________________");



// Extract data from 1st image
Console.WriteLine("Extract data from image 1...");
var extractRequestImg1 = new GeminiBaseRequest
{
    FileData = File.OpenRead($"{directory}agl-example-1.jpg"),
    FileMimeType = MimeType.Jpeg,
    Prompt = "What's in the file"
};
var extractedDataImg1 = await gemini.GenerateContent(extractRequestImg1);
Console.WriteLine(extractedDataImg1);
Console.WriteLine("_____________________________");



// Extract data from 2nd image
Console.WriteLine("Extract data from image 2...");
var extractRequestImg2 = new GeminiBaseRequest
{
    FileData = File.OpenRead($"{directory}agl-example-2.jpg"),
    FileMimeType = MimeType.Jpeg,
    Prompt = "What's in the file"
};
var extractedDataImg2 = await gemini.GenerateContent(extractRequestImg2);
Console.WriteLine(extractedDataImg2);
Console.WriteLine("_____________________________");



// Extract data from 3rd image
Console.WriteLine("Extract data from image 3...");
var extractRequestImg3 = new GeminiBaseRequest
{
    FileData = File.OpenRead($"{directory}agl-example-3.jpg"),
    FileMimeType = "image/jpeg",
    Prompt = "What's in the file"
};
var extractedDataImg3 = await gemini.GenerateContent(extractRequestImg3);
Console.WriteLine(extractedDataImg3);
Console.WriteLine("_____________________________");
