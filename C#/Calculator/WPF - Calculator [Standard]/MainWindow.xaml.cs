using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF___combined__Calculator_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public partial class MainWindow : Window
    {
        private string _operation = String.Empty;
        private bool _equalsPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!_equalsPressed)
            {
                Button button = (Button)sender;
                
                string tmpOperation = _operation + button.Content;

                if (ValidationCheck(tmpOperation, _operation))
                {
                    _operation = ResultTextBox.Text + button.Content;
                    ResultTextBox.Text = _operation;
                }
            }
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_equalsPressed &&
                    _operation != String.Empty &&
                    !_operation.EndsWith('+') &&
                    !_operation.EndsWith('-') &&
                    !_operation.EndsWith('*') &&
                    !_operation.EndsWith('/'))
                {
                    string result = Calculator(_operation);
                    ResultTextBox.Text = ResultTextBox.Text + " = " + result;
                    _equalsPressed = true;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Ungültige Rechnung!\n\n"+ ex.ToString());
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = String.Empty;
            _operation = String.Empty;
            _equalsPressed = false;
        }

        private static string Calculator(string operation)
        {
            DataTable dataTable = new DataTable();
            object resultObj = dataTable.Compute(operation, null);

            double result = Convert.ToDouble(resultObj);

            if (Double.IsNaN(result) ||
                Double.IsInfinity(result) ||
                operation.StartsWith("0.0") ||
                operation.StartsWith("-0.0") ||
                operation.EndsWith("0.0") ||
                operation.EndsWith("-0.0"))
            {
                return "ERR";
            }

            result = Math.Round(result, 2);

            return result.ToString("G", new System.Globalization.CultureInfo("en-US"));
        }
        
        private static bool ValidationCheck(string tmpOperation, string operation)
        {
            string numberPattern = @"-?\d+(\.\d{0,3})?";
            string operatorPattern = @"[\+\-\*/]";
            string combinedPattern = $@"^({numberPattern}|{operatorPattern})+$";
            string pointCalcTypeRow = @"(\.\.|\+\+|--|\*\*|//)";
            string symbolsRow = @"(\.\+|\+\.|\-\+|\+\-|\*\+|\+\*|\/\+|\+\/|\.\-|\-\.)";
            string calcTypeRow = @"[\+\-\*/]{2,}";


            if (string.IsNullOrEmpty(operation))
            {
                return Regex.IsMatch(tmpOperation, numberPattern) || tmpOperation == "-";
            }
            else if (!Regex.IsMatch(tmpOperation, combinedPattern))
            {
                return false;
            }
            else if (Regex.IsMatch(tmpOperation, pointCalcTypeRow))
            {
                return false; 
            }
            else if (Regex.IsMatch(tmpOperation, symbolsRow))
            {
                return false; 
            }
            else if (Regex.IsMatch(tmpOperation, calcTypeRow))
            {
                return false;
            }

            return true;
        }
    }
}
