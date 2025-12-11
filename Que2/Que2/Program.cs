using System;

class Program
{
    static void Main(string[] args)
    {
        FileExtensionInfo infoSystem = new FileExtensionInfo();

        Console.WriteLine("==== FILE EXTENSION INFORMATION SYSTEM ====\n");

        while (true)
        {
            Console.Write("Enter a file extension (e.g., .mp4, .pdf, .txt) or 'exit' to quit: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "exit")
            {
                Console.WriteLine("\nExiting... Goodbye!");
                break;
            }

            infoSystem.GetInfo(input);
            Console.WriteLine(); // spacing
        }
    }
}
