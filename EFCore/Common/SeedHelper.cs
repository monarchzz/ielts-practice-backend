using Newtonsoft.Json;

namespace EFCore.Common;

public class SeedHelper
{
    public static IEnumerable<TEntity> SeedData<TEntity>(string fileName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine(currentDirectory);

        var projectPath = currentDirectory.Replace(@"\Api", "");
        var fullPath = Path.Combine(projectPath, fileName.TrimStart('~').Replace('/', Path.DirectorySeparatorChar));

        using var reader = new StreamReader(fullPath);
        var json = reader.ReadToEnd();
        var result = JsonConvert.DeserializeObject<List<TEntity>>(json);

        return result ?? new List<TEntity>();
    }
}