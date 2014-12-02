using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeChallenge3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* 
         * Description:
         * 
         * Search for all the numbers in a string.  Add them together.  Return that final number divided by the total amount of letters in the string.
         * Hello6 9World 2, Nic8e D7ay! ===> output should be 2 = 32/17 = 1.88 round up to the nearest whole number
         * may have multiple digits as well as negative numbers
        */
        public MainWindow()
        {
            InitializeComponent();
            txtTextToProcess.Text = "Hello6 9World 2, Nic8e D7ay!";
        }

        /// <summary>
        /// Searches a given string for all the whole numbers, adds them together, and divids that number the total number of letters in the string.
        /// </summary>
        /// <param name="text">The string to be processed.</param>
        /// <param name="lblShowWrk">The Label control on which to display the calculation work done.</param>
        /// <returns>The final number divided by the total amount of letters in the string rounded up to the nearest whole number.</returns>
        private int processString(string text, ref Label lblShowWrk)
        {
            int total = 0;
            int letterCount = 0;
            string numberPattern = @"(-\d+|\d+|[A-z]+)"; //split the given text by groups of whole numbers (positive or negative) and letters.
            string[] splitText = Regex.Split(text, numberPattern);
            foreach (string piece in splitText)
            {
                if(Regex.Match(piece, "^" + @"(-\d+|\d+)" + "$").Success) //A number (positive or negative)
                {
                    total += int.Parse(piece);
                    //changes the adding of negative numbers to subtraction
                    lblShowWrk.Content += (!string.IsNullOrEmpty((string)lblShowWrk.Content) ? (piece.StartsWith("-") ? piece.Replace("-", " - ") : " + " + piece) : "(" + piece);
                }
                else if (Regex.Match(piece, "^" + "[A-z]+" + "$").Success) //A letter
                {
                    letterCount += piece.Length;
                }
            }
            lblShowWrk.Content += string.Format(") / {0} => {1} / {0}", letterCount, total);
            return divideByNumLetters(total, letterCount);
        }

        private int divideByNumLetters(Decimal numberTotal, Decimal letterCount)
        {
            Decimal number = Math.Round(numberTotal / letterCount, 0);
            string txt = number.ToString();
            return int.Parse(txt);
        }

        /// <summary>
        /// Processes the text entered by the user into the text box.
        /// </summary>
        /// <param name="sender">The Process Text Button</param>
        /// <param name="e">The event</param>
        private void btnProcess_Click_1(object sender, RoutedEventArgs e)
        {
            lblFinal.Content = "";
            lblShowWork.Content = "";
            lblShowWork.Foreground = Brushes.Black;
            if (!string.IsNullOrEmpty(txtTextToProcess.Text))
            {
                try
                {
                    lblFinal.Content = "" + processString(txtTextToProcess.Text, ref lblShowWork);
                }
                catch (Exception ex)
                {
                    lblShowWork.Content += ". " + ex.Message;
                    lblShowWork.Foreground = Brushes.Red;
                }
            }
            else
            {
                lblShowWork.Foreground = Brushes.Red;
                lblShowWork.Content = "Must have text to process.";
            }
        }
    }
}
