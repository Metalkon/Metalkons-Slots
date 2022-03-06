using System;
using System.Media;


namespace Slot_Machine
{
    class Program

    {
        static void Main()
        {
            int num1 = 0; int num2 = 0; int num3 = 0;
            int num4 = 0; int num5 = 0; int num6 = 0;
            int num7 = 0; int num8 = 0; int num9 = 0;
            ConsoleHelper.SetCurrentFont("Consolas", 18); Console.Clear();
            SoundPlayer jackpot = new SoundPlayer(@"Music\Jackpot.wav");
            SoundPlayer kaching = new SoundPlayer(@"Music\Kaching.wav");
            SoundPlayer music = new SoundPlayer(@"Music\Music.wav");
            music.PlayLooping();

            Title();
            Console.WriteLine("How much virtual cash would you like to start the game with?");
            Console.Write("Insert Starting Amount ($1000 Limit): ");
            string userResponse = (Console.ReadLine());
            while (!Int32.TryParse(userResponse, out _) || Convert.ToInt32(userResponse) < 0)
            {
                Console.WriteLine("Enter ONLY numbers PLEASE!");
                Console.Write("Insert Starting Amount ($1000 Limit): ");
                userResponse = Console.ReadLine();

            }
            if (Convert.ToInt32(userResponse) > 1000)
            {
                Console.WriteLine("That's too much!");
                Console.Write("Insert Starting Amount ($1000 Limit): ");
                userResponse = Console.ReadLine();
            }
            Console.Write($"Insert Bid (${userResponse} Limit): ");
            string userResponse2 = (Console.ReadLine());
            while (!Int32.TryParse(userResponse2, out _) || Convert.ToInt32(userResponse2) < 0)
            {
                Console.WriteLine("Enter ONLY numbers PLEASE!");
                Console.Write($"\nInsert Bid (${userResponse} Limit): ");
                userResponse = Console.ReadLine();
                Console.Clear();

            }
            if (Convert.ToInt32(userResponse2) > Convert.ToInt32(userResponse))
            {
                Console.WriteLine("That's too much!");
                Console.Write($"\nInsert Bid (${userResponse} Limit): ");
                userResponse = Console.ReadLine();
                Console.Clear();
            }

            int cash = Convert.ToInt32(userResponse);
            int bid = Convert.ToInt32(userResponse2);
            Title();
            Console.WriteLine($"\t  [ {num1} ] - [ {num2} ] - [ {num3} ]\n\t  [ {num4} ] - [ {num5} ] - [ {num6} ]\n\t  [ {num7} ] - [ {num8} ] - [ {num9} ]");
            string response = null;
            Random RandomNumber = new Random();
            for (; ; )
            {
                if (Convert.ToInt32(cash) < bid)
                {
                    Console.WriteLine("You're now broke. GAME OVER");
                    Console.Read();
                    break;
                }
                Console.WriteLine($"\nCash Remaining = ${cash} (Current Bid ${bid})");
                Console.Write("Would you like to spin again? (press enter)");
                response = Console.ReadLine();
                if (response == "n")
                {
                    break;
                }
                else
                {
                    cash = cash - bid;
                    num1 = RandomNumber.Next(1, 8); num2 = RandomNumber.Next(1, 8); num3 = RandomNumber.Next(1, 8);
                    num4 = RandomNumber.Next(1, 8); num5 = RandomNumber.Next(1, 8); num6 = RandomNumber.Next(1, 8);
                    num7 = RandomNumber.Next(1, 8); num8 = RandomNumber.Next(1, 8); num9 = RandomNumber.Next(1, 8);

                    Console.Clear();
                    Title();
                    Console.WriteLine($"\t  [ {GetCharacter(num1)} ] - [ {GetCharacter(num2)} ] - [ {GetCharacter(num3)} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);
                    Console.WriteLine($"\t  [ {GetCharacter(num4)} ] - [ {GetCharacter(num5)} ] - [ {GetCharacter(num6)} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);
                    Console.WriteLine($"\t  [ {GetCharacter(num7)} ] - [ {GetCharacter(num8)} ] - [ {GetCharacter(num9)} ]"); Console.Beep(); System.Threading.Thread.Sleep(350);

                    // Note: Replace if with switch
                    if ((num1 == num2 && num2 == num3 && (num1 != 8)) || (num4 == num5 && num5 == num6 && (num4 != 8)) || (num7 == num8 && num8 == num9 && (num7 != 8)) || (num1 == num5 && num5 == num9 && (num7 != 8)) || (num3 == num5 && num5 == num7 && (num7 != 8)))
                    {
                        cash += 5 * bid;
                        Console.WriteLine($"\n\t  Congratulations, you've won ${5 * bid}!");
                        music.Stop();
                        kaching.PlaySync();
                        music.PlayLooping();
                    }
                    else if ((num1 == num2 && num2 == num3 && (num1 >= 8)) || (num4 == num5 && num5 == num6 && (num4 >= 8)) || (num7 == num8 && num8 == num9 && (num7 >= 8)) || (num1 == num5 && num5 == num9 && (num7 >= 8)) || (num3 == num5 && num5 == num7 && (num7 >= 8)))
                    {
                        cash += 75 * bid;
                        Console.WriteLine($"\n\t  JACKPOT LUCKY 7's, you've won {75 * bid}!");
                        music.Stop();
                        jackpot.PlaySync();
                        music.PlayLooping();
                    }
                    else
                    {
                        Console.WriteLine("\n\t  Better luck next time!");
                    }
                }
            }
        }
        public static char GetCharacter(int num)
        {
            switch (num)
            {
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '♠';
                case 5: return '♥';
                case 6: return '♦';
                case 7: return '♣';
                case 8: return '7';
                default: return '\0';
            }
        }
        public static void Title()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║  Metalkon's Shitty Slot Machine Game!  ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");
        }
    }
}