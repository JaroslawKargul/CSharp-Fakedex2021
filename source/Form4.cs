using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class EditBaseStatsPanel : Form
    {
        public EditBaseStatsPanel()
        {
            InitializeComponent();

            // Populate fields with current Pokemon's stats
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    EditATK.Text = row["ATK"].ToString();
                    EditDEF.Text = row["DEF"].ToString();
                    EditSPD.Text = row["SPEED"].ToString();
                    EditHP.Text = row["HP"].ToString();
                    EditHT.Text = row["Height"].ToString();
                    EditWT.Text = row["Weight"].ToString();

                    break;
                }
            }
        }

        // OK

        private void EditBaseOKButton_MouseDown(object sender, EventArgs e)
        {
            EditBaseOKButton.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_OK_press);
            EditBaseOKButton.Image = bm1;
        }

        private void EditBaseOKButton_MouseUp(object sender, EventArgs e)
        {
            EditBaseOKButton.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_OK);
            EditBaseOKButton.Image = bm2;
        }

        private void EditBaseOKButton_Click(object sender, EventArgs e)
        {
            if (EditBaseOKButton.Enabled)
            {
                Globals.Request_NewBaseHP = EditHP.Text.Replace("<","").Replace(">","");
                Globals.Request_NewBaseATK = EditATK.Text.Replace("<", "").Replace(">", "");
                Globals.Request_NewBaseDEF = EditDEF.Text.Replace("<", "").Replace(">", "");
                Globals.Request_NewBaseSPD = EditSPD.Text.Replace("<", "").Replace(">", "");
                Globals.Request_NewBaseWT = EditWT.Text.Replace("<", "").Replace(">", "");
                Globals.Request_NewBaseHT = EditHT.Text.Replace("<", "").Replace(">", "");
                this.Close();
            }
        }

        // CANCEL

        private void EditBaseCANCELButton_MouseDown(object sender, EventArgs e)
        {
            EditBaseCANCELButton.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.question_window_CANCEL_press);
            EditBaseCANCELButton.Image = bm1;
        }

        private void EditBaseCANCELButton_MouseUp(object sender, EventArgs e)
        {
            EditBaseCANCELButton.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.question_window_CANCEL);
            EditBaseCANCELButton.Image = bm2;
        }

        private void EditBaseCANCELButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
