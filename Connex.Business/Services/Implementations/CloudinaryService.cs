using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Connex.Business.Services.Implementations;

public class CloudinaryService : ICloudinaryService
{
    private readonly IConfiguration _configuration;
    private readonly CloudinaryOptionsDto _optionsDto;
    private readonly Cloudinary _cloudinary = null!;

    public CloudinaryService(IConfiguration configuration)
    {
        _configuration = configuration;
        _optionsDto = _configuration.GetSection("CloudinarySettings").Get<CloudinaryOptionsDto>() ?? new();
        var myAccount = new Account { ApiKey = _optionsDto.APIKey, ApiSecret = _optionsDto.APISecret, Cloud = _optionsDto.CloudName };

        Cloudinary _cloudinary = new Cloudinary(myAccount);
        _cloudinary.Api.Secure = true;
    }

    public async Task<string> FileCreateAsync(IFormFile file)
    {
        string fileName = string.Concat(Guid.NewGuid(), file.FileName.Substring(file.FileName.LastIndexOf('.')));
   
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }
        string url = uploadResult.SecureUrl.ToString();

        return url;
    }

    public async Task<bool> FileDeleteAsync(string filePath)
    {

        var deletionParams = new DeletionParams(filePath);

        var deletionResult = await _cloudinary.DestroyAsync(deletionParams);

        return deletionResult.Result == "ok";
    }
}
