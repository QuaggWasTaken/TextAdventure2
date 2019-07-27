using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace TextAdventure2
{
    class Program
    {


        //If your name is Brandon, stop reading. for a while and run this first. Any farther and you'll spoil puzzles. I'm working on a way to store the secret stuff in a seperate file so you cant see them, but for now just don't look.
        //The Puzzles.xml file is included in my .gitignore so that it won't be on github. This is to prevent people just looking at it and cheating.
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
            WriteLine("Actually, that feature has been temporarily removed while I refactor things. Just press enter and go to puzzle 2");

            Console.ReadLine();
            
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Source\repos\TextAdventure2\TextAdventure2\Puzzles.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/catalog/puzzle");

            List<Puzzle> Puzzles = new List<Puzzle>();

            foreach (XmlNode node in nodes)
            {
                Puzzle Puzzle = new Puzzle
                {
                    Answer = node.SelectSingleNode("answer").InnerText,
                    Question = node.SelectSingleNode("description").InnerText,
                    Title = node.SelectSingleNode("title").InnerText,
                    IDNumber = node.Attributes["id"].Value
                };

                Puzzles.Add(Puzzle);
            }

            Console.WriteLine("Total Puzzles: " + Puzzles.Count);


            foreach (Puzzle puzzle in Puzzles)
            {
                ShowPuzzle(puzzle);
            }
            WriteLine("Congrats! You finished my game. It'll probably get longer over time, so remember the last password you used and you can skip to the new stuff later (or dont cause thats not a thing right now)");

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
        static void ShowPuzzle(Puzzle puzzle)
        {

            string input;
            do
            {
                Console.Clear();
                WriteLine(puzzle.Title);
                WriteLine("");
                WriteLine(puzzle.Question);

                input = Console.ReadLine().ToLower();
            } while (input != puzzle.Answer);
        }


    }
    class Puzzle
    {
        public string IDNumber { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Title { get; set; }
    }
}
