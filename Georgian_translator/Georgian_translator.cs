using System.Text;

namespace GeorgianTranslator
{
    public static class Georgian_translator
    {

        public static void RunGeorgian_translator()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Dictionary<char, char> myDictionary = new Dictionary<char, char>
                {
                {'a', 'ა'},
                {'b', 'ბ'},
                {'g', 'გ'},
                {'d', 'დ'},
                {'e', 'ე'},
                {'v', 'ვ'},
                {'z', 'ზ'},
                {'T', 'თ'},
                {'i', 'ი'},
                {'k', 'კ'},
                {'l', 'ლ'},
                {'m', 'მ'},
                {'n', 'ნ'},
                {'o', 'ო'},
                {'p', 'პ'},
                {'J', 'ჟ'},
                {'r', 'რ'},
                {'s', 'ს'},
                {'t', 'ტ'},
                {'u', 'უ'},
                {'f', 'ფ'},
                {'q', 'ქ'},
                {'R', 'ღ'},
                {'y', 'ყ'},
                {'S', 'შ'},
                {'C', 'ჩ'},
                {'c', 'ც'},
                {'Z', 'ძ'},
                {'w', 'წ'},
                {'W', 'ჭ'},
                {'x', 'ხ'},
                {'j', 'ჯ'},
                {'h', 'ჰ'}
                };

            Console.WriteLine();
            Console.WriteLine("Georgian Translator");
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter the text :");



            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (myDictionary.ContainsKey(input[i]) == true)
                {
                    Console.Write(myDictionary[input[i]]);
                }
                else
                {
                    Console.Write(input[i]);
                }

            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

    }
}