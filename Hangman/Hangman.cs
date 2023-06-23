using System;
using System.Collections.Generic;
namespace Hangman;
public static class Hangmanstart
{
    public static void Main()
    {
        string[] words = { "car", "bike", "bus" };
        string selectedWord = GetRandomWord(words);
        char[] Letters = new char[selectedWord.Length];
        int attempts = 5;
        int correctGuesses = 0;
        List<char> list = new List<char>();


        while (attempts > 0 && correctGuesses < selectedWord.Length)
        {
            Console.WriteLine();
            Console.WriteLine("Attempts left: " + attempts);
            Console.WriteLine("Current word: " + GetWordWithGuesses(selectedWord, Letters));

            Console.Write("Enter a letter: ");
            char letter = Console.ReadLine()[0];

            if (list.Contains(letter))
            {
                attempts++;
                Console.WriteLine("You have already guessed that letter. Try again.");
                
            }

            list.Add(letter);

            bool isCorrectGuess = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == letter)
                {
                    if (Letters[i] != letter)
                    {
                        Letters[i] = letter;
                        correctGuesses++;
                        isCorrectGuess = true;
                    }
                }
            }


           

            if (!isCorrectGuess)
            {
                attempts--;
                Console.WriteLine("Incorrect guess!");
            }
        }

        if (correctGuesses == selectedWord.Length)
        {
            Console.WriteLine("You guessed the word: " + selectedWord);
        }
        else
        {
            Console.WriteLine("The word was: " + selectedWord);
        }


        Console.ReadKey();
    }

    static string GetRandomWord(string[] words)
    {
        Random random = new Random();
        int index = random.Next(0, words.Length);
        return words[index];
    }

    static string GetWordWithGuesses(string word, char[] Letters)
    {
        string line = "";
        for (int i = 0; i < word.Length; i++)
        {
            if (Letters[i] == 0)
            {
                line += "_";
            }
            else
            {
                line += Letters[i];
            }
        }
        return line;
    }
}