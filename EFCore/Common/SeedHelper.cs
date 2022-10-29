using Newtonsoft.Json;

namespace EFCore.Common;

public class SeedHelper
{
    public static IEnumerable<TEntity> SeedData<TEntity>(string fileName)
    {
        try
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectPath = currentDirectory[..currentDirectory.IndexOf("Api", StringComparison.Ordinal)];
            var fullPath = Path.Combine(projectPath, "EFCore",
                fileName.TrimStart('~').Replace('/', Path.DirectorySeparatorChar));
            Console.WriteLine(fullPath);

            using var reader = new StreamReader(fullPath);
            var json = reader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<List<TEntity>>(json);

            return result ?? new List<TEntity>();
        }
        catch (Exception)
        {
            return new List<TEntity>();
        }
    }
}