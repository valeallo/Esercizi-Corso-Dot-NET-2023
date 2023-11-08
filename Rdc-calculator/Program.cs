using System;

namespace Rdc_calculator
{
 
        internal class Program
        {
            static void Main(string[] args)
            {
            //Person Chiara = new Person(
            //            Name: "Chiara",
            //            Surname: "Rossi",
            //            HasCompletedMilitaryService: false,
            //            Age: 23,
            //            IsUniversityStudent: true,
            //            HighSchoolFinalScore: 95.5,
            //            UniversityAverageGrade: 29.0,
            //            NumberOfChildren: 1,
            //            MunicipalityGDP: 80_000_000, 
            //            HasDebts: false
            //        );
            //Person Eugenio = new Person(
            //          Name: "Eugenio",
            //          Surname: "Motta",
            //          HasCompletedMilitaryService: false,
            //          Age: 50,
            //          IsUniversityStudent: true,
            //          HighSchoolFinalScore: 60,
            //          UniversityAverageGrade: 0,
            //          NumberOfChildren: 0,
            //          MunicipalityGDP: 1_000_000_000,
            //          HasDebts: true
            //        );
            //Intesa.Balance = 1000; // Error: Setter is private
            //Console.WriteLine($"{Chiara.FullName} qualifies for Rdc :  {Chiara.IsQualifiedForRdc}");
            //Console.WriteLine($"{Eugenio.FullName} qualifies for Rdc :  {Eugenio.IsQualifiedForRdc}");
        }
        }
        internal class Person
        {
            protected string _name;
            protected string _surname;
            protected bool _hasCompletedMilitaryService;
            protected int _age;
            protected bool _isUniversityStudent;
            protected double _universityAverageGrade;




        public Person(string Name, string Surname, int Age)
            {
            //bool IsUniversityStudent, double UniversityAverageGrade, int MunicipalityGDP, bool HasCompletedMilitaryService,


                 _name = Name;
                _surname = Surname;
                _age = Age;
            //_hasCompletedMilitaryService = HasCompletedMilitaryService;
            //_isUniversityStudent = IsUniversityStudent;
            //_universityAverageGrade = UniversityAverageGrade;
      

        }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public string FullName { get { return _name + " " + _surname; } }

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

        internal class Citizen : Person
    {
        protected int _numberOfChildren;
        protected bool _hasDebts;
        protected double _municipalityGDP;
        public Citizen(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, double MunicipalityGDP) : base(Name, Surname, Age)
        {
            _numberOfChildren = NumberOfChildren;
            _hasDebts = HasDebts;
            _municipalityGDP = MunicipalityGDP;
        }
    }

    internal class Student : Citizen
    {
        private double _highSchoolFinalScore;
        public Student(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, double MunicipalityGDP, double HighSchoolFinalScore) : base(Name, Surname, Age, NumberOfChildren, HasDebts, MunicipalityGDP)
        {
            _highSchoolFinalScore = HighSchoolFinalScore;
        }
    }

    
}
