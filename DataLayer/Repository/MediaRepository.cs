using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;


namespace DataLayer.Repository
{
   
        public class MediaRepository<T, Rs, Rq> : IRepository<T, Rs, Rq>
            where T : class, new()
            where Rs : class, IMediaObject, new()
            where Rq : class, IMediaObject, new()
        {
            private readonly GenericDbContext<T, Rs> _context;

            public MediaRepository(GenericDbContext<T, Rs> context)
            {
                _context = context;
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
        }
    

}
