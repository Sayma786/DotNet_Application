## Setup

- Requires VS2022.
- Unzip the "generatedFiles.zip" folder so all contents are stored in "C:\temp\generatedFiles" (or unzip anywhere you want, change the path in the application to match)
  
## Assignment

- Search the 15,001 files in generatedFiles.zip for the string stored in the _searchValue constant in program.cs; The Program.cs portion must display the names of all the files that contain this string.

Note: The files found only need to be added to the _filesLocated field. The pre-written code will display that for you at the end. The number of files located should be returned by the LocateFilesContainingContent call.

## Solution Summary

- Implemented the `LocateFilesContainingSearchValue` method to:
  - Search all files in the target directory (including those without extensions).
  - Perform a case-insensitive search for the `_searchValue`.
  - Add matching files to the `_filesLocated` list.
  - Return the number of matches found.

- Updated `Program.cs` to:
  - Display matching file names.
  - Show the total time taken to complete the search.
  - Handle errors gracefully during execution.

## Output

- The application prints the following details to the console when executed:
  - Start of the search
  - Total number of files being scanned
  - Names of all files containing the search string
  - Number of matching files found
  - Total execution time in milliseconds

