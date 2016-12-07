using System.Collections.Generic;

namespace FileManager.Api.Models
{
    public class FilesInfoResponseDTO
    {
        public string CurrentPath { get; set; }

        public IEnumerable<string> FileNames { get; set; }

        public IEnumerable<string> DirectoryNames { get; set; }
    }
}