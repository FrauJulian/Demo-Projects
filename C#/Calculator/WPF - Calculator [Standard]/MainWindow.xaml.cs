using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WPF___Calculator__Standard_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _operation = "-0";
        private bool _equalsPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_equalsPressed)
                {
                    if (!_operation.EndsWith("+") ||
                        !_operation.EndsWith("-") ||
                        !_operation.EndsWith("*") ||
                        !_operation.EndsWith("/") ||
                        !_operation.EndsWith(","))
                    {
                        Button button = (Button)sender;

                        _operation = resultTextBox.Text + button.Content;
                        resultTextBox.Text = Convert.ToString(_operation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EqualsClick(object sender, RoutedEventArgs e)
        {
            if (!_equalsPressed)
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

        static decimal Calculator(string operation)
        {
            DataTable dataTable = new DataTable();
            object result = dataTable.Compute(operation, null);
            return Convert.ToDecimal(result);
        }
    }
}