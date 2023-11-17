using Arrays.classes.UE;

namespace Arrays.classes.EU
{
    internal class EUCitizen
    {
        EUMunicipality _municipality;
        EUID id;
        string _name;
        string _surname;
        public EUCitizen(string Name, string Surname, EUMunicipality municipality, EUID id)
        {
            _municipality = municipality;
        }


        public void ChangeCommune(EUMunicipality municipality)
        {
            _municipality.RemoveCitizen(this);
            _municipality = municipality;
        }
    }
}
