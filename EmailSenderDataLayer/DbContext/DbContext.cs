using EmailSenderDataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;




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
        string _config;
        protected DbContext(string config)
        {
            _config = config;
        }

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

            return CreateObject<T>(File.ReadAllLines(path).ToList());
        }
        private static List<T> CreateObject<T>(List<string> file)
            where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = file.ElementAt(0).Split(',');
            file.RemoveAt(0);

            bool isDataset = true;
            T entry = new T();
            PropertyInfo[] prop = entry.GetType().GetProperties();

            if (isDataset)
            {
                for (int i = 0; i < prop.Length; i++)
                {
                    if (prop.ElementAt(i).Name == headers[i])
                        continue;
                    else isDataset = false;
                }
            }
            if (isDataset)
            {
                foreach (var line in file)
                {
                    entry = new T();

                    int j = 0;
                    string[] columns = line.Split(',');

                    foreach (var col in columns)
                    {
                        if (col == null || col == string.Empty)
                        {
                            j++;
                            continue;
                        }
                        try
                        {
                            var CurrentProp = entry.GetType().GetProperty(headers[j]).PropertyType;
                            if (CurrentProp.IsEnum)
                            {
                                object enumValue = Enum.Parse(CurrentProp, col);
                                entry.GetType().GetProperty(headers[j]).SetValue(entry, enumValue);
                            }
                            else
                                entry.GetType()
                                    .GetProperty(headers[j])
                                    .SetValue(entry, Convert.ChangeType(col, entry.GetType().GetProperty(headers[j])
                                    .PropertyType));
                        }
                        catch (Exception ex)
                        {
                            
                        }
                        j++;
                    }

                    list.Add(entry);
                }
            }

            return list;
        }



        protected virtual void SaveDataToCsv<T>(List<T> data, string path)
        where T : class, new()
            {
   
                WriteDataToCsv(data, path);
            }
    }
}
