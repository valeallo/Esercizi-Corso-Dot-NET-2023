using Arrays.classes.UE;
using Arrays.interfaces;
using System;

namespace Arrays.classes.Default
{
    internal class State : IAdministrativeEntity
    {
        EURegion _region;
        string _name;
        public State(string Name)
        {
          
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


        public string Name { get { return _name; } }
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
