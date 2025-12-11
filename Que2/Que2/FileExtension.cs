using System;
using System.Collections.Generic;

public class FileExtensionInfo
{
    private Dictionary<string, string> fileTypes;

    public FileExtensionInfo()
    {
        fileTypes = new Dictionary<string, string>()
        {
            { ".txt", "Plain Text File" },
            { ".pdf", "Adobe PDF Document" },
            { ".doc", "Microsoft Word Document" },
            { ".docx", "Microsoft Word Open XML Document" },
            { ".xls", "Microsoft Excel Spreadsheet" },
            { ".xlsx", "Excel Open XML Spreadsheet" },
            { ".ppt", "PowerPoint Presentation" },
            { ".pptx", "PowerPoint Open XML Presentation" },
            { ".jpg", "JPEG Image" },
            { ".jpeg", "JPEG Image" },
            { ".png", "Portable Network Graphics" },
            { ".gif", "Graphics Interchange Format" },
            { ".mp3", "MP3 Audio File" },
            { ".wav", "Waveform Audio File" },
            { ".mp4", "MPEG-4 Video File" },
            { ".mkv", "Matroska Video File" },
            { ".avi", "Audio Video Interleave File" },
            { ".mov", "Apple QuickTime Movie" },
            { ".webm", "WebM Video File" },
            { ".zip", "Compressed Archive File" },
            { ".rar", "WinRAR Compressed Archive" },
            { ".exe", "Windows Executable File" }
        };
    }

    public void GetInfo(string extension)
    {
        if (!extension.StartsWith("."))
        {
            Console.WriteLine("❌ Invalid input. Please enter a valid extension starting with a dot.");
            return;
        }

        if (fileTypes.ContainsKey(extension))
        {
            Console.WriteLine($"✔ {extension} → {fileTypes[extension]}");
        }
        else
        {
            Console.WriteLine($"⚠ Unknown extension: {extension}\nNo information available.");
        }
    }
}
