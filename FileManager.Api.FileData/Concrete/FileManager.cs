using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Api.FileData.Abstracts;
using System.IO;

namespace FileManager.Api.FileData.Concrete
{
    public class FileManager: IFileManager
    {
        public IEnumerable<string> GetFiles(string path)
        {
            if (path != null && path != "")
            {
                return Directory.GetFiles(path);
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }

        public IEnumerable<string> GetSubDirectories(string path)
        {
            if (path != null && path != "")
            {
                return Directory.GetDirectories(path);
            }
            else
            {
                return GetDrivers();
            }
        }

        private IEnumerable<string> GetDrivers()
        {
            List<string> result = new List<string>();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                    result.Add(drive.Name);
            }
            return result;
        }
    }
}
