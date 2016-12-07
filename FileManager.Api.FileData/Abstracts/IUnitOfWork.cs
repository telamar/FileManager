using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Api.FileData.Abstracts
{
    public interface IUnitOfWork
    {
        IFileCounter FileCounter { get; }

        IFileManager FileManager { get; }
    }
}
