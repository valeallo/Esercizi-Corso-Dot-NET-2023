using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IMediaObject
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
