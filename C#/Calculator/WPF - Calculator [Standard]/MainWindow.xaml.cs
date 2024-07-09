using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF___Calculator__Standard_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
 
    public partial class MainWindow : Window
    {
        private string _operation = "";
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

                if (ValidNumber(Convert.ToString(button.Content)))
                {
                    _operation = resultTextBox.Text + button.Content;
                    resultTextBox.Text = Convert.ToString(_operation);
                }
            }
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            if (!_equalsPressed &&
                _operation != "")
            {
                decimal result = Calculator(_operation);
                resultTextBox.Text = resultTextBox.Text + " = " + result;
                _equalsPressed = true;
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "";
            _operation = "";
            _equalsPressed = false;
        }

        private static decimal Calculator(string operation)
        {
            DataTable dataTable = new DataTable();
            object result = dataTable.Compute(operation, null);
            return Convert.ToDecimal(result);
        }

        private static bool ValidNumber(string tmpOperation)
        {
            string regexPattern = @"^(\-)?(\d{1,6})?(\.{0,1})?(\d{1,3})?";
            return Regex.IsMatch(tmpOperation, regexPattern);
        }

        private static bool ValidCalcType(string tmpOperation)
        {
            string regexPattern = @"^(\-)?(\d)?(\.)?(\d{1,3})*([+|\-|*|\/])?((\d)?(\.)?(\d{1,3})*)*";
            return Regex.IsMatch(tmpOperation, regexPattern);
        }
    }
}
