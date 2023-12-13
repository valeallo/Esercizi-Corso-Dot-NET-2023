using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Interfaces
{
    public interface IDto<T> where T : class
    {
        string Id { get; }

        public void initializeFromEntity(T entity);

    }
}
