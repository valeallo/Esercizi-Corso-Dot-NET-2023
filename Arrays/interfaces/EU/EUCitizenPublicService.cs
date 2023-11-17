using Arrays.classes.EU;
using System;

namespace Arrays.interfaces.EU
{
    abstract class EUCitizenPublicService : IAdministrativeEntity
    {

        public void LawSystem()
        {
            Console.WriteLine($"insert an id to use this function");
        }
        public void LawSystem(EUID id)
        {
            if (id != null)
            {
                Console.WriteLine($"{id.Name} can access law system");
            }
            else
            {

                Console.WriteLine($"{id.Name} cant access law system");
            };



        }

        public void HealthCareNationalSystem() { Console.WriteLine($"insert an id to use this function"); }
        public void HealthCareNationalSystem(EUID id)
        {
            if (id != null)
            {
                Console.WriteLine($"{id.Name} can access healthcare services");
            }
            else
            {
                Console.WriteLine($"{id.Name} cant access healthcare services");
            }

        }

        public void EducationalSystem() { }


    }
}
