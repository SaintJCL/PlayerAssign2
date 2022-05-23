using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

using Pa2.Models;

namespace PlayerAssign2
{

    class Program
    {

        static void Main(string[] args)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$"; //E-mail pattern to check for invalids

            Console.WriteLine("Enter the number of human players");
            int plNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Now enter the number of bots");
            int botNum = Int32.Parse(Console.ReadLine());
            Infantry[] players = new Infantry[plNum];
            Bot[] bots = new Bot[botNum];

            for (int i = 0; i < plNum; i++) //Player inputs their information.
            {
                players[i] = new Infantry();

                Console.WriteLine("Enter the data for Player " + (i + 1) + ", as prompted. \n Name: ");
                players[i].Name = Console.ReadLine();
                Console.WriteLine("Age:");
                players[i].Age = Int32.Parse(Console.ReadLine());
                do
                {                                  //Checks to see if the e-mail entered is valid.
                    Console.WriteLine("E-mail:");
                    players[i].Email = Console.ReadLine();

                    if (!Regex.IsMatch(players[i].Email, pattern))
                        Console.Write("VALID E-mail, you blockhead.");
                }
                while (!Regex.IsMatch(players[i].Email, pattern));

            }

            Random rand = new Random();
            for (int i = 0; i < botNum; i++) //Fill the bots with data.
            {
                bots[i] = new Bot(rand.Next(4));
            }

                Console.WriteLine("would you like to print the data to file? Press y for yes. If not, \n press another key+ Enter");
            if (Console.ReadKey().Equals('y'))
            {
                using (StreamWriter sw = new StreamWriter("PlayerData.txt"))
                {
                    foreach (Infantry p in players)
                    {
                        p.PrintPlayerStats();
                    }

                    foreach (Bot p in bots)
                    {
                        p.PrintPlayerStats();
                    }
                }

                // Read and show each line from the file.
                string line = "";
                using (StreamReader sr = new StreamReader("PlayerData.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

            }

        }

   
    }

}
