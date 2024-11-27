using IronOcr;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Starting OCR process...");

        // Manually change the image you want to use for now
        string imagePath = @"C:\Users\tamago\Desktop\bread\lanFile\kuzushiShita.jpg";

        try
        {
            Console.WriteLine("Checking file path: " + imagePath);

            // Verify the file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Error: Image file not found!");
                return;
            }
            Console.WriteLine("Image file found!");

            // Test file access
            using (var stream = File.OpenRead(imagePath))
            {
                Console.WriteLine("File is accessible.");
            }

            // Initialize OCR
            IronTesseract ocr = new();
            ocr.Language = OcrLanguage.Japanese;
            ocr.AddSecondaryLanguage(OcrLanguage.English);

            // Create and load image into OCR
            var input = new OcrInput();
            input.LoadImage(imagePath);
            Console.WriteLine("Image loaded successfully.");

            // Perform OCR
            var result = ocr.Read(input);
            Console.WriteLine("OCR processing complete.");

            // Write OCR result to file
            string outputPath = @"C:\Users\tamago\Desktop\bread\resultFile\result.txt";
            File.WriteAllText(outputPath, result.Text);
            Console.WriteLine("Text file created successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
