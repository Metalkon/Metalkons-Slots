using System;
using System.Media;


namespace Slot_machine

{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;

            SoundPlayer jackpot = new SoundPlayer(@"Music\Jackpot.wav");
            SoundPlayer kaching = new SoundPlayer(@"Music\Kaching.wav");
            SoundPlayer music = new SoundPlayer(@"Music\Music.wav");

            music.PlayLooping();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Welcome to Metalkon's Shitty Slot Machine Game!");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("How much virtual cash would you like to start the game with? \n(Every spin will cost you $5 and you must match 3 numbers to win a prize)");
            Console.Write("\nInsert Starting Amount: ");
            string userResponse = (Console.ReadLine()); Console.Clear();
            while (!Int32.TryParse(userResponse, out _) || Convert.ToInt32(userResponse) < 0)
            {
                Console.WriteLine("\nEnter ONLY numbers PLEASE!\n");
                userResponse = Console.ReadLine();
            }
            int cash = Convert.ToInt32(userResponse);
            Console.WriteLine($"[ {num1} ] - [ {num2} ] - [ {num3} ]\n[ {num4} ] - [ {num5} ] - [ {num6} ]\n[ {num7} ] - [ {num8} ] - [ {num9} ]");
            string response = null;
            Random RandomNumber = new Random();
            for (; ; )
            {
                if (Convert.ToInt32(cash) <= 0)
                {
                    Console.WriteLine("You're now broke. GAME OVER");
                    Console.Read();
                    break;
                }
                Console.WriteLine($"\nCash Remaining = ${cash}");
                Console.Write("Would you like to spin? (y/n or just press enter)");
                response = Console.ReadLine();
                if (response == "n")
                {
                    break;
                }
                else
                {
                    cash = cash - 5;
                    num1 = RandomNumber.Next(1, 8);
                    num2 = RandomNumber.Next(1, 8);
                    num3 = RandomNumber.Next(1, 8);
                    num4 = RandomNumber.Next(1, 8);
                    num5 = RandomNumber.Next(1, 8);
                    num6 = RandomNumber.Next(1, 8);
                    num7 = RandomNumber.Next(1, 8);
                    num8 = RandomNumber.Next(1, 8);
                    num9 = RandomNumber.Next(1, 8);

                    Console.Clear();
                    Console.WriteLine($"[ {num1} ] - [ {num2} ] - [ {num3} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);
                    Console.WriteLine($"[ {num4} ] - [ {num5} ] - [ {num6} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);
                    Console.WriteLine($"[ {num7} ] - [ {num8} ] - [ {num9} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);
                    if ((num1 == num2 && num2 == num3 && (num1 != 7)) || (num4 == num5 && num5 == num6 && (num4 != 7)) || (num7 == num8 && num8 == num9 && (num7 != 7)) || (num1 == num5 && num5 == num9 && (num7 != 7)) || (num3 == num5 && num5 == num7 && (num7 != 7)))
                    {
                        cash += 25;
                        Console.WriteLine("Congratulations, you've won $25!"); System.Threading.Thread.Sleep(350);
                        music.Stop();
                        kaching.PlaySync();
                        music.PlayLooping();
                    }
                    else if ((num1 == num2 && num2 == num3 && (num1 >= 7)) || (num4 == num5 && num5 == num6 && (num4 >= 7)) || (num7 == num8 && num8 == num9 && (num7 >= 7)) || (num1 == num5 && num5 == num9 && (num7 >= 7)) || (num3 == num5 && num5 == num7 && (num7 >= 7)))
                    {
                        cash += 350;
                        Console.WriteLine("JACKPOT LUCKY 7's, you've won $350!"); System.Threading.Thread.Sleep(350);
                        music.Stop();
                        jackpot.PlaySync();
                        music.PlayLooping();
                    }
                    else
                    {
                        Console.WriteLine("Better luck next time!");
                    }
                }
            }
        }
    }
}