using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class FAKEDEX_SAVEPOPUP : Form
    {
        public FAKEDEX_SAVEPOPUP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.question_window_OK_press);
            button1.Image = bm3;
        }

        private void button1_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.question_window_OK);
            button1.Image = bm3;
        }
    }
}
