using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab1OOPsfinal
{
    class Person
    {
        //I have used the list to make my code efficient and tried to make the output clear by using
        //console.writeline to produce line spaces between every part 

        //CREATING ATTRIBUTES
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColour { get; set; }
        public int Age { get; set; }
        public bool IsWorking { get; set; }

        //DEFINING FUNCTIONS
        public void DisplayPersonInfo()
        {
            Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite colour is {FavoriteColour}");
        }

        public void ChangeFavoriteColour()
        {
            FavoriteColour = "White";
        }

        public int GetAgeInTenYears()
        {
            return Age + 10;
        }

        public override string ToString()
        {
            return $"PersonId: {PersonId}\nFirstName: {FirstName}\nLastName: {LastName}\nFavoriteColour: {FavoriteColour}\nAge: {Age}\nIsWorking: {IsWorking}\n";
        }
    }
    class Relation
    {
        //creating attributes
        public enum RelationshipType { Sister, Brother, Mother, Father }
        public RelationshipType RType { get; set; }

        //defining function
        public void ShowRelationship(Person person1, Person person2)
        {
            Console.WriteLine($"Relationship between {person1.FirstName} and {person2.FirstName} is: {RType}hood");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //part a
            //object creation
            Person person1 = new Person
            {
                PersonId = 1,
                FirstName = "Ian",
                LastName = "Brooks",
                FavoriteColour = "Red",
                Age = 30,
                IsWorking = true
            };

            Person person2 = new Person
            {
                PersonId = 2,
                FirstName = "Gina",
                LastName = "James",
                FavoriteColour = "Green",
                Age = 18,
                IsWorking = false
            };

            Person person3 = new Person
            {
                PersonId = 3,
                FirstName = "Mike",
                LastName = "Briscoe",
                FavoriteColour = "Blue",
                Age = 45,
                IsWorking = true
            };

            Person person4 = new Person
            {
                PersonId = 4,
                FirstName = "Mary",
                LastName = "Beals",
                FavoriteColour = "Yellow",
                Age = 28,
                IsWorking = true
            };

            //part b
            Console.WriteLine("Gina's information:");
            person2.DisplayPersonInfo();
            Console.WriteLine();

            //part c
            Console.WriteLine("Mike's information as a list:");
            Console.WriteLine(person3.ToString());
            Console.WriteLine();

            //part d
            person1.ChangeFavoriteColour();
            Console.WriteLine("Ian's information after changing favourite color");
            person1.DisplayPersonInfo();
            Console.WriteLine();    

            //part e
            int marysAgeInTenYears = person4.GetAgeInTenYears();
            Console.WriteLine($"Mary Beals's Age in 10 years is: {marysAgeInTenYears}");
            Console.WriteLine();

            //part f
            Relation relation1 = new Relation { RType = Relation.RelationshipType.Sister };
            Relation relation2 = new Relation { RType = Relation.RelationshipType.Brother };
            relation1.ShowRelationship(person2, person4);
            relation2.ShowRelationship(person1, person3);
            Console.WriteLine();

            //part g
            List<Person> peopleList = new List<Person> { person1, person2, person3, person4 };
            List<Person> peopleWithFirstNameM = new List<Person>();
            List<Person> peopleWithBlueFav = new List<Person>();


            double sumOfAges = 0;
            Person youngest = null;
            int minAge = int.MaxValue;
            Person oldest = null;
            int maxAge = int.MinValue;

            foreach (Person person in peopleList)
            {
                //calculating sum of ages
                sumOfAges += person.Age;

                //finding youngest person
                if (person.Age < minAge)
                {
                    minAge = person.Age;
                    youngest = person;
                }
                //finding oldest person
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldest = person;
                }
                //finding people starting with "M"
                if (person.FirstName.StartsWith("M"))
                {
                    peopleWithFirstNameM.Add(person);
                }
                //finding people who like "blue" color
                if (person.FavoriteColour.Equals("Blue"))
                {
                    peopleWithBlueFav.Add(person);
                }
            }

            double averageAge = sumOfAges / peopleList.Count;

            Console.WriteLine($"Average age is: {averageAge}");
            Console.WriteLine();

            Console.WriteLine($"The youngest person is: {youngest.FirstName}");
            Console.WriteLine($"The oldest person is: {oldest.FirstName}");
            Console.WriteLine();

            Console.WriteLine("People whose first names start with M:");
            foreach (Person person in peopleWithFirstNameM)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("People whose favourite color is 'Blue':");
            foreach (Person person in peopleWithBlueFav)
            {
                Console.WriteLine(person.ToString());
            }
            Console.ReadLine();
        } 
    }
}
