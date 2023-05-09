using Api.DTOs;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
 
    [ApiController]
    [Route("api/S3")]

    public class AssetsController : ControllerBase
    {
        private readonly IS3Service _s3Service;

        public AssetsController(IS3Service s3Service)
        {
            _s3Service = s3Service ?? throw new ArgumentNullException(nameof(s3Service));
        }
        [ProducesResponseType(typeof(AttachmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AttachmentDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("Put data on S3")]
        [HttpPost("")]
       
        public async Task<ActionResult<AttachmentDto>> InsertProfileToS3(string name, AttachmentDto data)
        {
            AttachmentDto result = await _s3Service.InsertProfileToS3( "asdasd", new AttachmentDto());
            return result != null ? Ok(result) : (ActionResult<AttachmentDto>)NoContent();
        }


    }
}
