using Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IS3Service
    {
        Task<AttachmentDto> InsertProfileToS3(string name, AttachmentDto data);
    }
}
