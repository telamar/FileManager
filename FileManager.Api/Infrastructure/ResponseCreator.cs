using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileManager.Api.Models;
using FileManager.Api.FileData.Abstracts;

namespace FileManager.Api.Infrastructure
{
    public static class ResponseCreator
    {
        public static FilesInfoResponseDTO CreateResponse(FilesInfoRequestDTO request, IUnitOfWork _filesData)
        {
            request.NextPath = InitializeNullableString(request.NextPath);
            FilesInfoResponseDTO response = new FilesInfoResponseDTO { CurrentPath = request.NextPath };
            response.FileNames = _filesData.FileManager.GetFiles(request.NextPath);
            response.DirectoryNames = _filesData.FileManager.GetSubDirectories(request.NextPath);
            return response;
        }

        private static string InitializeNullableString(string path)
        {
            if (path == null)
            {
                path = "";
            }
            return path;
        }
    }
}