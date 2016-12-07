namespace FileManager.Api.Models
{
    public class FilesQuantityResponseDTO
    {
        public string RequestPath { get; set; }

        public int QuantityFilesSizeLessThen { get; set; }

        public int QuantityFilesSizeBetween { get; set; }

        public int QuantityFilesSizeMoreThen { get; set; }
    }
}