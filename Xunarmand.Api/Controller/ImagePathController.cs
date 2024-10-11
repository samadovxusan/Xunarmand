using Lorby.Api.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Xunarmand.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class ImagePathController (IWebHostEnvironment webHostEnvironment): ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> ImageUrl(IFormFile imageurl)
    {
        var Extention = new MethodExtention(webHostEnvironment);
        var picturepa = await Extention.AddPictureAndGetPath(imageurl);
        return Ok(picturepa);
    }
}