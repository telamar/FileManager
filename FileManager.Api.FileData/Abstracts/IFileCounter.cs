using FileManager.Api.FileData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Api.FileData.Abstracts
{
    public interface IFileCounter
    {
        QuantityFilesModel GetFilesQuantity();

        QuantityFilesModel GetFilesQuantity(string requestPath);
    }
}
