using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Claculator : Form
    {
        double value = 0;
        string operation = "";
        bool operation_pressed = false;
        public Claculator()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (result.Text == "0" || (operation_pressed))
                result.Clear();
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
            operation_pressed = false;
        }
        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = double.Parse(result.Text);
            operation_pressed = true;
        }

        private void Equal_Operation(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result.Text = (value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;
                case "Binary":
                    int intValue = Convert.ToInt32(value);
                    result.Text = ConvertToBinary(intValue);
                    break;
                case "Decimal":
                    int binaryValue = Convert.ToInt32(value);
                    result.Text = ConvertToDecimal(binaryValue);
                    break;
                case "sqrt":
                    result.Text = Math.Sqrt(value).ToString();
                    break;
                case "sqr":
                    result.Text = (value*value).ToString();
                    break;
                case "AND":
                    int andValue1 = Convert.ToInt32(value);
                    int andValue2 = Convert.ToInt32(result.Text);
                    result.Text = (andValue1 & andValue2).ToString();
                    break;
                case "OR":
                    int orValue1 = Convert.ToInt32(value);
                    int orValue2 = Convert.ToInt32(result.Text);
                    result.Text = (orValue1 | orValue2).ToString();
                    break;
                case "XOR":
                    int xorValue1 = Convert.ToInt32(value);
                    int xorValue2 = Convert.ToInt32(result.Text);
                    result.Text = (xorValue1 ^ xorValue2).ToString();
                    break;
                default:
                    break;
            }
            operation_pressed = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        public string ConvertToBinary(int number)
        {
            var result = "";
            int i = 0;
            while (number > 0)
            {
                var reminder = number % 2;
                number = number / 2;
                i++;
                result = reminder.ToString() + result;
            }
            return result;

        }
        public string ConvertToDecimal(int number)
        {
            int reminder, decimalValue = 0, baseValue = 1;
            while (number > 0)
            {
                reminder = number % 10;
                decimalValue = decimalValue + reminder * baseValue;
                number = number / 10;
                baseValue = baseValue * 2;
            }
            return decimalValue.ToString();
        }

    }
}
