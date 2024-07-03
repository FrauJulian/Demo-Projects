namespace DemoProject
{
    class Program
    {
        enum CalculationTypes
        {
            Addidieren,
            Subtrahieren,
            Multiplizieren,
            Dividieren
        }

        enum AgainYN
        {
            Ja,
            Nein
        }

        static void Main()
        {
            Calculator();

        }

        static void Calculator()
        {
            double result;

            var types = Enum.GetNames(typeof(CalculationTypes));
            int pos = DropdownFunc(types, false);

            Console.WriteLine("Gib die erste Zahl deiner Rechnung an:");
            double Num1 = NumValidation();
            Console.Clear();

            Console.WriteLine("Gib die zweite Zahl deiner Rechnung an:");
            double Num2 = NumValidation();
            Console.Clear();

            switch (pos)
            {
                case 0:
                    result = Num1 + Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " + " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 1:
                    result = Num1 - Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " - " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 2:
                    result = Num1 * Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " * " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case 3:
                    result = Num1 / Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " / " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
            }
        }

        private static double NumValidation()
        {
            double Number;

            while (!double.TryParse(Console.ReadLine(), out Number))
            {
                Console.WriteLine("Deine Eingabe ist ungültig, bitte gib eine Zahl an!");
            }

            return Number;
        }

        private static void CalculateAgain()
        {
            Console.ReadLine();

            var types = Enum.GetNames(typeof(AgainYN));
            int pos = DropdownFunc(types, true);

            if (pos == 0)
            {
                Calculator();
            } 
            else
            {
                return;
            }
        }

         private static int DropdownFunc(string[] Options, bool again)
         {
            int OptionPosition = 0;
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


                for (int i = 0; i < Options.Length; i++)
                {
                    if (i == OptionPosition)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($" {Options[i]} ");
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        OptionPosition = Math.Max(0, OptionPosition - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        OptionPosition = Math.Min(Options.Length - 1, OptionPosition + 1);
                        break;
                    case ConsoleKey.Enter:
                        menuOpen = false;
                        Console.Clear();
                        return OptionPosition;
                }

            }
            return 0;
        }
    }
}
