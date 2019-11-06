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
        bool operationPressed = false;
       // bool operationStatus = false;
        public Claculator()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (operationPressed)
                result.Clear();
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
            operationPressed = false;
        }
        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = double.Parse(result.Text);
            operationPressed = true;

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
                case "pow":
                    result.Text = Math.Pow(value, double.Parse(result.Text)).ToString();
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
                    var andValue1 = Convert.ToByte(value);
                    var andValue2 = Convert.ToByte(result.Text);
                    var andResult= (andValue1 & andValue2);
                    result.Text = andResult.ToString();
                    break;
                case "OR":
                    var orValue1 = Convert.ToByte(value);
                    var orValue2 = Convert.ToByte(result.Text);
                    var orResult = (orValue1 | orValue2);
                    result.Text = orResult.ToString();
                    break;
                case "XOR":
                    var xorValue1 = Convert.ToByte(value);
                    var xorValue2 = Convert.ToByte(result.Text);
                    var xorResult = (xorValue1 ^ xorValue2);
                    result.Text = xorResult.ToString();
                    break;
                default:
                    break;
            }
            operationPressed = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
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
