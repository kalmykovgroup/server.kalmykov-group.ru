using KalmykovGroup.Core;
using KalmykovGroup.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace KalmykovGroup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;


        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
          
        [HttpGet("page/{id}")]
        public async Task<IActionResult> Page(int id, AppDbContext appDbContext)
        { 

            List<Product> products = await appDbContext.Products
               .Include(p => p.Category)
               .Include(p => p.Rating)
               .Include(p => p.Unit)
               .Include(p => p.Img)
               .AsNoTracking()
               .ToListAsync();
 
            return Ok(products);
        }

        [HttpPost("addFile")]
        public async Task AddFile(IFormFile files)
        {

            var fileName = Path.GetFileName(files.FileName);
            var filePath = Path.Combine("C:\\test", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await files.CopyToAsync(fileSteam);
            }

        }
    }
}
