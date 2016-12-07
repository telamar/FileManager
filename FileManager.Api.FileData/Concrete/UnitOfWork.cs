using FileManager.Api.FileData.Abstracts;

namespace FileManager.Api.FileData.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        IFileCounter _fileCounter;
        IFileManager _fileManager;

        public UnitOfWork()
        {
            _fileCounter = new FileCounter();
            _fileManager = new FileManager();
        }

        public IFileCounter FileCounter { get { return _fileCounter; } }

        public IFileManager FileManager { get { return _fileManager; } }
    }
}
