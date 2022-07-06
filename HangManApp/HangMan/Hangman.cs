using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public static class Hangman
    {
        public static string globalWord { get; set; }
        public static char globalLetter { get; set; }
        public static List<string> globalBlanks { get; set; }
        public static List<char> listLetter = new();
        public static int live = 7;
        public static int countNumber = 0;
        public static void RandomWord()
        {
            Random random = new Random();
            string choosenWord = String.Empty;
            List<string> words = new List<string> { "hello", "caar" };
            int index = random.Next(words.Count);

            choosenWord = words[index];
            //Console.Write($"Choosen Word: {choosenWord}");
            Console.WriteLine();

            globalWord = choosenWord;
            assingBlanks(choosenWord);

        }

        public static void assingBlanks(string word)
        {
            List<string> blanks = new List<string>();
            foreach (var letter in word)
            {
                blanks.Add("_");
            }

            globalBlanks = blanks;
            showBlanks(blanks);
        }

        public static void showBlanks(List<string> blanks)
        {
            foreach (var blank in blanks)
            {
                Console.Write(blank + " ");
            }
            Console.WriteLine();
        }

        public static void askUser()
        {

            string letter;

            Console.Write("Choose a Letter: ");
            letter = Console.ReadLine().ToLower();

            char finalLetter = char.Parse(letter);
            globalLetter = finalLetter;

            
            compareLetters(globalWord, globalLetter, globalBlanks);

        }

        public static void compareLetters(string word, char letter, List<string> blanks)
        {

            try
            {

                foreach (var item in word)
                {

                    int index = globalWord.IndexOf(letter);
                    if (globalBlanks.Contains(letter.ToString()))
                    {
                        index++;
                    }

                    if (item.Equals(letter))
                    {
                        countNumber++;
                        globalBlanks[index] = letter.ToString();
                        listLetter.Add(letter);
                        showFinalWord();
                    }

                }

                if (live > 0)
                {
                    live = live - 1;
                    wrongAnswer(live);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a letter please.");
                askUser();
            }

        }

        public static void wrongAnswer(int live)
        {

            switch (live)
            {
                case 6:
                    Console.WriteLine("O");
                    showFinalWord();
                    break;
                case 5:
                    Console.WriteLine("O");
                    Console.WriteLine("|");
                    showFinalWord();
                    break;
                case 4:
                    Console.WriteLine(" O");
                    Console.WriteLine(@"/|");
                    showFinalWord();
                    break;
                case 3:
                    Console.WriteLine(" O");
                    Console.Write(@"/");
                    Console.WriteLine(@"|\");
                    showFinalWord();
                    break;
                case 2:
                    Console.WriteLine(" O");
                    Console.Write(@"/");
                    Console.WriteLine(@"|\");
                    Console.WriteLine(@"/");
                    showFinalWord();
                    break;
                case 1:
                    Console.WriteLine(" O");
                    Console.Write(@"/");
                    Console.WriteLine(@"|\");
                    Console.Write(@"/ \");
                    Console.WriteLine();
                    Console.WriteLine("Game Over!!");
                    Environment.Exit(0);
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Game Over!!!");
                    break;
            }
        }

        public static void showFinalWord()
        {
            Console.WriteLine();

            foreach (var item in globalBlanks)
            {

                Console.Write(item + " ");
            }

            Console.WriteLine();

            if (countNumber == globalWord.Length)
            {
                Console.WriteLine("Congrats you Win!!!");
                Console.WriteLine($"The choosen word is: {globalWord}");
                Environment.Exit(0);
            }
            else
            {
                askUser();
            }

        }
    }
}
