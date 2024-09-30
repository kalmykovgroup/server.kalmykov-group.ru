using KalmykovGroup.Core;
using Microsoft.AspNetCore.Mvc;

namespace KalmykovGroup.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SourceController : ControllerBase
    {

        [HttpGet("products/{id}/{token}/{name}")]
        public IActionResult fileProduct(string id, string token, string name)
        {
            string path = $"~/../Source/Img/Products/{id}/{token}/{name}";

            Console.WriteLine($"Запрос: products/{id}/{token}/{name}");

            try
            {
                if (System.IO.File.Exists(path))
                {
                    Byte[] b = System.IO.File.ReadAllBytes(path);   // You can use your own method over here.


                    return File(b, "image/webp");
                }
            }
            catch (Exception)
            {

            }


            return NotFound();

        }

        [HttpGet("advertisement/{token}/{name}")]
        public IActionResult fileAdvertisement(string token, string name)
        {
            string path = $"~/../Source/Img/Advertisement/{token}/{name}";
             

            try
            {
                if (System.IO.File.Exists(path))
                {
                    Byte[] b = System.IO.File.ReadAllBytes(path);   // You can use your own method over here.

                           
                    return File(b, $"image/jpeg");
                }
            }
            catch (Exception)
            {

            }


            return NotFound();

        }

    }
}
