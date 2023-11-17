using Associations.classes.UE;
using System;

namespace Associations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of EuropeanUnion
            EuropeanUnion europeanUnion = new EuropeanUnion(); // Assuming you have a constructor for EuropeanUnion

            // Create two states
            EUState currentState = new EUState("Current State", europeanUnion);
            EUState newState = new EUState("New State", europeanUnion);

            // Create an instance of EUParliament
            EUParliament euParliament = new EUParliament();

            // Create a region
            EURegion euRegion = new EURegion(currentState);

            // Simulate changing the state of a region
            Console.WriteLine("Attempting to change the state of a region...");
            euRegion.ChangeState(euParliament, newState);

            // Simulate adding a province to a region
            EUProvince newProvince = new EUProvince(euRegion); // Assuming you have a constructor for EUProvince
            Console.WriteLine("Attempting to add a province to a region...");
            euRegion.AddProvince(euParliament, newProvince);

            // Simulate removing a province from a region through border redefinition
            Console.WriteLine("Attempting border redefinition to remove a province...");
            bool borderRedefinitionResult = euRegion.BorderRedefinition(euParliament, newProvince);
            Console.WriteLine($"Border redefinition was {(borderRedefinitionResult ? "successful" : "unsuccessful")}.");

            // Testing the state's methods
            Console.WriteLine("\nTesting EUState's methods:");
            currentState.EuropeanConstitutionalRegulation();
            currentState.HumanRightsTribunal();
            currentState.AddRegion(euParliament, euRegion);
            currentState.RemoveRegion(euParliament, euRegion);
            currentState.WelfareServices();

            // Testing the region's other methods
            Console.WriteLine("\nTesting EURegion's other methods:");
            euRegion.HealthCareNationalSystem();
            euRegion.LawSystem();
            euRegion.EducationalSystem();
        }
    }
}
