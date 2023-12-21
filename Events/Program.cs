using Events.Models;
using System;
using static Events.Thermometer;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //code example from lesson
            Thermometer thermometerSamsung = new Thermometer();
            thermometerSamsung.Name = "Samsung";
            thermometerSamsung.TempChanged += new OnTempChangedEventHandler(TurnOffTermostato);
            thermometerSamsung.Temp = 18;


            Thermometer thermometerArsiton = new Thermometer();
            thermometerArsiton.Name = "Arsiton";
            thermometerArsiton.TempChanged += new OnTempChangedEventHandler(TurnOffTermostato);
            thermometerArsiton.Temp = 28;


            //exercise code
            EuropeanUnion eu = new EuropeanUnion();

            EuropeanCountry italy = new EuropeanCountry("Italy");
            EuropeanCountry france = new EuropeanCountry("France");

            eu.AddCountry(italy);
            eu.AddCountry(france);

            italy.CovidPositives = 1000;
            france.CovidPositives = 500;

            Console.WriteLine($"Total COVID-19 positives in EU: {eu.TotalCovidPositives}");

        }


        //code example from lesson
        public static void TurnOffTermostato(object sender, ChangeTempEventArgs e)
        {
            Console.WriteLine(sender.GetType().GetProperty("Name").GetValue(sender));

            if (e.NewTemp < 24)
            {
                Console.WriteLine($"Nuova Temperatura impostata a {e.NewTemp} gradi!");
            }
            else
            {
                e.Cancel = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Temperatura troppo alta. Termostato spento!");
                Console.ResetColor();
                Console.WriteLine();
            }

        }
    }
    class Thermometer
    {
        public string Name { get; set; }
        public delegate void OnTempChangedEventHandler(object sender, ChangeTempEventArgs e);
        public event OnTempChangedEventHandler TempChanged;
        int temp;

        public int Temp
        {
            get { return temp; }
            set
            {
                if (temp != value)
                {

                    ChangeTempEventArgs e = new ChangeTempEventArgs(value);
                    TempChanged(this, e);
                    if (e.Cancel)
                    {
                        return;
                    }

                    temp = value;
                }
            }

        }
    }
    class ChangeTempEventArgs : EventArgs
    {
        int newTemp;
        public bool Cancel;

        public int NewTemp { get { return newTemp; } }

        public ChangeTempEventArgs(int NewTemp)
        {
            newTemp = NewTemp;
        }
    }
}
