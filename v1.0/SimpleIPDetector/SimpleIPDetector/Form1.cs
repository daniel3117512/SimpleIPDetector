// Author: Daniel Roger ; e-mail:  daniroger@free.fr
// Licence : GNU GPL V3
// You can edit , distribute this program without limitation. Totally free and open source.
// Enjoy it 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 fm2 = new Form2();      // Form declaration (Settings window)
        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:/settings-ip.ini"))   // Checks if the configuration file exists
            {
                ipcap();
                string conf = File.ReadAllText("C:/settings-ip.ini");   // Loads the timer value from the configuration file
                int setting = int.Parse(conf);
                fm2.textBox1.Text = conf;
                timer1.Interval = setting * 60000;
                timer1.Start();
            }
            else
            {
                ipcap();
            }
        }
        // This void will detetct your IP address
        void ipcap()
        {
            string url = "http://checkip.dyndns.org";  // This is website which detects the IP address
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim(); 
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);                  // Skips the text before the IP address
            string[] a3 = a2.Split('<');                    
            string a4 = a3[0];
            label1.Text = a4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            fm2.Show();       // Opens the settings window
            fm2.Owner = this; // Allows a setting exchange between Form1 and Form2. I'm not going to explain it in details.
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ipcap();     // Goes to the IP detection void
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ipcap();
        }

    }

        
}
