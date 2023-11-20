using Arrays.classes.UE;
using System.Data.Common;

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

        public EUID ID { get { return id; } }

        public string Name { get { return _name; } }
        public string Surname {  get { return _surname; } }

        public string FullName {  get { return _name + " " + _surname; } }

        public void ChangeCommune(EUMunicipality municipality)
        {
            _municipality.RemoveCitizen(this);
            _municipality = municipality;
        }
    }
}
