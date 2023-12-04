using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    public class RadioDTO
    {


            public string Name { get; set; }


            public RadioDTO(Radio radio)
            {
                Name = radio.Name;
            }

            public RadioDTO()
            {
            }


     }
    

}
}
