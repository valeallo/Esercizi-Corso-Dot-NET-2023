namespace Arrays.classes.Default
{
    internal class State : IAdministrativeEntity
    {
        EURegion _region;
        Country _country;
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
