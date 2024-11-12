using Enums;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            Calculator();
        }

        private static void Calculator()
        {
            decimal result;

            string[] type = Enum.GetNames(typeof(CalculationType));
            int position = DropdownFunction(type, false);

            Console.WriteLine("Gib die erste Zahl deiner Rechnung an:");
            decimal num1 = NumberValidation();
            Console.Clear();

            Console.WriteLine("Gib die zweite Zahl deiner Rechnung an:");
            decimal num2 = NumberValidation();
            Console.Clear();

            switch (position)
            {
                case 0:
                    result = num1 + num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + num1 + " + " + num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 1:
                    result = num1 - num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + num1 + " - " + num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 2:
                    result = num1 * num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + num1 + " * " + num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 3:
                    result = num1 / num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + num1 + " / " + num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
            }
        }

        private static decimal NumberValidation()
        {
            decimal number;

            while (!decimal.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Deine Eingabe ist ungültig, bitte gib eine Zahl an!");
            }

            return number;
        }

        private static void CalculateAgain()
        {
            Console.ReadLine();

            var type = Enum.GetNames(typeof(AgainAnswers));
            int position = DropdownFunction(type, true);

            if (position == 0)
            {
                Calculator();
            }
            else
            {
                return;
            }
        }

        private static int DropdownFunction(string[] options, bool again)
        {
            int option = 0;
            bool menuOpen = true;

            while (menuOpen)
            {
                Console.Clear();

                if (again)
                {
                    Console.WriteLine("Lust auf noch eine Rechnung?");
                }
                else
                {
                    Console.WriteLine("Gib an welche Rechenart du nutzen möchtest für deine Rechnung!");
                }


                for (int i = 0; i < options.Length; i++)
                {
                    if (i == option)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($" {options[i]} ");
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = Math.Max(0, option - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        option = Math.Min(options.Length - 1, option + 1);
                        break;
                    case ConsoleKey.Enter:
                        menuOpen = false;
                        Console.Clear();
                        return option;
                }

            }
            return 0;
        }
    }
}