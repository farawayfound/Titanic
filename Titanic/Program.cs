using System.Collections.Generic;
using System.Linq;
using System;

namespace Titanic
{
   public class Program
   {
      static void Main(string[] args)
      {
         List<Passenger> passengers = Titanic.GetPassengers("Titanic.Tsv");

            // Intro: The line of code above reads in a file that contains all of
            //        the passengers who were on the Titanic. Feel free to look at
            //        the Passenger class to see which fields each Passenger
            //        contains. The file is read into a List of Passengers.

            // ToDo: Write code using LInQ in order to find the answers to the
            //       following questions.

            // 1) Find out whether a "Miss. Alice Cleaver" survived the accident.
            Console.WriteLine("Did Alice Survive?");
            var alice = from p in passengers
                        where p.Name.Contains("Cleaver")
                        select new { survived = p.Survived };
            foreach (var a in alice)
                Console.WriteLine(a);

            // 2) There were six 52-year-olds on board, however, only one embarked
            //    from Cherbourg (C). What was his or her name? Did he or she
            //    survive?

            Console.WriteLine("52 year old from Cherbourg");
            var fiftyTwo = from p in passengers
                           where p.Embarked == 'C' && p.Age == 52
                           select new { name = p.Name, survived = p.Survived };
            foreach (var b in fiftyTwo)
                Console.WriteLine(b);

            // 3a) How many men were on board?

            decimal men = (from p in passengers
                           where p.Gender == 'M'
                           select p).Count();
            Console.WriteLine($"Total Men on board: {men}");

            // 3b) How many men survived?

            decimal menS = (from p in passengers
                            where p.Gender == 'M' && p.Survived == true
                            select p).Count();
            Console.WriteLine($"Total Men survived: {menS}");

            // 3c) What was the survival rate of men?

            Console.WriteLine($"Men Survival Rate: {decimal.Truncate((menS / men) * 100)} percent");

            // ToDo (Hint): Implement the getSurvivalRate method below.

            // 4a) How many women were on board?

            decimal women = (from p in passengers
                             where p.Gender == 'F'
                             select p).Count();
            Console.WriteLine($"Total Women on board: {women}");

            // 4b) How many women survived?

            decimal womenS = (from p in passengers
                              where p.Gender == 'W' && p.Survived == true
                              select p).Count();
            Console.WriteLine($"Total Women survived: {womenS}");

            // 4c) What was the survival rate of women?

            Console.WriteLine($"Women Survival Rate: {decimal.Truncate((womenS / women) * 100)} percent");

            // 5a) How many children were on board?

            decimal children = (from p in passengers
                                where p.Age < 18
                                select p).Count();
            Console.WriteLine($"Total Children on board: {children}");

            // 5b) How many children survived?

            decimal childrenS = (from p in passengers
                                 where p.Age < 18 && p.Survived == true
                                 select p).Count();
            Console.WriteLine($"Total Children survived: {childrenS}");

            // 5c) What was the survival rate of children?

            Console.WriteLine($"Children Survival Rate: {decimal.Truncate((childrenS / children) * 100)} percent");

            // 6a) Who was the youngest survivor? (name)

            var youngest = (from p in passengers
                            where p.Age < 18 && p.Survived == true
                            orderby p.Age ascending
                            select new { name = p.Name, age = p.Age }).First();
            Console.WriteLine($"Youngest survivor: {youngest}");

            // 6b) Who was the oldest casualty? (name)

            var oldest = (from p in passengers
                            where p.Age > 52 && p.Survived == false
                            orderby p.Age descending
                            select new { name = p.Name, age = p.Age }).First();
            Console.WriteLine($"Oldest casualty: {oldest}");

            // 7a) Who had the cheapest ticket? (name) Did they survive?

            var cheapest = (from p in passengers
                            where p.Fare < 10
                            orderby p.Fare ascending
                            select new { name = p.Name, survived = p.Survived, fare = p.Fare}).First();
            Console.WriteLine($"Cheapest ticket: {cheapest}");

            // 7b) Who had the most expensive ticket? (name) Did they survive?

            var expensive = (from p in passengers
                            where p.Fare > 100
                            orderby p.Fare descending
                            select new { name = p.Name, survived = p.Survived, fare = p.Fare }).First();
            Console.WriteLine($"Most expensive ticket: {expensive}");

            // 8a) What was the survival rate for all first class passengers?

            var firstClass = from p in passengers
                                 where p.Class == 1
                                 select p;
            Console.WriteLine($"First Class survival rate: {getSurvivalRate(firstClass)} percent");

            // 8b) What was the survival rate for all second class passengers?

            var secondClass = from p in passengers
                             where p.Class == 2
                             select p;
            Console.WriteLine($"Second Class survival rate: {getSurvivalRate(secondClass)} percent");

            // 8c) What was the survival rate for all third class passengers?

            var thirdClass = from p in passengers
                              where p.Class == 3
                              select p;
            Console.WriteLine($"Second Class survival rate: {getSurvivalRate(thirdClass)} percent");

            // 9) What was the survival rate of girls in first class with 2 or
            //    more of any relative?

            var secondClassGirlsR = from p in passengers
                              where p.Class == 2 && p.Age < 18 && (p.ParentsChildren + p.SiblingsSpouse) > 2
                              select p;
            Console.WriteLine($"Second Class girls with 2+ relatives survival rate: {getSurvivalRate(secondClassGirlsR)} percent");

            // 10) What was the survival rate of men in third class with no
            //     relatives onboard?

            var thirdClassMenNoR = from p in passengers
                             where p.Class == 3 && p.Age > 18 && (p.ParentsChildren + p.SiblingsSpouse) == 0
                             select p;
            Console.WriteLine($"Second Class men with no relatives survival rate: {getSurvivalRate(thirdClassMenNoR)} percent");

            // 11) What was the survival rate of passengers who embarked from
            //     Southampton (S) and whose fare was over 10 pounds?

            var southampton = from p in passengers
                             where p.Embarked == 'S' && p.Fare > 10
                             select p;
            Console.WriteLine($"Second Class survival rate: {getSurvivalRate(thirdClass)} percent");

            // 12) What was the survival rate of passengers with the word "sink"
            //     in their name? (case insensitive)

            // 13) What was the survival rate of passengers whose ticket number
            //     included the substring "13"?

        } // end Main( )

        private static double getSurvivalRate(IEnumerable<Passenger> passengers)
      {
         double survivalRate = 0.0;

            double survive = (from p in passengers
                              where p.Survived == true
                              select p).Count();
            double total = passengers.Count();

            survivalRate = (survive / total) * 100;

            return Math.Truncate(survivalRate);
      } // end getSurvivalRate( )
   }
}
