using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class EditEvoLineForm : Form
    {
        public EditEvoLineForm()
        {
            InitializeComponent();

            // Populate all comboboxes
            COMBOBOX_STAGE1.Items.Add("");
            COMBOBOX_STAGE2.Items.Add("");
            COMBOBOX_STAGE3.Items.Add("");

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if (row["ID"].ToString() != "")
                {
                    COMBOBOX_STAGE1.Items.Add(row["ID"].ToString() + " " + row["Name"].ToString());
                    COMBOBOX_STAGE2.Items.Add(row["ID"].ToString() + " " + row["Name"].ToString());
                    COMBOBOX_STAGE3.Items.Add(row["ID"].ToString() + " " + row["Name"].ToString());
                }
            }

            // Fill out all elements with proper data
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    if (row["Stage1To2EvoMethod"].ToString() != "This creature does not evolve.")
                    {
                        TXT_EVOMETHOD1.Text = row["Stage1To2EvoMethod"].ToString();
                        TXT_EVOMETHOD2.Text = row["Stage2To3EvoMethod"].ToString();

                        if (!String.IsNullOrEmpty(row["Stage1ID"].ToString()))
                        {
                            string Stage1ID = row["Stage1ID"].ToString();
                            string Stage1Name = "";
                            foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                            {
                                if ((string)evorow["ID"] == Stage1ID)
                                {
                                    Stage1Name = evorow["Name"].ToString();
                                    break;
                                }
                            }
                            COMBOBOX_STAGE1.SelectedItem = Stage1ID + " " + Stage1Name;
                        }

                        if (!String.IsNullOrEmpty(row["Stage2ID"].ToString()))
                        {
                            string Stage2ID = row["Stage2ID"].ToString();
                            string Stage2Name = "";
                            foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                            {
                                if ((string)evorow["ID"] == Stage2ID)
                                {
                                    Stage2Name = evorow["Name"].ToString();
                                    break;
                                }
                            }
                            COMBOBOX_STAGE2.SelectedItem = Stage2ID + " " + Stage2Name;
                        }

                        if (!String.IsNullOrEmpty(row["Stage3ID"].ToString()))
                        {
                            string Stage3ID = row["Stage3ID"].ToString();
                            string Stage3Name = "";
                            foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                            {
                                if ((string)evorow["ID"] == Stage3ID)
                                {
                                    Stage3Name = evorow["Name"].ToString();
                                    break;
                                }
                            }
                            COMBOBOX_STAGE3.SelectedItem = Stage3ID + " " + Stage3Name;
                        }
                    }
                    else
                    {
                        TXT_EVOMETHOD1.Text = "";
                        TXT_EVOMETHOD2.Text = "";
                    }
                    break;
                }
            }
        }

        private void BTN_OK_EVOPATH_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.question_window_OK_press);
            BTN_OK_EVOPATH.Image = bm3;
        }

        private void BTN_OK_EVOPATH_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.question_window_OK);
            BTN_OK_EVOPATH.Image = bm3;
        }

        private void BTN_OK_EVOPATH_Click(object sender, EventArgs e)
        {
            // Set evolution info in current Pokemon data

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    Globals.DEX_UNSAVED_CHANGES = true;

                    row["Stage1To2EvoMethod"] = TXT_EVOMETHOD1.Text.Replace("<","").Replace(">", "");
                    row["Stage2To3EvoMethod"] = TXT_EVOMETHOD2.Text.Replace("<", "").Replace(">", "");

                    row["Stage1ID"] = COMBOBOX_STAGE1.Text.Split(" ")[0];
                    row["Stage2ID"] = COMBOBOX_STAGE2.Text.Split(" ")[0];
                    row["Stage3ID"] = COMBOBOX_STAGE3.Text.Split(" ")[0];

                    //MessageBox.Show(row["Stage1ID"].ToString());
                    //MessageBox.Show(row["Stage2ID"].ToString());
                    //MessageBox.Show(row["Stage3ID"].ToString());

                    // Find base imagename for each evolution
                    if (!String.IsNullOrEmpty(row["Stage1ID"].ToString()))
                    {
                        string Stage1ID = row["Stage1ID"].ToString();
                        string Stage1Image = "";
                        foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                        {
                            if ((string)evorow["ID"] == Stage1ID)
                            {
                                Stage1Image = evorow["BaseImage"].ToString();
                                break;
                            }
                        }
                        row["Stage1Image"] = Stage1Image;
                    }

                    if (!String.IsNullOrEmpty(row["Stage2ID"].ToString()))
                    {
                        string Stage2ID = row["Stage2ID"].ToString();
                        string Stage2Image = "";
                        foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                        {
                            if ((string)evorow["ID"] == Stage2ID)
                            {
                                Stage2Image = evorow["BaseImage"].ToString();
                                break;
                            }
                        }
                        row["Stage2Image"] = Stage2Image;
                    }

                    if (!String.IsNullOrEmpty(row["Stage3ID"].ToString()))
                    {
                        string Stage3ID = row["Stage3ID"].ToString();
                        string Stage3Image = "";
                        foreach (DataRow evorow in Globals.POKEDEX_DATA.Rows)
                        {
                            if ((string)evorow["ID"] == Stage3ID)
                            {
                                Stage3Image = evorow["BaseImage"].ToString();
                                break;
                            }
                        }
                        row["Stage3Image"] = Stage3Image;
                    }

                    // If all entries are empty, then set a special string on Stage1To2EvoMethod
                    if (string.IsNullOrEmpty(TXT_EVOMETHOD1.Text.Replace("<", "").Replace(">", "")) &&
                        string.IsNullOrEmpty(TXT_EVOMETHOD2.Text.Replace("<", "").Replace(">", "")) &&
                        string.IsNullOrEmpty(COMBOBOX_STAGE1.Text.Split(" ")[0]) &&
                        string.IsNullOrEmpty(COMBOBOX_STAGE2.Text.Split(" ")[0]) &&
                        string.IsNullOrEmpty(COMBOBOX_STAGE3.Text.Split(" ")[0]))
                    {
                        row["Stage1To2EvoMethod"] = "This creature does not evolve.";
                    }

                    break;
                }
            }
        }
    }
}
