using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakedex_2021
{
    public partial class AltFormEditForm : Form
    {
        public AltFormEditForm()
        {
            InitializeComponent();

            ALTFORM_ERR.Hide();

            // Populate the combobox. Disable it if there are no valid entries.
            AltFormsEditor.PopulateComboBox(COMBOBOX_ALTFORMS, BTN_DEL_ALTFORMEDIT);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BTN_ADD_ALTFORMEDIT_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_add_pressed);
            BTN_ADD_ALTFORMEDIT.Image = bm3;
        }

        private void BTN_ADD_ALTFORMEDIT_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_add);
            BTN_ADD_ALTFORMEDIT.Image = bm3;
        }

        private void BTN_ADD_ALTFORMEDIT_Click(object sender, EventArgs e)
        {
            string ParsedTxtNewAltFormName = TXT_NEWALTFORMNAME.Text.Replace("<", "").Replace(">", "");
            if (!string.IsNullOrEmpty(ParsedTxtNewAltFormName))
            {
                if (COMBOBOX_ALTFORMS.Items.Contains(ParsedTxtNewAltFormName))
                {
                    ALTFORM_ERR.Text = "Form with this name already exists!";
                    ALTFORM_ERR.Show();
                    return;
                }
                else
                {
                    ALTFORM_ERR.Hide();
                }

                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if (row["ID"].ToString() == Globals.CurrentPokemonID)
                    {
                        Dictionary<string, string> AltFormDict = new Dictionary<string, string>();
                        AltFormDict.Add("FormName", ParsedTxtNewAltFormName.ToString());
                        AltFormDict.Add("BaseImage", row["BaseImage"].ToString());
                        AltFormDict.Add("ShinyImage", row["ShinyImage"].ToString());

                        //MessageBox.Show(row["AlternateForms"].GetType().Name);

                        if (row["AlternateForms"] != null && row["AlternateForms"].GetType().Name != "DBNull")
                        {
                            List<Dictionary<string, string>> NewAltFormsList = (List<Dictionary<string, string>>)row["AlternateForms"];
                            NewAltFormsList.Add(AltFormDict);
                        }
                        else
                        {
                            List<Dictionary<string, string>> NewAltFormsList = new List<Dictionary<string, string>>();
                            NewAltFormsList.Add(AltFormDict);
                            row["AlternateForms"] = NewAltFormsList;
                        }

                        //Re-populate combobox
                        COMBOBOX_ALTFORMS.Items.Clear();
                        AltFormsEditor.PopulateComboBox(COMBOBOX_ALTFORMS, BTN_DEL_ALTFORMEDIT);

                        //Clear textbox
                        TXT_NEWALTFORMNAME.Text = "";

                        break;
                    }
                }
            }
            else
            {
                ALTFORM_ERR.Text = "Form name must be at least 1 character long!";
                ALTFORM_ERR.Show();
            }
        }

        private void BTN_DEL_ALTFORMEDIT_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_del_pressed);
            BTN_DEL_ALTFORMEDIT.Image = bm3;
        }

        private void BTN_DEL_ALTFORMEDIT_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_del);
            BTN_DEL_ALTFORMEDIT.Image = bm3;
        }

        private void BTN_DEL_ALTFORMEDIT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(COMBOBOX_ALTFORMS.SelectedItem.ToString()))
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if (row["ID"].ToString() == Globals.CurrentPokemonID)
                    {
                        if (row["AlternateForms"] != null && row["AlternateForms"].GetType().Name != "DBNull")
                        {
                            List<Dictionary<string, string>> CurrentAltFormsList = (List<Dictionary<string, string>>)row["AlternateForms"];
                            Dictionary<string, string> DictionaryToRemove = null;

                            foreach (Dictionary<string, string>DIC in CurrentAltFormsList)
                            {
                                if (DIC["FormName"] == COMBOBOX_ALTFORMS.SelectedItem.ToString())
                                {
                                    DictionaryToRemove = DIC;
                                    break;
                                }
                            }

                            if (DictionaryToRemove != null)
                            {
                                CurrentAltFormsList.Remove(DictionaryToRemove);
                            }

                            //Rebuild combobox
                            COMBOBOX_ALTFORMS.Items.Clear();
                            AltFormsEditor.PopulateComboBox(COMBOBOX_ALTFORMS, BTN_DEL_ALTFORMEDIT);
                        }
                        break;
                    }
                }
            }
        }
    }

    public static class AltFormsEditor
    {
        public static void PopulateComboBox(ComboBox COMBOBOX_ALTFORMS, Button BTN_DEL_ALTFORMEDIT)
        {
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if (row["ID"].ToString() == Globals.CurrentPokemonID)
                {
                    List<Dictionary<string, string>> rowAlternateFormList = null;

                    if (!(row.IsNull("AlternateForms")))
                    {
                        rowAlternateFormList = (List<Dictionary<string, string>>)row["AlternateForms"];
                    }

                    if (rowAlternateFormList != null)
                    {
                        foreach (Dictionary<string, string> AltFormDictionary in rowAlternateFormList)
                        {
                            string AltFormNameStr = "";
                            AltFormNameStr = AltFormDictionary["FormName"].ToString();
                            if (!string.IsNullOrEmpty(AltFormNameStr))
                            {
                                COMBOBOX_ALTFORMS.Items.Add(AltFormNameStr);
                            }
                        }
                    }

                    if (COMBOBOX_ALTFORMS.Items.Count <= 0)
                    {
                        COMBOBOX_ALTFORMS.Enabled = false;
                        BTN_DEL_ALTFORMEDIT.Enabled = false;
                    }
                    else
                    {
                        COMBOBOX_ALTFORMS.Enabled = true;
                        BTN_DEL_ALTFORMEDIT.Enabled = true;

                        //Set actual first value as chosen
                        COMBOBOX_ALTFORMS.SelectedItem = COMBOBOX_ALTFORMS.Items[0];
                    }

                    //Rebuild index (remove empty value)
                    COMBOBOX_ALTFORMS.SelectedIndex = (COMBOBOX_ALTFORMS.Items.Count > 0) ? 0 : -1;

                    break;
                }
            }
        }
    }
}
