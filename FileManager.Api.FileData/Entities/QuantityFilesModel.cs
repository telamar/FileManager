namespace FileManager.Api.FileData.Entities
{
    public class QuantityFilesModel
    {
        public string RequestPath { get; set; }

        public int QuantityFilesSizeLessThen { get; set; }

        public int QuantityFilesSizeBetween { get; set; }

        public int QuantityFilesSizeMoreThen { get; set; }
    }
}
