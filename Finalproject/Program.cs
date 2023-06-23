using Calculator;
using Guess_number;
using Hangman;
using atm;
using GeorgianTranslator;
using Translator;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Console Aplication");
            Console.WriteLine("--------------------");
            Console.WriteLine("1) Calculator");
            Console.WriteLine("2) Guess the Number");
            Console.WriteLine("3) HangMan");
            Console.WriteLine("4) Translator");
            Console.WriteLine("5) Georgian Letter Translator");
            Console.WriteLine("6) ATM");
            Console.WriteLine("7) Exit");

            Console.WriteLine("Choose Number: 1-7");
            List<int> list = new List<int>();
            string input = Console.ReadLine();
            int guess;

            if (int.TryParse(input, out guess))
            {
                list.Add(guess);
            }
            else
            {
                Console.WriteLine("please write a number:");
                Console.WriteLine();
                Console.WriteLine();
            }
            switch (input)
            {
                case "1":
                    Console.Clear();
                    CalculatorStart.RunCalculator();
                    break;
                case "2":
                    Console.Clear();
                    GuessNumberStart.RunGuessNumber();
                    break;
                case "3":
                    Console.Clear();
                  Hangmanstart.Main();
                    break;
                case "4":
                    Console.Clear();
                   
                    break;

                case "5":
                    Console.Clear();
                    Georgian_translator.RunGeorgian_translator();
                    break;
                case "6":
                    Console.Clear();
                 
                    break;  
            }
            if (input == "7")
            {
                break;
            }
            

            Console.Clear();
        }
    }
}