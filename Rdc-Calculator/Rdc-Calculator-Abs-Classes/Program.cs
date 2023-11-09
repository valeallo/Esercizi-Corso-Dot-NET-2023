using System;

namespace Rdc_Calculator_Abs_Classes
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Citizen, Student, and UniversityStudent with the new military service variable
            Citizen chiara = new Citizen(
                Name: "Chiara",
                Surname: "Rossi",
                Age: 23,
                NumberOfChildren: 1,
                HasDebts: false,
                MunicipalityGDP: 80_000_000,
                HasCompletedMilitaryService: false
            );

            Citizen eugenio = new Citizen(
                Name: "Eugenio",
                Surname: "Motta",
                Age: 50,
                NumberOfChildren: 0,
                HasDebts: true,
                MunicipalityGDP: 1_000_000_000,
                HasCompletedMilitaryService: true 
            );

            // Assuming that 'Student' should be used for high school students
            // Note: Student class constructor needs to be updated to include the new parameter if it isn't already
            Student mario = new Student(
                Name: "Mario",
                Surname: "Bianchi",
                Age: 19,
                NumberOfChildren: 0,
                HasDebts: false,
                MunicipalityGDP: 50_000_000,
                HasCompletedMilitaryService: false,
                HighSchoolFinalScore: 98
            );

            // UniversityStudent instance
            // Note: UniversityStudent class constructor needs to be updated to include the new parameter if it isn't already
            UniversityStudent luca = new UniversityStudent(
                Name: "Luca",
                Surname: "Verdi",
                Age: 22,
                NumberOfChildren: 0,
                HasDebts: false,
                MunicipalityGDP: 30_000_000,
                HasCompletedMilitaryService: false, 
                HighSchoolFinalScore: 88,
                UniversityAverageGrade: 29.5
            );

            // Create a Commune instance to use the Rdc method
            Commune myCommune = new Commune(NameCommune: "Comune di Esempio", NameProvince: "Provincia di Esempio");

            // Calculate Rdc score for each individual
            int chiaraRdcScore = myCommune.Rdc(chiara);
            int eugenioRdcScore = myCommune.Rdc(eugenio);
            int marioRdcScore = myCommune.Rdc(mario);
            int lucaRdcScore = myCommune.Rdc(luca);

            // Print out the scores
            Console.WriteLine($"{chiara.FullName} Rdc score: {chiaraRdcScore}");
            Console.WriteLine($"{eugenio.FullName} Rdc score: {eugenioRdcScore}");
            Console.WriteLine($"{mario.FullName} Rdc score: {marioRdcScore}");
            Console.WriteLine($"{luca.FullName} Rdc score: {lucaRdcScore}");
        }


    }
    internal class Person
    {
        protected string _name;
        protected string _surname;
        protected bool _hasCompletedMilitaryService;
        protected int _age;
        protected bool _isUniversityStudent;

        public Person(string Name, string Surname, int Age)
        {



            _name = Name;
            _surname = Surname;
            _age = Age;
        }

        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public int Age { get { return _age; } }
        public string FullName { get { return _name + " " + _surname; } }



    }

    internal class Citizen : Person
    {
        protected int _numberOfChildren;
        protected bool _hasDebts;
        protected double _municipalityGDP;
        protected bool _hasCompletedMilitaryService;
        public Citizen(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, double MunicipalityGDP, bool HasCompletedMilitaryService) : base(Name, Surname, Age)
        {
            _numberOfChildren = NumberOfChildren;
            _hasDebts = HasDebts;
            _municipalityGDP = MunicipalityGDP;
            _hasCompletedMilitaryService = HasCompletedMilitaryService;
        }
        public int NumberOfChildren { get { return _numberOfChildren; } }
        public bool HasDebts { get { return _hasDebts; } }
        public double MunicipalityGDP { get { return _municipalityGDP; } }
        public bool HasCompletedMilitaryService { get { return _hasCompletedMilitaryService; } }

    }

    internal class Student : Citizen
    {
        private double _highSchoolFinalScore;
        public Student(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, double MunicipalityGDP, bool HasCompletedMilitaryService, double HighSchoolFinalScore) : base(Name, Surname, Age, NumberOfChildren, HasDebts, MunicipalityGDP, HasCompletedMilitaryService)
        {
            _highSchoolFinalScore = HighSchoolFinalScore;
        }
        public double HighSchoolFinalScore { get { return _highSchoolFinalScore; } }

    }
    internal class UniversityStudent : Student
    {
        private double _universityAverageGrade;
        public UniversityStudent(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, double MunicipalityGDP, bool HasCompletedMilitaryService, double HighSchoolFinalScore, double UniversityAverageGrade) : base(Name, Surname, Age, NumberOfChildren, HasDebts, MunicipalityGDP, HasCompletedMilitaryService, HighSchoolFinalScore)
        {
            _universityAverageGrade = UniversityAverageGrade;
        }

        public double UniversityAverageGrade { get { return _universityAverageGrade; } }
    }


    internal class Province
    {
        private string _nameProvince;

        public Province(string NameProvince)
        {
            _nameProvince = NameProvince;
        }
    }

    internal class Commune : Province
    {
        private string _nameCommune;

        public Commune(string NameCommune, string NameProvince) : base(NameProvince)
        {
            _nameCommune = NameCommune;
        }

        public int Rdc(Citizen citizen)
        {
            int count = 0;
            int inc = 4;
            if (citizen.MunicipalityGDP >= 100)
            {
                count += inc;
            }
            if (citizen.NumberOfChildren > 1)
            {
                count += inc;
            }
            if (!citizen.HasDebts)
            {
                count += inc;
            }
            if ((citizen.Age >= 18 && citizen.Age <= 25) || citizen.Age >= 60)
            {
                count += inc;
            }

            if (citizen.HasCompletedMilitaryService)
            {
                count += inc;
            }

            if (citizen is Student student)
            {
                Console.WriteLine($"Debug: Checking high school final score for {student.FullName}");

                if (student.HighSchoolFinalScore > 90)
                {
                    Console.WriteLine($"Debug: {student.FullName} has a high school final score greater than 90.");
                    count += inc;
                }
                else
                {
                    Console.WriteLine($"Debug: {student.FullName} does not have a high school final score greater than 90.");
                }
            }

            if (citizen is UniversityStudent universityStudent)
            {
                Console.WriteLine($"Debug: Checking university average grade for {universityStudent.FullName}");

                if (universityStudent.UniversityAverageGrade > 28)
                {
                    Console.WriteLine($"Debug: {universityStudent.FullName} has a university average grade greater than 28.");
                    count += inc;
                }
                else
                {
                    Console.WriteLine($"Debug: {universityStudent.FullName} does not have a university average grade greater than 28.");
                }
            }




            return count;
        }

    }





}
