using Enums;
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
        private decimal _num1;
        private decimal _num2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (numOneBox.Text != "" &&
                numTwoBox.Text != "" &&
                calculationTypeBox.Text != "")
            {
                try
                {
                    decimal.TryParse(numOneBox.Text, out _num2);
                    decimal.TryParse(numTwoBox.Text, out _num1);

                    int calculationTypePosition =
                        Array.IndexOf(
                            (CalculationType[])Enum.GetValues(typeof(CalculationType)),
                            (CalculationType)Enum.Parse(typeof(CalculationType),
                            calculationTypeBox.Text)
                            );

                    Calculator(_num1, _num2, calculationTypePosition);
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

        private void Calculator(decimal num1, decimal num2, int calculationTypePosition)
        {
            decimal result;

            switch (calculationTypePosition)
            {
                case 0:
                    result = num1 + num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + num1 + " + " + num2 + ", ist: " + result);
                    break;
                case 1:
                    result = num1 - num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + num1 + " - " + num2 + ", ist: " + result);
                    break;
                case 2:
                    result = num1 * num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + num1 + " * " + num2 + ", ist: " + result);
                    break;
                case 3:
                    result = num1 / num2;
                    MessageBox.Show("Das Ergebniss deiner Rechnung, " + num1 + " / " + num2 + ", ist: " + result);
                    break;
            }
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}