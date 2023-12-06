using DataLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbContext
{
    public class GenericDbContext<T, Rs> : DbContext
        where T : class, new()
        where Rs : IMediaObject


    {
        public List<Rs> Data { get; set; }

        public GenericDbContext(string path) : base(path)
        {
            var dataFromJson = LoadFromJsonFile<T>(Path.Combine(path, typeof(T).Name + ".json"));
            Data = dataFromJson.Select(o => Activator.CreateInstance(typeof(Rs), o)).Cast<Rs>().ToList();
        }

        private List<T> LoadFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
    }
}
