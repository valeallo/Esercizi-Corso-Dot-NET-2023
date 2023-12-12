using EmailSenderDataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.DbContext
{
    public class GenericDbContext<T, Rs> : DbContext
        where T : class, new()
        where Rs : class, new()


    {
        public List<Rs> Data { get; set; }

        public GenericDbContext(string basePath) : base(basePath)
        {
            string filePath = Path.Combine(basePath, typeof(T).Name + ".json");
            
            
        }


    }
    }

