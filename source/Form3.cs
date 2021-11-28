using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class AddPkmnPanel : Form
    {
        public AddPkmnPanel()
        {
            InitializeComponent();
            NewPkmnDexIDBox.Text = "";
            NewPkmnNameBox.Text = "";

            NewPkmnWarning1.Text = "";
            NewPkmnWarning2.Text = "";

            NewPkmnOK.Enabled = false;

            // No weird white border on buttons when form is out of focus...
            NewPkmnOK.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            NewPkmnCANCEL.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        // NewPkmnOK

        private void NewPkmnOK_Click(object sender, EventArgs e)
        {
            if (NewPkmnOK.Enabled)
            {
                Globals.Request_NewPkmnDexID = NewPkmnDexIDBox.Text;
                Globals.Request_NewPkmnName = NewPkmnNameBox.Text;
                this.Close();
            }
        }

        private void NewPkmnOK_MouseDown(object sender, EventArgs e)
        {
            NewPkmnOK.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_OK_press);
            NewPkmnOK.Image = bm1;
        }

        private void NewPkmnOK_MouseUp(object sender, EventArgs e)
        {
            NewPkmnOK.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_OK);
            NewPkmnOK.Image = bm2;
        }

        // NewPkmnCANCEL

        private void NewPkmnCANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPkmnCANCEL_MouseDown(object sender, EventArgs e)
        {
            NewPkmnCANCEL.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_CANCEL_press);
            NewPkmnCANCEL.Image = bm1;
        }

        private void NewPkmnCANCEL_MouseUp(object sender, EventArgs e)
        {
            NewPkmnCANCEL.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_CANCEL);
            NewPkmnCANCEL.Image = bm2;
        }

        // NewPkmnDexIDBox

        private void NewPkmnDexIDBox_KeyUp(object sender, EventArgs e)
        {
            NewPkmnTextChecker.Trigger(NewPkmnDexIDBox, NewPkmnNameBox, NewPkmnWarning1, NewPkmnWarning2, NewPkmnOK);
        }

        private void NewPkmnDexIDBox_KeyDown(object sender, EventArgs e)
        {
            NewPkmnOK.Enabled = false;
        }

        // NewPkmnNameBox

        private void NewPkmnNameBox_KeyUp(object sender, EventArgs e)
        {
            NewPkmnTextChecker.Trigger(NewPkmnDexIDBox, NewPkmnNameBox, NewPkmnWarning1, NewPkmnWarning2, NewPkmnOK);
        }

        private void NewPkmnNameBox_KeyDown(object sender, EventArgs e)
        {
            NewPkmnOK.Enabled = false;
        }

        public static class NewPkmnTextChecker
        {
            public static void Trigger(TextBox PkmnIDBox, TextBox PkmnNameBox, Label WarningIDLabel, Label WarningNameLabel, Button OKButton)
            {
                Dictionary<TextBox,Label> PkmnTextBoxes = new Dictionary<TextBox, Label>
                {
                    [PkmnIDBox] = WarningIDLabel,
                    [PkmnNameBox] = WarningNameLabel,
                };

                int ValidEntries = 0;

                foreach (KeyValuePair<TextBox, Label> PkmnTextBoxLabelPair in PkmnTextBoxes)
                {
                    TextBox PkmnTextBox = PkmnTextBoxLabelPair.Key;
                    Label PkmnLabel = PkmnTextBoxLabelPair.Value;
                    String EditedThing = PkmnTextBox.Tag.ToString();

                    if (PkmnTextBox.Text != "")
                    {
                        bool IsDexIDValid = true;
                        foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                        {
                            if ((string)row["ID"] == PkmnTextBox.Text)
                            {
                                PkmnLabel.Text = "A creature with this " + EditedThing + " already exists.";
                                IsDexIDValid = false;
                                ValidEntries--;
                            }
                        }

                        foreach (string IllegalChar in Globals.IllegalChars)
                        {
                            if (PkmnTextBox.Text.Contains(IllegalChar))
                            {
                                PkmnLabel.Text = "Spaces and special characters are not supported.";
                                IsDexIDValid = false;
                                ValidEntries--;
                            }
                        }

                        if (IsDexIDValid)
                        {
                            PkmnLabel.Text = "";
                            ValidEntries++;
                        }
                    }
                    else
                    {
                        PkmnLabel.Text = EditedThing + " must contain at least 1 character.";
                        ValidEntries--;
                    }
                }

                if (ValidEntries >= 2)
                {
                    OKButton.Enabled = true;
                }
                else
                {
                    OKButton.Enabled = false;
                }
            }
        }

    }
}
