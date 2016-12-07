using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileManager.Api.FileData.Abstracts;
using FileManager.Api.FileData.Entities;
using FileManager.Api.Models;

namespace FileManager.Api.Controllers
{
    public class FilesCounterController : ApiController
    {
        IUnitOfWork _unitOfWork;

        public FilesCounterController(IUnitOfWork fileData)
        {
            _unitOfWork = fileData;
        }

        public IHttpActionResult GetFilesQuantity([FromUri]string pathRequest = "")
        {
            QuantityFilesModel quantityFilesModel;

            if (pathRequest == null || pathRequest == "")
            {
                quantityFilesModel = _unitOfWork.FileCounter.GetFilesQuantity();
            }
            else
            {
                quantityFilesModel = _unitOfWork.FileCounter.GetFilesQuantity(pathRequest);
            }

            FilesQuantityResponseDTO response = new FilesQuantityResponseDTO
            {
                RequestPath = quantityFilesModel.RequestPath,
                QuantityFilesSizeBetween = quantityFilesModel.QuantityFilesSizeBetween,
                QuantityFilesSizeLessThen = quantityFilesModel.QuantityFilesSizeLessThen,
                QuantityFilesSizeMoreThen = quantityFilesModel.QuantityFilesSizeMoreThen
            };

            return Ok(response);
        }
    }
}
