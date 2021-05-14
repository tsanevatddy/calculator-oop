using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StandardCalculator
{
    public partial class _calculator : Form
    {
        double currentNum = 0;
        double currentValue = 0;
        private double tempAccum = 0;
        private char lstOprtion;
        
        string operations = "";
            double value = 0;
        bool pressedOperation = false;
        private double memoryStore = 0;
        double result;
        public _calculator()
        {
            InitializeComponent();
            

        }

        private void _calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            switch (e.KeyChar) //Depending on which key was pressed to enter it's value
            {
                case '0':
                    e.Handled = true;
                    bttZero.PerformClick();
                    break;
                case '1':
                    e.Handled = true;
                    bttOne.PerformClick();
                    break;
                case '2':
                    e.Handled = true;
                    bttTwo.PerformClick();
                    break;
                case '3':
                    e.Handled = true;
                    bttThree.PerformClick();
                    break;
                case '4':
                    e.Handled = true;
                    bttFour.PerformClick();
                    break;
                case '5':
                    e.Handled = true;
                    bttFive.PerformClick();
                    break;
                case '6':
                    e.Handled = true;
                    bttSix.PerformClick();
                    break;
                case '7':
                    e.Handled = true;
                    bttSeven.PerformClick();
                    break;
                case '8':
                    e.Handled = true;
                    bttEight.PerformClick();
                    break;
                case '9':
                    e.Handled = true;
                    bttNine.PerformClick();
                    break;

            }
            
        }
        
        private void bttBackSpace_Click(object sender, EventArgs e) //Deleting last number with BackSpace
        {
            if (txtResult.Text != string.Empty) 
            {
                int inputlength = txtResult.Text.Length;
                if( inputlength != 0)
                {
                    txtResult.Text = txtResult.Text.Remove(inputlength - 1);

                }
                else
                {
                    
                    txtResult.Text = 0.ToString();
                }

            }
        }

        

        private void _calculator_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
           
        }

        private void bttCE_Click(object sender, EventArgs e) //deleting the last input 
        {
         
            
                txtResult.Text = "0";
              
           
        }

        private void bttClear_Click(object sender, EventArgs e) // clear button
        {
            txtResult.Text = "";
            lblInputs.Text = String.Empty;
            
        }

        private void bttPlusMinus_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Contains("-"))
            {
                txtResult.Text = txtResult.Text.Remove(0, 1);

            }
            else
            {
                txtResult.Text = "-" + txtResult.Text;
            }
        }

        private void bttSqrt_Click(object sender, EventArgs e)
        {
        
        }

        private void button_Click(object sender, EventArgs e)
        {
            

        }
    
        private void Operator_Pressed(object sender, EventArgs e) // Operators'event to identify which operator was pressed from the calculator
        {
            
            
            char operation = (sender as Button).Text[0];

            string msg = "Cannot divide by 0!";
            double percentage = 0.01;
           
            if (operation == 'C')
            {
                tempAccum = 0;
                txtResult.Text = "0";
            }
            
            else
            {
               currentValue = double.Parse(txtResult.Text);
                lblInputs.Text = Convert.ToString(currentValue) ;

               
                switch (lstOprtion)
                {
                    case '+': tempAccum += currentValue;break;
                    case '-': tempAccum -= currentValue; break;
                    case '*': tempAccum = tempAccum * currentValue;  break;
                    case '/':
                            tempAccum = tempAccum / currentValue;
                        break;

                    case '%':tempAccum = tempAccum * (currentValue * 0.01);break;
                    case '√': tempAccum = Math.Sqrt(tempAccum); break;

                    default: tempAccum = currentValue; break;
                }
            }

            lstOprtion = operation;
            if (operation == '=')
            {

                if (double.IsPositiveInfinity(tempAccum) || double.IsNegativeInfinity(tempAccum)) //if a number was divided by 0,isntead of dispaying Infinity,display a message.
                {
                    txtResult.Text = msg;
                }
                else
                {
                    
                    txtResult.Text = tempAccum.ToString();
                   
                }
            }
            else
            {
                txtResult.Text = "0";
            }
            lblInputs.Text = String.Empty;
            lblInputs.Text = Convert.ToString(tempAccum);
            if (operation == '=')
            {
                lblInputs.Text = lblInputs.Text;
            }
            else
            {

                 lblInputs.Text += operation;
            }
            
        }

        private void Number_Pressed(object sender, EventArgs e) //Event for pressed numbers which will be displayed
        {
            
            string number = (sender as Button).Text;
            txtResult.Text = txtResult.Text == "0" ? number : txtResult.Text + number;
        }

        

        private void bttResult_Click(object sender, EventArgs e)
        {
           
        }

       

        private void result_click(object sender, EventArgs e)
        {
            txtResult.Text = tempAccum.ToString();
        }

        private void memorybtns_click(object sender, EventArgs e) //Event for memory buttons
        {
            result = tempAccum;
            Button btnMemory = (Button)sender;
            string btnText = btnMemory.Text;
            
           


            if (btnText == "MS")
            {

                memoryStore = Double.Parse(txtResult.Text);
                txtResult.Text = "0";
                bttMR.Enabled = true;
                bttMC.Enabled = true;
                return;

            }

            else if (btnText == "M-")
            {
               
                memoryStore -= result;
                txtResult.Text = memoryStore.ToString();
                txtResult.Text = "0";
                return;
            }

            else if (btnText == "M+")
            {
               

                memoryStore += result;
                txtResult.Text = memoryStore.ToString();
                txtResult.Text = "0";
                return;

            }
            
           
            else if (btnText == "MC")
            {
                
                this.memoryStore = 0;
                bttMC.Enabled = false;
                 bttMR.Enabled = false;
                txtResult.Text = "0";
                return;
            }
            else if (btnText == "MR")
            {

                txtResult.Text = memoryStore.ToString();
                return;
            }
            else
            {
                txtResult.Text = "0";
            }






        }

        private void button6_Click(object sender, EventArgs e) // adding decimal point
        {
            if (txtResult.Text.Contains("."))
            {
                txtResult.Text = txtResult.Text;
            }

            else
            {
                txtResult.Text = txtResult.Text + ".";
            }


        }

        private void button15_Click(object sender, EventArgs e) //dividing 1 by the number
        {
            if (txtResult.Text != string.Empty)
            {

                double reciprNum = Convert.ToDouble("1") / Convert.ToDouble(txtResult.Text);
                txtResult.Text = reciprNum.ToString();

            }

        }

        private void _calculator_KeyDown(object sender, KeyEventArgs e) //Event for keyboard opeator keys
        {
            if ((Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.D8)|| ( e.KeyCode == Keys.Multiply)) //implementation of the multiply operator
            {
                e.Handled = true;
                bttMultyplication.PerformClick();
            }
            else if( e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)//implementation of the devision operator
            {
                e.Handled = true;
                bttDevision.PerformClick();
            }
            else if ( e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)//implementation of the additon operator
            {
                e.Handled = true;
                bttAddition.PerformClick();
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)//implementation of the substraction operator
            {
                e.Handled = true;
                bttSubstraction.PerformClick();
            }
            else if (Control.ModifierKeys == Keys.Enter)//implementation of the enter key
            {
                e.Handled = true;
                bttResult.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)//implementation of the backspace 
            {
                if (txtResult.Text != string.Empty)
                {
                    int inputlength = txtResult.Text.Length;
                    if (inputlength != 0)
                    {
                        txtResult.Text = txtResult.Text.Remove(inputlength - 1);

                    }
                    else
                    {
                        txtResult.Text = 0.ToString();
                    }

                }
              
            }
            else if (e.KeyCode == Keys.Delete)//implementation of the delete operator
            {
                e.Handled = true;
                bttClear.PerformClick();
            }



        }

        private void lblInputs_Click(object sender, EventArgs e)
        {
            if (lstOprtion != '0')
            {
              lblInputs.Text = txtResult.Text + lstOprtion;

            }
        }

        private void bttPowr(object sender, EventArgs e)// x^2 operator
        {

            if (txtResult.Text != string.Empty)
            {
                double temp = Convert.ToDouble(txtResult.Text);
                double pwr = Math.Pow(temp, 2);
                txtResult.Text = pwr.ToString();
                lblInputs.Text = txtResult.Text;

            }
        }
    }
}
