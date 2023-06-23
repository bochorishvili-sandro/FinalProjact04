using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public class Translator
    {
        private Dictionary<string, string> translations;

        public Translator(string translationsFilePath)
        {
            translations = LoadTranslations(translationsFilePath);
        }

        public string Translate(string word)
        {
            if (translations.ContainsKey(word))
            {
                return translations[word];
            }

            return "Translation not found";
        }

        private Dictionary<string, string> LoadTranslations(string translationsFilePath)
        {
            Dictionary<string, string> translationDictionary = new Dictionary<string, string>();

            try
            {
                string[] allLines = File.ReadAllLines(translationsFilePath);

                foreach (string line in allLines)
                {
                    string[] translation = line.Split('=');

                    if (translation.Length == 2)
                    {
                        string key = translation[0].Trim();
                        string value = translation[1].Trim();

                        if (!translationDictionary.ContainsKey(key))
                        {
                            translationDictionary.Add(key, value);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Translations file not found. Please make sure the file exists.");
            }

            return translationDictionary;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string translationsFilePath = "translations.txt"; // Replace with the path to your translations file
            Translator translator = new Translator(translationsFilePath);

            Console.WriteLine("Enter a word or phrase to translate:");
            string input = Console.ReadLine();

            string translation = translator.Translate(input);
            Console.WriteLine("Translation: " + translation);

            Console.ReadLine();
        }
    }
}
