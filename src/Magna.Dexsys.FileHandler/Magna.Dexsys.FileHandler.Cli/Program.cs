using Magna.Dexsys.FileHandler.Models;
using Magna.Dexsys.FileHandler.Services;
using System;
using System.Diagnostics;

namespace Magna.Dexsys.FileHandler.Cli
{
    public class Program
    {
        private const string _fileLocation = "C:\\Users\\sayma\\Desktop\\generatedFiles";
        private const string _searchValue = "OLD"; 


        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting file search...");

                Stopwatch stopwatch = Stopwatch.StartNew();

                FileSearchService searchService = new();
                int matchCount = searchService.LocateFilesContainingSearchValue(_fileLocation, _searchValue);

                stopwatch.Stop();

                if (matchCount == 0)
                {
                    Console.WriteLine("No files found containing the search string.");
                }
                else
                {
                    Console.WriteLine($"Found {matchCount} file(s) containing \"{_searchValue}\":\n");

                    foreach (FileDetails item in searchService.FilesLocated)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                Console.WriteLine($"\nSearch completed in {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
