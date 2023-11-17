using System;

namespace Arrays.classes.UE
{
    internal class EUParliament
    {

        public EUParliament() { }


        public bool ApproveChanges()
        {
            Random random = new Random();
            bool result = random.Next(2) == 1;
            return result;
        }
    }


}
