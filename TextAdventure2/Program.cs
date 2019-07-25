using System;
using System.Threading;

namespace TextAdventure2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("This is a puzzle game, and it probably won't be easy.");
            WriteLine("This website should help: https://cryptii.com/");
            WriteLine("Some of the puzzles here will be cryptological, some won't. Most will give a hint to help. ");
            WriteLine("All you have to do is use the information given and then put in the password to get to the next puzzle.");
            WriteLine("Passwords will always be either one word or a number less than 2.1 billion.");
            WriteLine("First, I need you to tell me your name");
            string PlayerName = Console.ReadLine();
            WriteLine($"Nice to meet you {PlayerName}, I'm your host for the next while.");
            WriteLine("Press enter to continue...");
            Console.ReadLine();
            string input;
            do
            {
                Console.Clear();
                WriteLine("This first one is simple. Here's your hint: lhenveyo. \nThat website I linked will probably help. \n(Ignore foreign characters, it seems to be a bit bugged if you include them)");
                WriteLine("Just input the password on this line once you have it. I'll repeat the question if you get it wrong.");
                input = Console.ReadLine();
            } while (input != "password");

            Console.Clear();
            WriteLine("Congrats. You passed the intro level. \nThe enigma machine is pretty cool, isn't it. Germany really did go all out with their cryptology. \nFrom here I'll let you skip forward if you know a future password. \nIf you don't, just say continue and we'll go to puzzle number 2.");
            bool validInput = false;
            int destination;
            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "continue":
                        destination = 2;
                        validInput = true;
                        break;
                    case "Brutus":
                        destination = 3;
                        validInput = true;
                        break;
                    default:
                        destination = 2;
                        break;
                }
            } while (!validInput);
            Destination:
            Console.Clear();
            switch (destination)
            {
                case 2:
                    Puzzle2();
                    break;
                default:
                    goto Finish;
            }
            destination++;
            goto Destination;
            Finish:
            WriteLine("Congrats! You finished my game. It'll probably get longer over time, so remember the last password you used and you can skip to the new stuff later.");
        }
        static void Puzzle2()
        {
            string input;
            do
            {
                WriteLine("So, this one won't be as much of a giveaway. You might have to brute force it a bit. Here's your hint: Euxwxv.");

                input = Console.ReadLine();
            } while (input != "Brutus");
        }
        static void WriteLine(string input)
        {
            foreach (char letter in input)
            {
                Console.Write(letter);
                Thread.Sleep(5);
            }
            Console.Write("\n");
        }
    }
}
