using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CR_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewController : ControllerBase
    {

        private readonly ILogger<InterviewController> _logger;

        public InterviewController(ILogger<InterviewController> logger)
        {
            _logger = logger;
        }
        //Obtener los datos
        [HttpGet]
        public Bitmap Get()
        {


            AmazonS3Client connect = new AmazonS3Client("", "", RegionEndpoint.GetBySystemName("eu-south-2"));
            GetObjectRequest getfile = new GetObjectRequest
            {
                Key = "Braisssssssssss.GIF",
                BucketName = "dev-crprofilesbucket"
            };
            Task <GetObjectResponse> fileGetResponse = connect.GetObjectAsync(getfile);
            Task.WhenAll(fileGetResponse);
                
            if (fileGetResponse.Result.HttpStatusCode.ToString() != "OK") return null;
            using (Stream stream = fileGetResponse.Result.ResponseStream)
            {
                StreamReader reader = new StreamReader(stream,Encoding.UTF8);
                Bitmap bmp = new Bitmap(Image.FromStream(stream, true, false));
                bmp.Save("brais.gif");
                return bmp;

            }
            
        }
        //enviar audio
        [HttpPost("{profilename}")]
        
        public  string UploadFileToS3(string profilename, [FromForm] AttachmentDto requestFile)
        {
            string responseString;
            AmazonS3Client connect = new AmazonS3Client("AKIAVFBRNYSXDYODIZ7N", "2qRA4i/f1GSXgpWNzl7oADmU1POCqvzb577/ipFZ", RegionEndpoint.GetBySystemName("eu-south-2"));


            MemoryStream target = new MemoryStream();  
            requestFile.RequestFile.OpenReadStream().CopyToAsync(target);
            try
            {
                PutObjectRequest request = new PutObjectRequest
                {
                    Key =requestFile.RequestFile.FileName +".wav",
                    BucketName = "dev-crprofilesbucket",
                    InputStream =  target
                };

                Task<PutObjectResponse>  response = connect.PutObjectAsync(request);
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
            return "";
        }

    }
}