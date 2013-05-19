using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        int temps;  // Variable for the timer interval
        
        private void button1_Click(object sender, EventArgs e)
        {

            Form1 fm1 = (Form1)this.Owner;                                  // Allows to exchange settings between Form1 and Form2.
            try
            {
                temps = int.Parse(textBox1.Text);                           // Converts the value entered from the textbox (string) into an integer
                fm1.timer1.Stop();                                          // Stops the timer to prevent any mistake.
                fm1.timer1.Interval = temps * 60000;                        // Sets the timer interval from the textbox value.

                fm1.timer1.Start();
                File.WriteAllText("C:/settings-ip.ini", textBox1.Text);    // Saves the setting (the textbox value) into an ini file. 
                this.Hide();
            }
            catch 
            // Prevents any crash if you entered a wrong value
            { 
            FormatException fe = new FormatException(); 
            ArgumentOutOfRangeException ar = new ArgumentOutOfRangeException();
            MessageBox.Show("Please enter a correct value","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();   // Hides our setting window.
        }
    }
}
