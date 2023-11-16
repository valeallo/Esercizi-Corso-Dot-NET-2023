using Associations.classes.EU;
using Associations.classes.UE;
using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.Default
{
    internal class State : IAdministrativeEntity
    {
        EURegion _region;
        Country _country;
        string _name;
        public State(string Name)
        {
            //_country = country;
            _name = Name;
        }
        public void AddRegion(EURegion region)
        {
            _region = region;
        }
        public void RemoveRegion(EURegion region)
        {
            _region = null;
        }




        public void HealthCareNationalSystem()
        {
            Console.WriteLine("state healthcare");

        }
        public void LawSystem()
        {
            Console.WriteLine("lawsystem state");

        }
        public void EducationalSystem()
        {
            Console.WriteLine("edusystem state");

        }
    }
}
