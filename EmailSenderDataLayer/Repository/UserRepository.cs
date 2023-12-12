using EmailSenderDataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EmailSenderDataLayer.DbContext;
using System.IO;


namespace EmailSenderDataLayer.Repository
{
   
        public class UserRepository<T, Rs, Rq> : IRepository<T, Rs, Rq>
            where T : class, new()
            where Rs : class, IMediaObject, new()
            where Rq : class, IMediaObject, new()
        {
            private readonly GenericDbContext<T, Rs> _context;

            public UserRepository()
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dataDirectory = Path.Combine(baseDirectory, "data");
                _context = new GenericDbContext<T, Rs>(dataDirectory);
 
            }

            public List<Rs> GetAll()
            {
                return _context.Data;
            }

            public Rs GetById(string id)
            {
                return _context.Data.FirstOrDefault(d => d.Id == id);
            }

            public bool DeleteById(string id)
            {
                var item = GetById(id);
                if (item != null)
                {
                    _context.Data.Remove(item);

                    //TODO change the data source
                    return true; 
                }
                return false;
            }

            public bool Update(Rq request)
            {
                var item = GetById(request.Id);
                if (item != null)
                {
                    //TODO implement changing data source

                    return true; 
                }
                return false;
            }


            public Rs GetByName(string name)
            {
                return _context.Data.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
    }
    

}
