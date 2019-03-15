using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Media.Imaging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleWebApp
{
    [Route("api/[controller]")]
    public class ImageIdentificationController : Controller
    {
        // POST api/ImageIdentification
        // returns the identification of what the image is
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<int> Post([FromBody]ImageDataModel imageDataModel)
        {
            Console.WriteLine(imageDataModel.ImageBase64Data);
            Console.WriteLine(imageDataModel.ImageType);
            
            return 1;
        }
    }
    public class ImageDataModel
    {
        public string ImageBase64Data { get; set; }
        public string ImageType { get; set; }
    }
}
