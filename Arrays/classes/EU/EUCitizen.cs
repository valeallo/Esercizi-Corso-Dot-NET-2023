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



        public void ChangeCommune(EUMunicipality municipality)
        {
            _municipality.RemoveCitizen(id);
            _municipality = municipality;
        }
    }
}
