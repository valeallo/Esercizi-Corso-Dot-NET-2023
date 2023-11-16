using Associations.classes.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.interfaces.EU
{
    internal interface IEUCitizenPublicService : IAdministrativeEntity
    {

        public bool HealthCareNationalSystem(EUID id)
        {
            if (id != null)
            {
                return true;
            }
            return false;
            
        }
        public bool LawSystem( EUID id) 
        {
            if (id != null)
            {
                return true;
            }
            return false;

        }
   

    }
}
