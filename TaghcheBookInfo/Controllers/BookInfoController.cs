using BookinfoCommon.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace TaghcheBookInfo.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookInfoController:ControllerBase
    {
        private IBookInfoService bookInfoService { get; set; }
        public BookInfoController(IBookInfoService service) { 
        
            bookInfoService = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookInfoById(string id)
        {
            var book =await bookInfoService.GetBookById(id);
            if (book == null) { 
            
                return NotFound();
            }
            return Ok(book);
        }
    }

}
