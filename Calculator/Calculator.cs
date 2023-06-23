namespace Calculator
{
    public static class CalculatorStart
    {
        public static void RunCalculator()
        {

            Console.WriteLine();
            Console.WriteLine("Calculator");
            Console.WriteLine("------------");
            int a = 1;
            while (a > 0)
            {



                Console.WriteLine("Enter the first number:");
                double num1;
               
             
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.WriteLine();
                    
                    continue;
                }

                bool Result = true;
                Console.WriteLine("Enter an arithmetic operation (+, -, *, /)");
                string operation = Console.ReadLine();
                if (operation != "+" && operation != "-"&& operation != "*"&& operation != "/")
                {
                    Console.WriteLine("wrong arithmetic operition");
                    Console.WriteLine(  );
                    continue;
                }
               

                Console.WriteLine("Enter the second number:");
                double num2;
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Division by zero is not allowed.");

                        }
                        result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
               
                  Console.WriteLine("Result: " + result);
                    a--;
                
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();



        }
    }
}
