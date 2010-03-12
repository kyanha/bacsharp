using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bacsharp
{
    public partial class Form1 : Form
    {
        private UDPClient myUDPClient = new UDPClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void sendWhoIsbutton_Click(object sender, EventArgs e)
        {
            myUDPClient.sendWhoIs();
        }
    }
}