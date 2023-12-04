using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;


namespace ServiceLayer
{
    internal class PlayerService
    {

        static SpotifyContext DbContext;
        static PlayerService instance;

        PlayerService()
        {
            string path = Directory.GetCurrentDirectory();
            string storage = Path.Combine(path, "storage");
            DbContext = new SpotifyContext(storage);
        }

        public static PlayerService GetInstance()
        {
            if (instance is null)
            {
                instance = new PlayerService();
            }
            return instance;
        }





      
}
}
