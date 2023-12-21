using EmailSenderDataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using EmailSenderDataLayer.Dto;
using EmailSenderDataLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;



namespace EmailSenderDataLayer.DbContext
{


    #region Cos'è DataContext
    /*
      Il Datacontext  è'un ORM: In contesti di database e Object-Relational Mapping (ORM), 
      il datacontext può riferirsi a una classe che incapsula la logica per connettersi 
      a un database, eseguire query e gestire le entità del database. In questo senso, 
      funge da ponte tra il database e il livello di applicazione, consentendo agli 
      sviluppatori di lavorare con oggetti del dominio del problema invece di scrivere query SQL dirette.
     */
    #endregion
    #region ORM
    /*
      Un ORM (Object-Relational Mapping) è uno strumento di programmazione che permette di convertire 
      i dati tra sistemi incompatibili utilizzando un linguaggio di programmazione orientato agli oggetti.
      In pratica, un ORM consente agli sviluppatori di manipolare i dati di un database usando gli oggetti
      della loro lingua di programmazione, invece di dover scrivere codice SQL complesso
     */
    #endregion

    public abstract class DbContext
    {



        

        public DbContext()
        {

        }

   

        protected virtual void WriteDataToCsv<T>(List<T> data, string path)
            where T : class
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            foreach (var item in data)
            {
                var line = string.Join(",", properties.Select(p => p.GetValue(item, null)));
                sb.AppendLine(line);
            }

            File.WriteAllText(path, sb.ToString());
        }
        protected virtual List<T> ReadDataFromCsv<T>(string path)
            where T : class, new()
        {
            if (!File.Exists(path))
            {
                return null;
            }
            var list = CreateObject<T>(File.ReadAllLines(path).ToList());
            Console.WriteLine(list.Count);
            return list;
        }


        public static List<T> CreateObject<T>(List<string> lines) where T : class, new()
        {
            List<T> list = new List<T>();

            if (lines.Count == 0)
            {
                Console.WriteLine("CSV file is empty.");
                return list;
            }

            string[] headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
            bool isValid = true;

            foreach (string header in headers)
            {
                PropertyInfo property = typeof(T).GetProperty(header);

                if (property == null)
                {
                    Console.WriteLine($"Property '{header}' does not exist in the {typeof(T).Name} class.");
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Properties in the file do not match the object's properties.");
                return list;
            }

            for (int i = 1; i < lines.Count; i++)
            {
                string[] columns = lines[i].Split(',');

                if (columns.Length != headers.Length)
                {
                    Console.WriteLine($"Line {i + 1} has an incorrect number of columns.");
                    continue;
                }

                T entry = new T();

                for (int j = 0; j < headers.Length; j++)
                {
                    string columnName = headers[j];
                    string columnValue = columns[j];

                    PropertyInfo property = typeof(T).GetProperty(columnName);

                    if (property != null && property.CanWrite)
                    {
                        object convertedValue = (string.IsNullOrEmpty(columnValue) || string.IsNullOrWhiteSpace(columnValue))
                            ? null
                            : Convert.ChangeType(columnValue, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);

                        property.SetValue(entry, convertedValue);
                    }
                }

                list.Add(entry);
            }

            return list;
        }






    }
}
