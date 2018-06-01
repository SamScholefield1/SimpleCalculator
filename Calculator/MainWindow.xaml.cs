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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int value1;
        private int value2;
        private string Op;
        private int checker = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDigit(string digit)
        {
            if (textField.Text == "0")
            {
                textField.Text = digit;
            }
            else
            {
                textField.Text += digit;
            }
        }

        private void buttonNumber_Click(object sender, RoutedEventArgs e)
        {

            // Each Button (0 to 9) must have it's Tag property set to the relevant number
            string buttonNumberText = Convert.ToString(((FrameworkElement)sender).Tag);
            AddDigit(buttonNumberText);
            
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textField.Text = "0";
            value1 = 0;
            value2 = 0;
            checker = 0;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

            Op = "+";

            if (checker == 0)
            {
                storeNumbers.Add(Convert.ToInt32(textField.Text));
                textField.Text = "0";
                checker = 1;
            }
            else if (checker == 1)
            {
                if(textField.Text == "0")
                {

                }
                else
                {
                    int finalValue = 0;
                    storeNumbers.Add(Convert.ToInt32(textField.Text));

                    foreach (int value in storeNumbers)
                    {
                        finalValue = finalValue + value;
                    }

                    textField.Text = "0";
                    storeNumbers.Clear();
                    storeNumbers.Add(finalValue);
                    checker = 0;
                }
               
            }
           
        }

        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {
            int finalValue = 0;

            if (Op == "+")
            {
                storeNumbers.Add(Convert.ToInt32(textField.Text));

                foreach (int value in storeNumbers)
                {
                    finalValue = finalValue + value;
                }
            }


            textField.Text = finalValue.ToString();
            storeNumbers.Clear();
            storeNumbers.Add(finalValue);
        }
    }
}
