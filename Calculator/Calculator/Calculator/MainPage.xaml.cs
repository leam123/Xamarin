using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int firstNumber = 0, secondNumber = 0, result = 0;
        Stack<int> valueStack = new Stack<int>();
        Stack<Char> operatorStack = new Stack<Char>();

        public MainPage()
        {
            InitializeComponent();
        }

        bool IsDigitsOnly(string str) {
            foreach (char c in str) {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        void OnNumberClick(object sender, EventArgs e) {
            Button numberButton = (Button)sender;
            string number = numberButton.Text;

            //valueStack.Push(int.Parse(number));
            this.displayText.Text += number;
        }

        private int PrecedenceCheck(string op) {
            if (op=="*" || op == "/") 
            {
                return 1;
            }
            if (op == "+" || op == "-") 
            {
                return 0;
            }
            else
            {
                return -1;
            }
            
        }

        void OnOperatorClick(object sender, EventArgs e) { 
            Button operatorButton = (Button)sender;
            string operatorSymbol = operatorButton.Text;

            int temp;
            bool isNumber = int.TryParse(this.displayText.Text.Substring(this.displayText.Text.Length - 1), out temp);

            if (!isNumber)
            {
                this.displayText.Text = this.displayText.Text.Remove(this.displayText.Text.Length - 1) + operatorSymbol;
                operatorStack.Pop();
                operatorStack.Push(char.Parse(operatorSymbol));
            }
            else
            {
                int currentOp = PrecedenceCheck(operatorSymbol);

                valueStack.Clear();

                string text = this.displayText.Text;
                string[] values = text.Split(new char[] { '+', '-', '*', '/' });

                foreach (string val in values)
                {
                    valueStack.Push(int.Parse(val));
                }


                if (!operatorStack.Any())
                {
                    operatorStack.Push(char.Parse(operatorSymbol));
                    this.displayText.Text += operatorSymbol;

                    //this.resultText.Text = operatorStack.Peek().ToString();
                }
                else
                {
                    string getStackOp = operatorStack.Peek().ToString();
                    int oldOp = PrecedenceCheck(getStackOp);

                    if (currentOp > oldOp)
                    {
                        operatorStack.Push(char.Parse(operatorSymbol));
                        this.displayText.Text += operatorSymbol;

                        //this.resultText.Text = operatorStack.Peek().ToString();
                    }
                    if (currentOp <= oldOp)
                    {
                        while (operatorStack.Count() != 0)
                        {
                            if (currentOp <= oldOp)
                            {
                                firstNumber = valueStack.Peek();
                                valueStack.Pop();
                                string x = operatorStack.Peek().ToString();
                                operatorStack.Pop();
                                secondNumber = valueStack.Peek();
                                valueStack.Pop();

                                if (x == "+")
                                {
                                    result = firstNumber + secondNumber;
                                    valueStack.Push(result);
                                }
                                if (x == "-")
                                {
                                    result = firstNumber - secondNumber;
                                    valueStack.Push(result);
                                }
                                if (x == "*")
                                {
                                    result = firstNumber * secondNumber;
                                    valueStack.Push(result);
                                }
                                if (x == "/")
                                {
                                    result = firstNumber / secondNumber;
                                    valueStack.Push(result);
                                }
                            }
                            else
                            {
                                getStackOp = operatorStack.Peek().ToString();
                                oldOp = PrecedenceCheck(getStackOp);
                            }
                            //getStackOp = operatorStack.Peek().ToString();
                            //oldOp = PrecedenceCheck(getStackOp);
                        }
                        operatorStack.Push(char.Parse(operatorSymbol));
                        this.displayText.Text += operatorSymbol;
                    }
                    //this.resultText.Text = valueStack.Peek().ToString();

                }
            }
            
        }

        void ShowPeakValue(object sender,  EventArgs e) {
            int peak = valueStack.Peek();
            this.displayText.Text = peak.ToString();
        }

        void ClearStack(object sender, EventArgs e) { 
            valueStack.Clear();
            operatorStack.Clear();

            this.displayText.Text = "";
            this.resultText.Text = "";
        }

        void OnPopValue(object sender, EventArgs e) {
            int val;
            bool isNumber = int.TryParse(this.displayText.Text.Substring(this.displayText.Text.Length - 1), out val);

            if (!isNumber)
            {
                if (operatorStack.Count() == 0)
                {
                    this.displayText.Text = this.displayText.Text.Remove(this.displayText.Text.Length - 1);
                }
                else
                {
                    this.displayText.Text = this.displayText.Text.Remove(this.displayText.Text.Length - 1);
                    operatorStack.Pop();
                }
            }
            else {
                if (valueStack.Count() == 0)
                {
                    this.displayText.Text = this.displayText.Text.Remove(this.displayText.Text.Length - 1);
                }
                else
                {
                    //valueStack.Pop();
                    this.displayText.Text = this.displayText.Text.Remove(this.displayText.Text.Length - 1);
                    valueStack.Pop();
                }
            }
        }

        void OnPushValue(object sender, EventArgs e)
        {
            string text = this.displayText.Text.Substring(this.displayText.Text.Length - 1);
            int val;
            bool isNumber = int.TryParse(text, out val);

            if (!isNumber)
            {
                operatorStack.Push(char.Parse(text));
            }
            else
            {
                valueStack.Push(int.Parse(text));
            }
        }

        void CalculateResult(object sender, EventArgs e) {

            //this.resultText.Text = "=Result displayed here";

            //valueStack.Clear();

            //string text = this.displayText.Text;
            //string[] values = text.Split(new char[] { '+', '-', '*', '/' });

            //foreach (string val in values)
            //{
            // valueStack.Push(int.Parse(val));
            // }

            int val;
            bool isNumber = int.TryParse(this.displayText.Text.Substring(this.displayText.Text.Length - 1), out val);

            if (!isNumber) {
                this.resultText.Text = "";
            }
            else
            {
                //valueStack.Push(int.Parse(this.displayText.Text.Substring(this.displayText.Text.Length - 1)));
                int topStack = valueStack.Peek();
                valueStack.Pop();
                int recentNumber = int.Parse(this.displayText.Text.Substring(this.displayText.Text.Length - 1));
                string lastOp = operatorStack.Peek().ToString();
                operatorStack.Pop();

                if (lastOp == "+")
                {
                    result = topStack + recentNumber;
                    valueStack.Push(result);
                }
                if (lastOp == "-")
                {
                    result = topStack - recentNumber;
                    valueStack.Push(result);
                }
                if (lastOp == "*")
                {
                    result = topStack * recentNumber;
                    valueStack.Push(result);
                }
                if (lastOp == "/")
                {
                    result = topStack / recentNumber;
                    valueStack.Push(result);
                }
                this.resultText.Text = "=" + valueStack.Peek().ToString();
            }
        }

    }
}
