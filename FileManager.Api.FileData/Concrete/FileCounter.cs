using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Api.FileData.Abstracts;
using FileManager.Api.FileData.Entities;
using System.IO;

namespace FileManager.Api.FileData.Concrete
{
    public class FileCounter : IFileCounter
    {
        public QuantityFilesModel GetFilesQuantity()
        {
            IEnumerable<DriveInfo> allDrives = DriveInfo.GetDrives();
            List<QuantityFilesModel> quantityFilesModels = new List<QuantityFilesModel>();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    quantityFilesModels.Add(WalkDirectoryTree(drive.RootDirectory));
                }
            }

            QuantityFilesModel result = SumQuantityOnDrives(quantityFilesModels);

            result.RequestPath = "";
            return result;
        }
        
        public QuantityFilesModel GetFilesQuantity(string requestPath)
        {
            QuantityFilesModel quantityFilesModel = WalkDirectoryTree(new DirectoryInfo(requestPath));
            quantityFilesModel.RequestPath = requestPath;
            return quantityFilesModel;
        }

        private QuantityFilesModel SumQuantityOnDrives(List<QuantityFilesModel> quantities)
        {
            QuantityFilesModel result = new QuantityFilesModel { QuantityFilesSizeBetween = 0, QuantityFilesSizeLessThen = 0, QuantityFilesSizeMoreThen = 0 };
            foreach (var quantity in quantities)
            {
                result = SumTwoQuantities(result, quantity);
            }
            return result;
        }

        private QuantityFilesModel WalkDirectoryTree(DirectoryInfo root)
        {
            IEnumerable<FileInfo> files = null;
            IEnumerable<DirectoryInfo> subDirectories = null;
            QuantityFilesModel result = new QuantityFilesModel { QuantityFilesSizeMoreThen = 0, QuantityFilesSizeBetween = 0, QuantityFilesSizeLessThen = 0 };

            try
            {
                files = root.GetFiles();
            }
            catch(UnauthorizedAccessException e)
            {
                return result;
            }

            QuantityFilesModel quantityFilesInThisDir = null;

            if (files.Count() != 0 && files != null)
            {
                quantityFilesInThisDir = CountFiles(files);
                result = SumTwoQuantities(result, quantityFilesInThisDir);
            }

            subDirectories = root.GetDirectories();

            if (subDirectories != null && subDirectories.Count() != 0)
            {
                foreach (DirectoryInfo dir in subDirectories)
                {
                    result = SumTwoQuantities(result, WalkDirectoryTree(dir));
                }
            }
          
            return result;
        }

        private QuantityFilesModel SumTwoQuantities(QuantityFilesModel result, QuantityFilesModel quantity)
        {
            result.QuantityFilesSizeMoreThen += quantity.QuantityFilesSizeMoreThen;
            result.QuantityFilesSizeBetween += quantity.QuantityFilesSizeBetween;
            result.QuantityFilesSizeLessThen += quantity.QuantityFilesSizeLessThen;
            return result;
        }

        private QuantityFilesModel CountFiles(IEnumerable<FileInfo> files)
        {
            QuantityFilesModel result = new QuantityFilesModel { QuantityFilesSizeMoreThen = 0, QuantityFilesSizeBetween = 0, QuantityFilesSizeLessThen = 0};
            foreach(FileInfo file in files)
            {
                if (file.Length > 0 && file.Length <= 10 * 1024 * 1024)
                {
                    result.QuantityFilesSizeLessThen += 1;
                }
                else
                {
                    if (file.Length <= 50 * 1024 * 1024)
                    {
                        result.QuantityFilesSizeBetween += 1;
                    }
                    else
                    {
                        if (file.Length >= 100 * 1024 * 1024)
                        {
                            result.QuantityFilesSizeMoreThen += 1;
                        }
                    }
                }
            }
            return result;
        }
    }
}
