namespace Lorby.Api.Extentions;

public class MethodExtention
{
    private readonly IWebHostEnvironment _env;
    public MethodExtention(IWebHostEnvironment webHostEnvironment)
    {
        _env = webHostEnvironment;
    }


    public async Task<string> AddPictureAndGetPath(IFormFile file)
    {
        string pathForSaveInComputer = Path.Combine( _env.WebRootPath, "images",  file.FileName);
        string pathForSaveInDatabase =Path.Combine("http://localhost:5000","images",  file.FileName);

        using (var stream = File.Create(pathForSaveInComputer))
        {
            await file.CopyToAsync(stream);
        }
        return pathForSaveInDatabase;
    }
}
