using Application.Common.Interfaces.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class AttachmentProvider : IAttachmentProvider
{
    private readonly Cloudinary _cloudinary;

    public AttachmentProvider(IConfiguration configuration)
    {
        var cloudName = configuration["CloudinarySettings:CloudName"];
        var apiKey = configuration["CloudinarySettings:ApiKey"];
        var apiSecret = configuration["CloudinarySettings:ApiSecret"];

        // var cloudName = "monarchz";
        // var apiKey = "158388936842612";
        // var apiSecret = "2n5v9MIWDbO9VnvQTa432lJZORE";

        _cloudinary = new Cloudinary(@$"cloudinary://{apiKey}:{apiSecret}@{cloudName}")
        {
            Api =
            {
                Secure = true
            }
        };
    }

    public string? ImageUpload(IFormFile file)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(_getFileName(file), file.OpenReadStream()),
            Overwrite = true,
            PublicId = "ietls/images/" + _getName(file)
        };
        var uploadResult = _cloudinary.Upload(uploadParams);
        return uploadResult?.Url?.ToString();
    }

    public string? AudioUpload(IFormFile file)
    {
        var uploadParams = new VideoUploadParams()
        {
            File = new FileDescription(_getFileName(file), file.OpenReadStream()),
            Overwrite = true,
            PublicId = "ietls/audios/" + _getName(file)
        };
        var uploadResult = _cloudinary.Upload(uploadParams);
        return uploadResult?.Url?.ToString();
    }

    private static string _getName(IFormFile file)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
        var name = $"{fileNameWithoutExtension}-{Guid.NewGuid()}";

        return name;
    }

    private static string _getFileName(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.FileName);
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);

        var filename = $"{fileNameWithoutExtension}-{Guid.NewGuid()}{fileExtension}";

        return filename;
    }
}