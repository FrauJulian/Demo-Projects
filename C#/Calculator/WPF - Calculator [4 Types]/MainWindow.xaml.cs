using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WPF___Calculator__4_Types_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        enum CalculationTypes
        {
            Addidieren,
            Subtrahieren,
            Multiplizieren,
            Dividieren
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal Num1;
            decimal Num2;

            if (NumOneBox.Text != "" &&
                NumTwoBox.Text != "" &&
                CalculationTypesBox.Text != "")
            {
                try
                {
                    Num1 = decimal.Parse(NumOneBox.Text);
                    Num2 = decimal.Parse(NumOneBox.Text);

                    int calculationTypePosition = 
                        Array.IndexOf(
                            (CalculationTypes[])Enum.GetValues(typeof(CalculationTypes)),
                            (CalculationTypes)Enum.Parse(typeof(CalculationTypes),
                            CalculationTypesBox.Text)
                            );

                    Calculator(Num1, Num2, calculationTypePosition);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ungültige eingabe! Bitte nutze ausschließlich gültige Zahlen und Rechenarten!\n\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ungültige eingabe! Bitte nutze ausschließlich gültige Zahlen und Rechenarten!");
            }
        }

        static void Calculator(decimal Num1, decimal Num2, int calculationTypePosition)
        {
            decimal result;

            switch (calculationTypePosition)
            {
                case 0:
                    result = Num1 + Num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + Num1 + " + " + Num2 + ", ist: " + result);
                    break;
                case 1:
                    result = Num1 - Num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + Num1 + " - " + Num2 + ", ist: " + result);
                    break;
                case 2:
                    result = Num1 * Num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + Num1 + " * " + Num2 + ", ist: " + result);
                    break;
                case 3:
                    result = Num1 / Num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + Num1 + " / " + Num2 + ", ist: " + result);
                    break;
            }
        }

        private void numValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}