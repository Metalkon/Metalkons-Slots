using System;
using System.Media;


namespace Slot_Machine
{
    class Program

    {
        public static void Title()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║  Metalkon's Shitty Slot Machine Game!  ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");
        }
        static void Main()
        {
            ConsoleHelper.SetCurrentFont("Consolas", 20); Console.Clear();
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
                userResponse2 = Console.ReadLine();
            }
            if (Convert.ToInt32(userResponse2) > Convert.ToInt32(userResponse2))
            {
                Console.WriteLine("That's too much!");
                Console.Write($"\nInsert Bid (${userResponse} Limit): ");
                userResponse2 = Console.ReadLine();
            }

            // note: gotta figure out how to fix the stuff above.
            int cash = Convert.ToInt32(userResponse);
            int bid = Convert.ToInt32(userResponse2);

            Title();
            Console.WriteLine($"\t  [ 7 ] - [ 7 ] - [ 7 ]\n\t  [ 7 ] - [ 7 ] - [ 7 ]\n\t  [ 7 ] - [ 7 ] - [ 7 ]");
            string response;
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
                Console.Write("Would you like to spin? (press enter)");
                response = Console.ReadLine();
                if (response == "n")
                {
                    break;
                }
                else
                {
                    cash = cash - bid;
                    int[] num = new int[9];
                    num[0] = RandomNumber.Next(1, 9); num[1] = RandomNumber.Next(1, 9); num[2] = RandomNumber.Next(1, 9);
                    num[3] = RandomNumber.Next(1, 9); num[4] = RandomNumber.Next(1, 9); num[5] = RandomNumber.Next(1, 9);
                    num[6] = RandomNumber.Next(1, 9); num[7] = RandomNumber.Next(1, 9); num[8] = RandomNumber.Next(1, 9);
                    Title();
                    Console.WriteLine($"\t  [ {GetCharacter(num[0])} ] - [ {GetCharacter(num[1])} ] - [ {GetCharacter(num[2])} ]"); Console.Beep(); System.Threading.Thread.Sleep(250);
                    Console.WriteLine($"\t  [ {GetCharacter(num[3])} ] - [ {GetCharacter(num[4])} ] - [ {GetCharacter(num[5])} ]"); Console.Beep(); System.Threading.Thread.Sleep(250);
                    Console.WriteLine($"\t  [ {GetCharacter(num[6])} ] - [ {GetCharacter(num[7])} ] - [ {GetCharacter(num[8])} ]"); Console.Beep(); System.Threading.Thread.Sleep(250);


                    if ((num[0] == num[1] && num[1] == num[2] && (num[0] == 8)) // SEVENS JACKPOT
                         || (num[3] == num[4] && num[4] == num[5] && (num[3] >= 8))
                         || (num[6] == num[7] && num[7] == num[8] && (num[6] >= 8))
                         || (num[0] == num[4] && num[4] == num[8] && (num[6] >= 8))
                         || (num[2] == num[4] && num[4] == num[6] && (num[6] >= 8))
                         || (num[0] == num[3] && num[3] == num[6] && (num[0] >= 8))
                         || (num[1] == num[4] && num[4] == num[7] && (num[1] >= 8))
                         || (num[2] == num[5] && num[5] == num[8] && (num[2] >= 8)))
                    {
                        cash += 75 * bid;
                        Console.WriteLine($"\nJACKPOT LUCKY 7's, you've won {75 * bid}!");
                        music.Stop(); jackpot.PlaySync(); music.PlayLooping();
                    }

                    else if ((num[0] == num[1] && num[1] == num[2] && (num[0] >= 4 && num[0] != 8)) // SPADES/CLUBS/HEARTS/DIAMONDS
                        || (num[3] == num[4] && num[4] == num[5] && (num[3] >= 4 && num[3] != 8))
                        || (num[6] == num[7] && num[7] == num[8] && (num[6] >= 4 && num[6] != 8))
                        || (num[0] == num[4] && num[4] == num[8] && (num[0] >= 4 && num[0] != 8))
                        || (num[2] == num[4] && num[4] == num[6] && (num[2] >= 4 && num[2] != 8))
                        || (num[0] == num[3] && num[3] == num[6] && (num[0] >= 4 && num[0] != 8))
                        || (num[1] == num[4] && num[4] == num[7] && (num[1] >= 4 && num[1] != 8))
                        || (num[2] == num[5] && num[5] == num[8] && (num[2] >= 4 && num[2] != 8)))
                    {
                        cash += 5 * bid;
                        Console.WriteLine($"\nCongratulations, you've won ${5 * bid}!");
                        music.Stop(); kaching.PlaySync(); music.PlayLooping();
                    }
                    else if ((num[0] == num[1] && num[1] == num[2] && (num[0]< 4)) // NUMBERS 1-3
                        || (num[3] == num[4] && num[4] == num[5] && (num[3] < 4))
                        || (num[6] == num[7] && num[7] == num[8] && (num[6] < 4))
                        || (num[0] == num[4] && num[4] == num[8] && (num[0] < 4))
                        || (num[2] == num[4] && num[4] == num[6] && (num[2] < 4))
                        || (num[0] == num[3] && num[3] == num[6] && (num[0] < 4))
                        || (num[1] == num[4] && num[4] == num[7] && (num[1] < 4))
                        || (num[2] == num[5] && num[5] == num[8] && (num[2] < 4)))
                    {
                        cash += 3 * bid;
                        Console.WriteLine($"\nCongratulations, you've won ${3 * bid}!");
                        music.Stop(); kaching.PlaySync(); music.PlayLooping();
                    }
                    else
                    {
                        Console.WriteLine("\nBetter luck next time!");
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

    }
}