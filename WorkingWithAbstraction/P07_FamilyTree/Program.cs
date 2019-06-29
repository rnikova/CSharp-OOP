using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();

            Person mainPerson = Person.CreatePerson(personInput);

            familyTree.Add(mainPerson);

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson = familyTree
                        .FirstOrDefault(p => p.Birthday == firstPerson || p.Name == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = Person.CreatePerson(firstPerson);

                        familyTree.Add(currentPerson);
                    }

                        SetChild(familyTree, currentPerson, secondPerson);
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree
                        .FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }

                    person.Name = name;
                    person.Birthday = birthday;

                    Person copyPerson = familyTree
                        .Where(p => p.Name == name || p.Birthday == birthday)
                        .Skip(1)
                        .FirstOrDefault();

                    if (copyPerson != null)
                    {
                        familyTree.Remove(copyPerson);
                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        foreach (var parent in copyPerson.Parents)
                        {
                            ReplaceDublicate(person, copyPerson, parent.Children);          
                        }

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();

                        foreach (var child in copyPerson.Children)
                        {
                            ReplaceDublicate(person, copyPerson, child.Parents);                        
                        }
                    }
                }
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");

            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Children:");

            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static void ReplaceDublicate(Person person, Person copyPerson, List<Person> people)
        {
            int copyPersonIndex = people.IndexOf(copyPerson);

            if (copyPersonIndex > -1)
            {
                people[copyPersonIndex] = person;
            }
            else
            {
                people.Add(person);
            }
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string childInput)
        {
            var child = familyTree
                .FirstOrDefault(c => c.Name == childInput || c.Birthday == childInput);

            if (child == null)
            {
                child = Person.CreatePerson(childInput);
                familyTree.Add(child);
            }

            parentPerson.Children.Add(child);
            child.Parents.Add(parentPerson);
        }
    }
}
