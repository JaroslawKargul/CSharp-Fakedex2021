using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class DeleteConfirmation : Form
    {
        public DeleteConfirmation()
        {
            InitializeComponent();

            // Make our form's backcolor a special color, then make it transparent.
            this.BackColor = Color.FromArgb(3, 252, 28);
            this.TransparencyKey = Color.FromArgb(3, 252, 28);

            // No weird white border on buttons when form is out of focus...
            BTN_YES.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            BTN_NO.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void BTN_YES_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_YES_MouseDown(object sender, EventArgs e)
        {
            BTN_YES.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_YES_press);
            BTN_YES.Image = bm1;
        }

        private void BTN_YES_MouseUp(object sender, EventArgs e)
        {
            BTN_YES.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_YES);
            BTN_YES.Image = bm2;
        }

        private void BTN_NO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_NO_MouseDown(object sender, EventArgs e)
        {
            BTN_NO.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_NO_press);
            BTN_NO.Image = bm1;
        }

        private void BTN_NO_MouseUp(object sender, EventArgs e)
        {
            BTN_NO.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_NO);
            BTN_NO.Image = bm2;
        }
    }
}
