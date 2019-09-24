using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\time.txt";
            List<string> time = new List<string>();
            int i;

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    i = 0;
                    do
                    {
                        time.Add(sr.ReadLine());
                        i++;
                    }
                    while ((time[i-1] != null));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Nie mozna odczytać pliku: {file}");
                Console.WriteLine(e.Message);
            }

            //SUMA
            TimeSpan timeSpanSuma = new TimeSpan();
            int hoursFromDays = 0;
            int hours = 0;
            int minutes = 0;
            int status = 1;

            foreach (var item in time)
            {
                if (item != null)
                {
                    try
                    {
                        DateTime dateTime = DateTime.ParseExact(item, "H:mm", CultureInfo.InvariantCulture);
                        hours = dateTime.Hour;
                        minutes = dateTime.Minute;
                        TimeSpan timeSpan = new TimeSpan(hours, minutes, 0);
                        timeSpanSuma += timeSpan;
                        status = 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Błąd podczas pobierania danych z pliku: ");
                        Console.WriteLine(e.Message);
                        status = 0;
                        break;
                    }
                }
            }
            if (status == 1)
            {
                hoursFromDays = timeSpanSuma.Days * 24 + timeSpanSuma.Hours;
                Console.WriteLine(hoursFromDays + "h " + timeSpanSuma.Minutes.ToString() + "min");
            }
            Console.ReadKey();
        }
    }
}

