using DataLayer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DbContext
{
    public class GenericDbContext<T, Rs> : DbContext
        where T : class, new()
        where Rs : IMediaObject


    {
        public List<Rs> Data { get; set; }

        public GenericDbContext(string basePath) : base(basePath)
        {
            string filePath = Path.Combine(basePath, typeof(T).Name + ".json");
            var dataFromJson = LoadFromJsonFile<T>(filePath);
            Data = dataFromJson.Select(item => TransformToDto(item)).ToList();
        }

        private List<T> LoadFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        private Rs TransformToDto(T item)
        {
          
            var constructorInfo = typeof(Rs).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[] { typeof(T) },
                null);

            if (constructorInfo == null)
            {
                throw new InvalidOperationException($"No matching constructor found for {typeof(Rs).Name} that takes a {typeof(T).Name} as a parameter.");
            }

            return (Rs)constructorInfo.Invoke(new object[] { item });
        }
    }
    }

