using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorapp
{
    public partial class Form1 : Form
    {

        private bool operator_used;
        private bool operator_display;
        private bool decimal_point;
        private string operator_type;
        

        private double value_1;
        
        public Form1()
        {
            decimal_point = false;
            operator_used = false;
            operator_display = false;
            operator_type = "";
            value_1 = 0;
            InitializeComponent();
        }

    
        private void number_click(object sender, EventArgs e)
        {
            if(display.Text == "0" || operator_display)
            {
                display.Clear();
               
                operator_display = false;
            }
            if(equation_box.Text == "0")
            { equation_box.Clear(); }

            Button number_value = (Button)sender;

            display.Text += number_value.Text;
            equation_box.Text += number_value.Text;
        }

        private void operator_button(object sender, EventArgs e)
        {
            if(operator_used)
            { 
                button15_Click(sender,e);
            }

            decimal_point = false;
            operator_used = true;
            Button operator_value = (Button)sender;

            value_1 = Double.Parse(display.Text);
            operator_type = operator_value.Text;
            display.Clear();
            display.Text = operator_value.Text;
            operator_display = true;

            equation_box.Text += operator_value.Text;
        }


        private void button17_Click(object sender, EventArgs e)
        {

            display.Text = "0";
            equation_box.Clear();
            value_1 = 0;
            decimal_point = false;
        }


        private void button15_Click(object sender, EventArgs e)
        {
            
            if (!operator_used)
            { return; }

            switch (operator_type)
            {
                case "+":
                    value_1 += Double.Parse(display.Text);
                    display.Text = value_1.ToString();
                    break;

                case "-":
                    value_1 -= Double.Parse(display.Text);
                    display.Text = value_1.ToString();
                    break;

                case "÷":
                    value_1 /= Double.Parse(display.Text);
                    display.Text = value_1.ToString();
                    break;

                case "×":
                    value_1 *= Double.Parse(display.Text);
                    display.Text = value_1.ToString();
                    break;

                case "Mod":


                default:
                    
                    break;
            }
            operator_used = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (decimal_point || operator_display) { return; }
            display.Text += ".";
            equation_box.Text += ".";
            decimal_point = true;
        }

        private void backspace_button_Click(object sender, EventArgs e)
        {
            if (display.Text != "" || equation_box.Text != "")
            {
                display.Text = display.Text.Substring(0,display.Text.Length - 1);
                equation_box.Text = equation_box.Text.Substring(0, equation_box.Text.Length - 1);
            }
        }
    }
}
