using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace DataLayer
{
    public class EntityContext<T>
    {
        public string Path;
        public EntityContext()
        {
            Path = @"C:\Users\Nout\OneDrive\Рабочий стол\КУрсач\WORK2\Classes\DataLayer\DataFiles\groups.json";
        }
        public List<T> ReadFromFile()
        {
            List<T> return_list = new List<T>();
            using (StreamReader streamReader = new StreamReader(Path))
            {
                string json_str = streamReader.ReadToEnd();
                return_list = JsonSerializer.Deserialize<List<T>>(json_str);
            }
            return return_list;
        }      
        public void CreateFile()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                List<T> list = new List<T>();
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json_str = JsonSerializer.Serialize<List<T>>(list, options);
                File.WriteAllText(Path, json_str);
            }
        }
        public void WriteToFile(List<T> data)
        {
            using (StreamWriter streamWriter = new StreamWriter(Path))
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json_str = JsonSerializer.Serialize<List<T>>(data, options);
                streamWriter.WriteLine(json_str);
            }
        }

    }
}
