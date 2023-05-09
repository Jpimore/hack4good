using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class AttachmentDto
    {


        public IFormFile? RequestFile { get; set; }
    }
}
