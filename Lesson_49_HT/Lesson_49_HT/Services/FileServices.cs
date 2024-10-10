using MyColection.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Lesson_49_HT.Services
{
    internal static class FileServices<T>
    {
        public static void SaveData(List<T> data, string path)
        {
            using (StreamWriter sw = new(path))
            {
                sw.WriteLine(JsonSerializer.Serialize(data));
            }
        }

        public static List<T>? GetData(string path)
        {
            using (StreamReader sr = new(path))
            {
                try
                {
                    List<T>? data = JsonSerializer.Deserialize<List<T>>(sr.ReadLine());
                    return data;
                }
                catch (System.ArgumentNullException)
                {
                    return new();
                }
                
            }
        }
    }

}
