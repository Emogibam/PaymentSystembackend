using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class SeederHelper<T>
    {
        public static List<T> GetData(string filePath)
        {
            var baseDir = Directory.GetCurrentDirectory();
            var path = File.ReadAllText(FilePath(baseDir, filePath));
            return JsonConvert.DeserializeObject<List<T>>(path);

        }

        private static string FilePath(string folderName, string fileName) =>
            Path.Combine(folderName += "/JsonFiles/", fileName);

    }
}
