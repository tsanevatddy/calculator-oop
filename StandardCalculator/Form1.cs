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
            
            switch (e.KeyChar)
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

        private void bttBackSpace_Click(object sender, EventArgs e)
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

        private void lbl1_Click(object sender, EventArgs e)
        {
            
        }

        private void _calculator_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
           
        }

        private void bttCE_Click(object sender, EventArgs e)
        {
         
            
                txtResult.Text = "0";
              
           
        }

        private void bttClear_Click(object sender, EventArgs e)
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
    
        private void Operator_Pressed(object sender, EventArgs e)
        {
            // An operator was pressed; perform the last operation and store the new operator.
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

                if (double.IsPositiveInfinity(tempAccum) || double.IsNegativeInfinity(tempAccum))
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
            //txtResult.Text = operation == '=' ? tempAccum.ToString() : "0";
        }

        private void Number_Pressed(object sender, EventArgs e)
        {
            // Add it to the display.
            string number = (sender as Button).Text;
            txtResult.Text = txtResult.Text == "0" ? number : txtResult.Text + number;
        }

        

        private void bttResult_Click(object sender, EventArgs e)
        {
           
        }

        private void operatos_click(object sender, EventArgs e)
        {
            currentNum = Convert.ToDouble(txtResult.Text);
            char operation = (sender as Button).Text[0];

            if (lstOprtion == 'C')
            {
                txtResult.Text = "0";
                tempAccum = 0;
            }

          
            else
            {
                switch (lstOprtion)
                {

                    case '+':
                        tempAccum += currentNum;
                        break;
                    case '-':
                        tempAccum -= currentNum;
                        break;
                    case '*':
                        tempAccum *= currentNum;
                        break;
                    case '/':
                        tempAccum /= currentNum;
                        break;
                    case '%':
                        tempAccum = (tempAccum * (currentNum / 100));
                        break;
                    case '√':
                        tempAccum = Math.Sqrt(tempAccum);
                        break;
                    default: tempAccum = currentNum; break;
                }
                
            }
            lstOprtion = operation;
            txtResult.Text = operation == '=' ? tempAccum.ToString() : "0";





        }

        private void result_click(object sender, EventArgs e)
        {
            txtResult.Text = tempAccum.ToString();
        }

        private void memorybtns_click(object sender, EventArgs e)
        {
            result = tempAccum;
            Button btnMemory = (Button)sender;
            string btnText = btnMemory.Text;
            
            //  txtResult.Text = btnText ==( ("MS") ||( "M-")||("M+")) ? tempAccum.ToString() : "0";


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
                // Memory subtract
                memoryStore -= result;
                txtResult.Text = memoryStore.ToString();
                txtResult.Text = "0";
                return;
            }

            else if (btnText == "M+")
            {
                // Memory add 

                memoryStore += result;
                txtResult.Text = memoryStore.ToString();
                txtResult.Text = "0";
                return;

            }
            
           
            else if (btnText == "MC")
            {
                //Memory Clear
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != string.Empty)
            {

                double reciprNum = Convert.ToDouble("1") / Convert.ToDouble(txtResult.Text);
                txtResult.Text = reciprNum.ToString();

            }

        }

        private void _calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.D8)|| (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Multiply))
            {
                e.Handled = true;
                bttMultyplication.PerformClick();
            }
            else if((Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Divide) || (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.OemQuestion))
            {
                e.Handled = true;
                bttDevision.PerformClick();
            }
            else if ((Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Add) || (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Oemplus))
            {
                e.Handled = true;
                bttAddition.PerformClick();
            }
            else if ((Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Subtract) || (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.OemMinus))
            {
                e.Handled = true;
                bttSubstraction.PerformClick();
            }
            else if (Control.ModifierKeys == Keys.Enter)
            {
                e.Handled = true;
                bttResult.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
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
            else if (e.KeyCode == Keys.Delete)
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

        private void bttPowr(object sender, EventArgs e)
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
