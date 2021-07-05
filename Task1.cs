using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            
            var customerFromJson = JsonConvert.DeserializeObject<List<MovieStar>>(File.ReadAllText("input.txt"));
            foreach (var obj in customerFromJson)
            {
                Console.WriteLine(obj.Name + " " + obj.Surname);
                Console.WriteLine(obj.SEX);
                Console.WriteLine(obj.Nationality);
                DateTime dateOfBirth = Convert.ToDateTime(obj.dateOfBirth);
                Console.WriteLine(GetAge(dateOfBirth) + " Years Old");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var T = (today.Year * 100 + today.Month) * 100 + today.Day;
            var DOB = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (T - DOB) / 10000;
        }
    }
    
    public class MovieStar
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string dateOfBirth { get; set; }
        public string SEX { get; set; }
        public string Nationality { get; set; }

    }
}
