using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Demos\Text.txt";

            //IT WILL READ THE FILE loop through it
            //List<string> lines = File.ReadAllLines(filePath).ToList();

            //foreach(var line in lines){
            //    Console.WriteLine(line);
            //}
            //lines.Add("Xman, storm, welcome.com");
            //THAT CAN WRITE TO FILE
            //File.WriteAllLines(filePath, lines);


            //creating a list of type pErson
            
            List<Person> people = new List<Person>();
            //reading lines
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach(var line in lines)
            {
                //an array containing string and then assigning them
                string[] entries = line.Split(',');
                Person newPerson = new Person();
                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.Url= entries[2];
                people.Add(newPerson);
            }

            Console.WriteLine("read from txt file");

            foreach(var person in people)
            {
                Console.WriteLine($"{person.FirstName}");
            }

            people.Add(new Person { FirstName = "John", LastName = "Smith", Url = "hey.com" });

            List<string> output = new List<string>();
            foreach(var person in people)
            {
                output.Add($"{person.FirstName} {person.LastName} {person.Url}");
            }
            Console.WriteLine("writing to text file");

            File.WriteAllLines(filePath, output);
            Console.ReadLine();

            
        }
    }
}
