using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    public class RadioDTO: IMediaObject
    {

            public string Name { get; set; }

            public string Id { get; set; }
            internal RadioDTO(Radio radio)
            {
                Name = radio.Name;
                Id = radio.Id;
            }

            public RadioDTO()
            {
            }


     }
    

}

