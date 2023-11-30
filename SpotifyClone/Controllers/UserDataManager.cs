using Newtonsoft.Json;
using SpotifyClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SpotifyClone.Controllers
{
    internal class UserDataManager
    {


        public static string SerializeSongs(List<Song> songs)
        {
            return JsonConvert.SerializeObject(songs, Formatting.Indented);
        }


        public static List<Song> DeserializeSongs(string json)
        {
            return JsonConvert.DeserializeObject<List<Song>>(json);
        }


        public static void SaveToJsonFile<T>(T data, string filePath)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string jsonString = JsonConvert.SerializeObject(data, settings);
            File.WriteAllText(filePath, jsonString);
        }


        public static T LoadFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default(T);
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }


    }
}
