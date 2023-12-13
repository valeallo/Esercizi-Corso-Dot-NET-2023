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
   
        public class GenericRepository<T, Rs, Rq> : IRepository<T, Rs, Rq>
            where T : class, new()
            where Rs : IDto, new()
            where Rq : IDto, new()
        {
            private readonly GenericDbContext<T, Rs> _context;

            public GenericRepository()
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
                    _context.SaveChanges(); 
                    return true;
                }
                return false;
            }

            public bool Update(Rq request)
            {
                var item = GetById(request.Id);
                if (item != null)
                {
                    // TODO: Map request to item properties
                    // Example: item.Name = request.Name;
                    _context.SaveChanges(); 
                    return true;
                }
                return false;
            }

        public bool Create(Rq request)
        {
            try
            {
                if (request == null)
                {
                    return false;
                }

                _context.Add(request);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"REpository error message creating item: {ex.Message}");

                return false;
            }
        }

        






        //public Rs GetByName(string name)
        //{
        //    return _context.Data.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        //}
    }
    

}
