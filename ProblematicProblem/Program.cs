using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace ProblematicProblem
{
    class program
    {
        static Random rng = new Random();
        
       

             
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
           
            
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string verification = Console.ReadLine();

            if (verification == "Yes")
            {
                cont = true;
            }

            if (verification == "No")
            {
                cont = false;
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Ah, welcome {userName}!");

            Console.Write("What is your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());

            if (userAge <= 17 ){
                Console.WriteLine("Wow You're young.");
            }

            if (userAge >= 25 )
            {
                Console.WriteLine("Sorry,Only Zoomers are permitted. No Millenials, x'ers or Boomers allowed... Kidding. :p Come in.");
            }

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string seeList = Console.ReadLine();

            if (seeList == "Yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var addToList = Console.ReadLine();
                Console.WriteLine();

                while (addToList.ToLower() == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine();
                }
            }
            
            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    

                     randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];

                    activities.Remove(randomActivity);
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
        

                if (Console.ReadLine().ToLower() == "redo")
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }

                
            }
        }
    }
}
