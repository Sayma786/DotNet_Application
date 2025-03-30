using Magna.Dexsys.FileHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Magna.Dexsys.FileHandler.Services;
public class FileSearchService
{
    public IReadOnlyList<FileDetails> FilesLocated => _filesLocated.AsReadOnly();

    private readonly List<FileDetails> _filesLocated = [];

    /// <summary>
    /// Populate the instance's FilesLocated member with a collection of
    /// files which contain the partialContent value anywhere in the 
    /// file.
    /// </summary>
    /// <param name="directory">Directory containing files to search</param>
    /// <param name="searchValue">Data to search for in files</param>
    /// <returns>Return the number of files located</returns>
    /// <exception cref="NotImplementedException"></exception>
    public int LocateFilesContainingSearchValue(string directory, string searchValue)
    {
        int matchCount = 0;

        if (!Directory.Exists(directory))
        {
            Console.WriteLine("Directory not found: " + directory);
            return 0;
        }

        var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
        Console.WriteLine($"Scanning {files.Length} file(s)...");

        foreach (var file in files)
        {
            try
            {
                // Read raw bytes
                byte[] bytes = File.ReadAllBytes(file);

                // Convert to string 
                string content = Encoding.UTF8.GetString(bytes);

                // null characters and garbage
                content = content.Replace("\0", "").Trim();

                if (!string.IsNullOrWhiteSpace(content))
                {
                    if (content.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string fileName = Path.GetFileName(file);
                        var details = new FileDetails(file, fileName, content.Length, content);
                        _filesLocated.Add(details);
                        matchCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Skipped] {file} - {ex.Message}");
            }
        }

        return matchCount;
    }



}
