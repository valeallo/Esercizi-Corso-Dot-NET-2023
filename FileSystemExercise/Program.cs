using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace FileSystemExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetDirInfo();
            string path = myProjectDirectory();
            string logsDirectory = Path.Combine(path, "logs");

            #region Tabular

            List<Customer> users = new List<Customer>();
            users.Add(new Customer("Alessio trotta", 50));
            users.Add(new Customer("Chiara Francini", 40));
            users.Add(new Customer("Sara Fedeli", 40));
            users.Add(new Customer("Giulia Ferragni", 30));
            users.Add(new Customer("Mario Spelta", 30));


            List<Account> accounts = new List<Account>();
            accounts.Add(new Account(1010, 0));
            accounts.Add(new Account(70898, 4000));
            accounts.Add(new Account(85798, 400));
            accounts.Add(new Account(989809, 308));
            accounts.Add(new Account(687687, 3000000));



  


            string costumerfilename = "CostumersTabularFile.csv";
            string accountTabular = "AccountsTabular.csv";
            string accountJSOn = "AccountsJSON.json";

            WriteAsTabular(logsDirectory, costumerfilename, users);
            WriteAsTabular(logsDirectory, accountTabular, accounts);
            WriteAsJSON(logsDirectory, accountJSOn, accounts);


            #endregion

        }
        static void SpecialPath(string RootPath, String MyDir) // Path  = percorso LOCAL  -> REMOTE path -> SERVER  
        {
            string myPath = $"{RootPath}{Path.DirectorySeparatorChar}{MyDir}";

            Console.WriteLine(myPath);
            // C:\users\bruno\ -> Windows 
            // Home/Bruno/miofile/ -> UNIX + MacOS
        }
        static void SpecialDirectory()
        {
            string SpecialDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(SpecialDir);
        }
        static void SplitPath()
        {
            string myDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(myDirectory);
            string[] splitedPath = myDirectory.Split(Path.DirectorySeparatorChar);

            foreach (var item in splitedPath)
            {
                // int counter = 1;
                Console.Write("\\");
                Console.WriteLine(item);

            }
            JoinPath(splitedPath);
        }
        static void JoinPath(string[] _path)
        {

            var path = Path.Combine(_path);
            Console.Write("JOINED STRINGS: ");
            Console.WriteLine(path);
        }
        static void GetFileExtention()
        {
            var fExt = Path.GetExtension("vendita.json");
            Console.WriteLine(fExt);
        }
        static void GetDirInfo()
        {
            string path = Directory.GetCurrentDirectory(); // -> trova il Path 
            DirectoryInfo dInfos = new DirectoryInfo(path);


            foreach (var item in dInfos.GetFiles())
            {
                Console.WriteLine($"Name -  {item.Name}");
                Console.WriteLine($"Parent Directory -  {item.Directory.Parent.Parent.Parent}");
                Console.WriteLine($" Directory FullName -  {item.Directory.FullName}");
                Console.WriteLine($" Directory CreationTime -  {item.Directory.CreationTime}");
                Console.WriteLine($" Directory LastAccessTime -  {item.Directory.LastAccessTime}");
                Console.WriteLine($" Directory Root -  {item.Directory.Root}");


            }
        }


        static string myProjectDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo dInfos = new DirectoryInfo(path);
            string myPath = dInfos.Parent.Parent.Parent.ToString();
            return myPath;

        }
        static void SearchInDirectory()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories);

            foreach (var file in files)
                Console.WriteLine(file);
        }
        static void FindOrCreate(String path)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            if (info.Exists)
            {
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }
            else
            {
                info.Create();
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }
        }
        static void CreateFile(string FileName)
        {
            File.Create(FileName);
        }
        static void WriteOnFile(string path, string FileName)
        {
            List<string> mytext = new List<string>()
            {
                "Heello by Bruno",
                "Heello by marco",
                "Heello by Maria"
            };

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllLines(Path.Combine(path, FileName), mytext); // Overwrite all content 
            File.AppendAllLines(Path.Combine(path, FileName), mytext); // Append content text 


        }
        static void ReadOnFile(string path, string FileName)
        {
            var texd = File.ReadAllText(Path.Combine(path, FileName));
            Console.WriteLine(texd);
        }
        static void SimpleFileMove(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Move(Src, dest);
        }
        static void SimpleFileCopy(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Copy(Src, dest, true);
        }
        static void SimpleFileDelete(string SrcPath, string Filename)
        {
            File.Delete(Path.Combine(SrcPath, Filename));
        }
        static void WriteAsTabular(string path, string Filename, List<Customer> data)
        {

            StringBuilder sb = new StringBuilder();

            string FilePath = Path.Combine(path, Filename);

            if (!File.Exists(FilePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }
            foreach (var usr in data)
            {
                  sb.AppendLine(string.Format($"{usr.Name},{usr.Age}"));
            }
            File.AppendAllText(FilePath, sb.ToString()); 


        }


        static void WriteAsTabular(string path, string Filename, List<Account> data)
        {

            StringBuilder sb = new StringBuilder();

            string FilePath = Path.Combine(path, Filename);

            if (!File.Exists(FilePath))
            {
                string header = string.Format("id,total");
                sb.AppendLine(header);
            }
            foreach (var acc in data)
            {
                sb.AppendLine(string.Format($"{acc.AccountId},{acc.Saldo}"));
            }
            File.AppendAllText(FilePath, sb.ToString());


        }

        static void WriteAsJSON(string path, string Filename, List<Account> data)
        {

            StringBuilder sb = new StringBuilder();

            string FilePath = Path.Combine(path, Filename);

            if (!File.Exists(FilePath))
            {
                string header = string.Format("id,total");
                sb.AppendLine(header);
            }
            for (int i = 0; i < data.Count; i++)
            {
                var acc = data[i];
                string jsonLine = $"{{\"AccountId\": {acc.AccountId}, \"Saldo\": {acc.Saldo}}}";
                if (i < data.Count - 1)
                {
                    jsonLine += ",";
                }
                sb.AppendLine(jsonLine);
               
            }
            File.AppendAllText(FilePath,$"[{sb.ToString()}]");


        }

    }
    public class Customer
    {
        string _name;
        int _age;
        public Customer(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name { get {return _name; } }
        public int Age { get {return _age; } }

    }
    public class Account
    {
        int _id;
        decimal _saldo;
        public Account (int accountId, decimal saldo)
        {
           _id = accountId;
           _saldo = saldo;
        }


        public int AccountId { get { return _id; } }
        public decimal Saldo { get { return _saldo; } }

    }
}