using System;

namespace Rdc_calculator
{
 
        internal class Program
        {
            static void Main(string[] args)
            {
            Citizen Chiara = new Citizen(
                        Name: "Chiara",
                        HasCompletedMilitaryService: false,
                        Age: 23,
                        IsUniversityStudent: true,
                        HighSchoolFinalScore: 95.5,
                        UniversityAverageGrade: 29.0,
                        NumberOfChildren: 1,
                        MunicipalityGDP: 80_000_000, 
                        HasDebts: false
                    );
            Citizen Eugenio = new Citizen(
                      Name: "Eugenio",
                      HasCompletedMilitaryService: false,
                      Age: 50,
                      IsUniversityStudent: true,
                      HighSchoolFinalScore: 60,
                      UniversityAverageGrade: 0,
                      NumberOfChildren: 0,
                      MunicipalityGDP: 1_000_000_000,
                      HasDebts: true
                    );
            //Intesa.Balance = 1000; // Error: Setter is private
            Console.WriteLine($"{Chiara._name} qualifies for Rdc :  {Chiara.IsQualifiedForRdc}");
            Console.WriteLine($"{Eugenio._name} qualifies for Rdc :  {Eugenio.IsQualifiedForRdc}");
        }
        }
        public class Citizen
        {
            public string _name;
            private bool _hasCompletedMilitaryService;
            private int _age;
            private bool _isUniversityStudent;
            private double _highSchoolFinalScore;
            private double _universityAverageGrade;
            private int _numberOfChildren;
            private double _municipalityGDP;
            private bool _hasDebts;


        public Citizen(string Name, bool HasCompletedMilitaryService, int Age, bool IsUniversityStudent, double HighSchoolFinalScore, double UniversityAverageGrade, int NumberOfChildren, int MunicipalityGDP, bool HasDebts)
            {
                _name = Name;
                _hasCompletedMilitaryService = HasCompletedMilitaryService;
                _age = Age;
                _isUniversityStudent = IsUniversityStudent;
                _highSchoolFinalScore = HighSchoolFinalScore;
                _universityAverageGrade = UniversityAverageGrade;
                _numberOfChildren = NumberOfChildren;
                _municipalityGDP = MunicipalityGDP;
                _hasDebts = HasDebts;
            }
            public bool IsQualifiedForRdc
            {
                get
                {
                    return checkRdcParameters();
                }
                private set
                {
                    // logic
                }
            }
            private bool checkRdcParameters()
            {
            int score = 0;

            
            if (_hasCompletedMilitaryService)
            {
                score += 5;
            }

            
            if ((_age >= 18 && _age <= 25 && _isUniversityStudent) || _age > 60)
            {
                score += 5;
            }

            
            if (_highSchoolFinalScore > 90)
            {
                score += 5;
            }

        
            if (_universityAverageGrade > 28)
            {
                score += 5;
            }

            if (_numberOfChildren > 1)
            {
                score += 5;
            }

            if (_municipalityGDP < 100_000_000)
            {
                score += 5;
            }

            if (!_hasDebts)
            {
                score += 5;
            }
           
            return score >= 25;
        }
        }
    
}
