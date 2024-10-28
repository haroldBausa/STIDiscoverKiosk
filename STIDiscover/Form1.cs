using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STIDiscover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            homeControl1.BringToFront();
        }
        private void moveImageBox(object sender)
        {
            Guna2Button guna2 = (Guna2Button)sender;
            imageSilder.Location = new Point(guna2.Location.X -45, guna2.Location.Y - 15);
            imageSilder.SendToBack();
        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homeControl1.BringToFront();
        }
      
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleControl1.BringToFront();
        }
    }
}
