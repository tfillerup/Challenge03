using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge3 {

    public partial class frmMain : Form {

        string[] LETTERS = { "a", "b", "c", "d", "e", 
                           "f", "g", "h", "i", "j", 
                           "k", "l", "m", "n", "o", 
                           "p", "q", "r", "s", "t", 
                           "u", "v", "w", "x", "y", 
                           "z" };

        string[] NUMBERS = { "0", "1", "2", "3", "4", 
                           "5", "6", "7", "8", "9","." };

        string[] SYMBOLS = { "-", "." };

        public frmMain() {
            InitializeComponent();

            txtData.Focus();
        }

        private void txtData_TextChanged(object sender, EventArgs e) {
            lblResult.Text = getResult(txtData.Text).Output();
        }

        private Results getResult(string text) {

            Results results = new Results();

            string number = string.Empty;

            List<string> numbers = new List<string>();

            foreach (char c in text) {

                if (NUMBERS.Contains(c.ToString())) {
                    number += c.ToString();
                } else if (SYMBOLS.Contains(c.ToString())) {

                    if (c == '-') {
                        if (!string.IsNullOrEmpty(number)) {
                            numbers.Add(number);
                            number = string.Empty;
                        }
                    }

                    number += c.ToString();
                } else {

                    if (!string.IsNullOrEmpty(number) && number != "-") {
                        numbers.Add(number);
                    }
                    number = string.Empty;
                }

                if (LETTERS.Contains(c.ToString().ToLower())) {
                    results.Letters += c.ToString();
                }
            }

            if (!string.IsNullOrEmpty(number) && number != "-") {
                numbers.Add(number);
            }

            foreach (string num in numbers) {

                results.NumberEquation += string.IsNullOrEmpty(results.NumberEquation) ? "" : " + ";
                results.NumberEquation += (decimal.Parse(num) < 0) ? string.Format("({0})", num) : num;

                results.NumberSum += decimal.Parse(num);
            }

            return results;
        }

    }

    public class Results {

        public Results() { }

        public string NumberEquation { get; set; }
        public decimal NumberSum { get; set; }
        public string Letters { get; set; }

        public int GetTheResult() {

            if (Letters.Count() > 0) {
                return (int)Math.Round(NumberSum / Letters.Count(), 0);
            } else {
                return 0;
            }
        }

        public string Output() {

            string msg = string.Empty;

            msg = string.Format("Number Equation: {0}{1}", NumberEquation, Environment.NewLine);
            msg += string.Format("Number Sum: {0}{1}", NumberSum, Environment.NewLine);
            msg += string.Format("Letters: {0}{1}", Letters, Environment.NewLine);
            msg += string.Format("Letter Count: {0}{1}", Letters.Count(), Environment.NewLine);
            msg += string.Format("Equation: ({0}) / {1}{2}", NumberEquation, Letters.Count(), Environment.NewLine);
            msg += string.Format("Result: {0}{1}", GetTheResult(), Environment.NewLine);

            return msg;
        }
    }
}
