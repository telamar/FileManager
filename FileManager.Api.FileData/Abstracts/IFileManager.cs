using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Api.FileData.Abstracts
{
    public interface IFileManager
    {
        IEnumerable<string> GetFiles(string path);

        IEnumerable<string> GetSubDirectories(string path);
    }
}
