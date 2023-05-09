using Api.DTOs;
using Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class S3Service : IS3Service
    {
        public S3Service()
        {

        }

        public async Task<AttachmentDto> InsertProfileToS3(string name, AttachmentDto data)
        {

            return new AttachmentDto();
        }
    }
}
