
namespace DemoProject
{
    class Program
    {
        static void Main()
        {
            Calculator();
        }

        static void CalculateAgain()
        {
            string[] AnswerTypes = {
                "Ja",
                "Nein"
            };
            int AnswerString = 0;
            bool menuOpen = true;
            bool Answer = true;

            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine("Lust auf noch eine Rechnung?");

                for (int i = 0; i < AnswerTypes.Length; i++)
                {
                    if (i == AnswerString)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($" {AnswerTypes[i]} ");
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        AnswerString = Math.Max(0, AnswerString - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        AnswerString = Math.Min(AnswerTypes.Length - 1, AnswerString + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (AnswerTypes[AnswerString])
                        {
                            case "Ja":
                                Answer = true;
                                break;
                            case "Nein":
                                Answer = false;
                                break;
                        }

                        menuOpen = false;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }

            } while (menuOpen);

            while (Answer)
            {
                Calculator();
            }
            
        }

        static void Calculator()
        {
            string[] CalculationTypes = {
                "addidieren",
                "subtrahieren",
                "multiplizieren",
                "dividieren"
            };
            int CalculateType = 0;
            bool menuOpen = true;
            double result;

            do
            {
                Console.Clear();
                Console.WriteLine("Gib an welche Rechenart du nutzen möchtest für deine Rechnung! (Wechsle mit den Pfeiltasten!)");

                for (int i = 0; i < CalculationTypes.Length; i++)
                {
                    if (i == CalculateType)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.WriteLine($" {CalculationTypes[i]} ");
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        CalculateType = Math.Max(0, CalculateType - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        CalculateType = Math.Min(CalculationTypes.Length - 1, CalculateType + 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        menuOpen = false;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }

            } while (menuOpen);

            Console.WriteLine("Gib die erste Zahl deiner Rechnung an:");
            double Num1 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Gib die zweite Zahl deiner Rechnung an:");
            double Num2 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (CalculationTypes[CalculateType])
            {
                case "addidieren":
                    result = Num1 + Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " + " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case "subtrahieren":
                    result = Num1 - Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " - " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case "multiplizieren":
                    result = Num1 + Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " * " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
                case "dividieren":
                    result = Num1 + Num2;
                    Console.WriteLine("Das Ergebniss deiner Rechnung, " + Num1 + " / " + Num2 + ", ist: " + result);
                    CalculateAgain();
                    break;
            }
        }
    }
}
