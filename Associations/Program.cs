using Associations.classes.Default;
using Associations.classes.EU;
using Associations.classes.UE;
using System;

namespace Associations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Testing EUState, EURegion, and EUParliament functionalities
            EuropeanUnion europeanUnion = new EuropeanUnion();
            EUState currentState = new EUState("Current State", europeanUnion);
            EUState newState = new EUState("New State", europeanUnion);
            EUParliament euParliament = new EUParliament();
            EURegion euRegion = new EURegion(currentState);
            EUProvince newProvince = new EUProvince(euRegion);

            // State and Region Operations
            Console.WriteLine("State and Region Operations:");
            euRegion.ChangeState(euParliament, newState);
            euRegion.AddProvince(euParliament, newProvince);
            bool borderRedefinitionResult = euRegion.BorderRedefinition(euParliament, newProvince);
            Console.WriteLine($"Border redefinition: {(borderRedefinitionResult ? "successful" : "unsuccessful")}");

            // Testing EUState methods
            currentState.EuropeanConstitutionalRegulation();
            currentState.HumanRightsTribunal();
            currentState.AddRegion(euParliament, euRegion);
            currentState.RemoveRegion(euParliament, euRegion);
            currentState.WelfareServices();

            // Testing EURegion methods
            euRegion.HealthCareNationalSystem();
            euRegion.LawSystem();
            euRegion.EducationalSystem();


            City city = new City();
            EUMunicipality municipality = new EUMunicipality(city, newProvince);
            EUID citizenID = new EUID("John Doe", "123456");
            EUCitizen citizen = new EUCitizen("Nome", "cognome", municipality, citizenID);

            // Citizen Public Service Operations
            Console.WriteLine("\nCitizen Public Service Operations:");
            municipality.LawSystem(citizenID);
            municipality.HealthCareNationalSystem(citizenID);
            municipality.LawSystem();
            municipality.HealthCareNationalSystem();

            // Municipality Operations
            municipality.AddCitizen(citizen);
            municipality.RemoveCitizen(citizen);
            municipality.ChangeProvince(newProvince, euParliament);




        }
    }
}
