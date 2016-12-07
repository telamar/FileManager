using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FileManager.Api.FileData.Abstracts;
using FileManager.Api.Models;
using FileManager.Api.Infrastructure;
using System.IO;

namespace FileManager.Api.Controllers
{
    public class FilesController : ApiController
    {
        IUnitOfWork _unitOfWork;

        public FilesController(IUnitOfWork iuof)
        {
            _unitOfWork = iuof;
        }

        public IHttpActionResult GetFilesInfo([FromUri]FilesInfoRequestDTO filesInfoRequestDTO)
        {
            try
            {
                FilesInfoResponseDTO response = ResponseCreator.CreateResponse(filesInfoRequestDTO, _unitOfWork);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return BadRequest("NO_ACCESS_TO_THE_DISC");
            }
            catch (PathTooLongException)
            {
                return BadRequest("PATH_TO_LONG_FOR_FILE_SYSTEM");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
