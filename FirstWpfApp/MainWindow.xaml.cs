using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // Events and others...

        private double firstNumber;
        private double lastNumber;
        private char doSmth;
        private bool IsOperationCalled;
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultTextBox.Text == "0" || IsOperationCalled) resultTextBox.Clear();
            if ((sender as Button).Content.ToString() == "," && resultTextBox.Text.Length == 0) resultTextBox.Text = "0";
            resultTextBox.Text += (sender as Button).Content;

            IsOperationCalled = false;
        }

        private void DoButton_Click(object sender, RoutedEventArgs e)
        {
            IsOperationCalled= true;
            showTextBox.Text = resultTextBox.Text;
            showTextBox.Text += (sender as Button).Content;
            doSmth = Char.Parse((sender as Button).Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (showTextBox.Text.Length == 0) return;

            if (showTextBox.Text.Last() == '=')
                showTextBox.Text = resultTextBox.Text + doSmth + lastNumber;
            else
            {
                showTextBox.Text += resultTextBox.Text;
            }
            showTextBox.Text += (sender as Button).Content;

            string[] numbers = showTextBox.Text.Split('+', '-', '/', '*','=');
            if (numbers.Length <= 1) return;

            firstNumber = double.Parse(numbers[0]);
            lastNumber = double.Parse(numbers[1]);

            switch (doSmth)
            {
                case '+':
                    resultTextBox.Text = (lastNumber + firstNumber).ToString();
                    break;
                case '-':
                    resultTextBox.Text = (firstNumber - lastNumber).ToString();
                    break;
                case '*':
                    resultTextBox.Text = (firstNumber * lastNumber).ToString();
                    break;
                case '/':
                    if (lastNumber != 0)
                        resultTextBox.Text = (firstNumber / lastNumber).ToString();
                    else
                    {
                        resultTextBox.Text = "Division by zero is illegal!";
                        IsOperationCalled = true;
                        showTextBox.Clear();
                    }                   
                    break;


                default:
                    MessageBox.Show("Fatal error! Call a programmer!");

                    break;
            }
        }


        // < 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (resultTextBox.Text.Length == 1)
            {
                resultTextBox.Text = "0";
                return;
            }
            resultTextBox.Text = resultTextBox.Text.Remove(resultTextBox.Text.Length - 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            doSmth = default;
            IsOperationCalled = false;
            showTextBox.Clear();
            resultTextBox.Text="0";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (showTextBox.Text.Last() == '=')
                Button_Click_2(this,new RoutedEventArgs());
            resultTextBox.Text="0";
        }
    }
}
