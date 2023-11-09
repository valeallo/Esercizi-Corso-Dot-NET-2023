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
                HasCompletedMilitaryService: false
            );

            Citizen eugenio = new Citizen(
                Name: "Eugenio",
                Surname: "Motta",
                Age: 50,
                NumberOfChildren: 0,
                HasDebts: true,
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
                HasCompletedMilitaryService: false, 
                HighSchoolFinalScore: 88,
                UniversityAverageGrade: 29.5
            );

            // Create a Commune instance to use the Rdc method
            Commune myCommune = new Commune(NameCommune: "Comune di Esempio", NameProvince: "Provincia di Esempio");

            chiara.GetInfo();
            luca.GetInfo();
            mario.GetInfo();
        
       

            // Calculate Rdc score for each individual
            int chiaraRdcScore = myCommune.Rdc(chiara);
            int eugenioRdcScore = myCommune.Rdc(eugenio);
            int marioRdcScore = myCommune.Rdc(mario);
            int lucaRdcScore = myCommune.Rdc(luca);

            // Print out the scores
            Console.WriteLine($"\n---------------");
            Console.WriteLine($"{chiara.FullName} Rdc score: {chiaraRdcScore}");
            Console.WriteLine($"{eugenio.FullName} Rdc score: {eugenioRdcScore}");
            Console.WriteLine($"{mario.FullName} Rdc score: {marioRdcScore}");
            Console.WriteLine($"{luca.FullName} Rdc score: {lucaRdcScore}");
        }


    }
    abstract class Person
    {
        protected string _name;
        protected string _surname;
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


        public abstract void GetInfo();



    }

    internal class Citizen : Person
    {
        protected int _numberOfChildren;
        protected bool _hasDebts;
        protected bool _hasCompletedMilitaryService;
        public Citizen(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, bool HasCompletedMilitaryService) : base(Name, Surname, Age)
        {
            _numberOfChildren = NumberOfChildren;
            _hasDebts = HasDebts;
            _hasCompletedMilitaryService = HasCompletedMilitaryService;
        }
        public int NumberOfChildren { get { return _numberOfChildren; } }
        public bool HasDebts { get { return _hasDebts; } }
        public bool HasCompletedMilitaryService { get { return _hasCompletedMilitaryService; } }

        public override void GetInfo()
        {
            Console.Write($"\n{FullName}, Age: {_age}");
        }

    }

    internal class Student : Citizen
    {
        private double _highSchoolFinalScore;
        public Student(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts, bool HasCompletedMilitaryService, double HighSchoolFinalScore) : base(Name, Surname, Age, NumberOfChildren, HasDebts, HasCompletedMilitaryService)
        {
            _highSchoolFinalScore = HighSchoolFinalScore;
        }
        public double HighSchoolFinalScore { get { return _highSchoolFinalScore; } }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", HighSchool Final Score: {HighSchoolFinalScore}");
        }

    }
    internal class UniversityStudent : Student
    {
        private double _universityAverageGrade;
        public UniversityStudent(string Name, string Surname, int Age, int NumberOfChildren, bool HasDebts,  bool HasCompletedMilitaryService, double HighSchoolFinalScore, double UniversityAverageGrade) : base(Name, Surname, Age, NumberOfChildren, HasDebts, HasCompletedMilitaryService, HighSchoolFinalScore)
        {
            _universityAverageGrade = UniversityAverageGrade;
        }

        public double UniversityAverageGrade { get { return _universityAverageGrade; } }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", avarage grade: {UniversityAverageGrade}");
        }
    }


    abstract class Province
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
        private int _municipalityGDP = 1000000;

        public Commune(string NameCommune, string NameProvince) : base(NameProvince)
        {
            _nameCommune = NameCommune;
        }

        public int Rdc(Citizen citizen)
        {
            int count = 0;
            int inc = 4;
            if (_municipalityGDP >= 100)
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

                if (student.HighSchoolFinalScore > 90)
                {
                    count += inc;
                }
            }

            if (citizen is UniversityStudent universityStudent)
            {
                if (universityStudent.UniversityAverageGrade > 28)
                {
                    count += inc;
                }
              
            }




            return count;
        }

    }



}
