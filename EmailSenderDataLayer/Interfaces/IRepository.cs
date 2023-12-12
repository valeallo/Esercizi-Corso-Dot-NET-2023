using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Interfaces
{
    interface IRepository<T, Rs, Rq>
    {
        public List<Rs> GetAll();
        public Rs GetById(string id);
        public bool DeleteById(string id);
        public bool Update(Rq request);

        public bool Create(Rq request);
        //public Rs GetByName(string name);
    }
}
