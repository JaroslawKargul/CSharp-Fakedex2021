using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Fakedex_2021
{
    public partial class EditAttackListPanel : Form
    {
        public EditAttackListPanel()
        {
            InitializeComponent();

            NORESULTS.Hide();
            BTN_SAVECHANGES.Enabled = false;
            BTN_REMOVEATTACK.Enabled = false;
            ERRORLABEL.Text = "";

            TXT_ATTACKNAME.MaxLength = 25;
            TXT_ATTACKLEVEL.MaxLength = 3;
            TXT_ATTACKTYPE.MaxLength = 15;
            TXT_ATTACKDESCR.MaxLength = 200;

            // Set globals
            Globals.TXT_ATTACKNAME = TXT_ATTACKNAME;
            Globals.TXT_ATTACKLEVEL = TXT_ATTACKLEVEL;
            Globals.TXT_ATTACKTYPE = TXT_ATTACKTYPE;
            Globals.TXT_ATTACKDESCR = TXT_ATTACKDESCR;

            // Load Attack templates
            AttackListEditor.RebuildTemplates(ATTACKTEMPLATES);

            // Load AttackList
            AttackListEditor.RebuildAttackList(ATTACKLIST, BTN_SAVECHANGES, BTN_REMOVEATTACK, toolTip1);
        }

        private void AtkListEditOK_Click(object sender, EventArgs e)
        {
            
        }

        private void ATKSEARCHBAR_KeyUp(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ATKSEARCHBAR.Text))
            {
                int AllAtks = ATTACKTEMPLATES.Controls.Count;
                int NrHidden = 0;
                foreach (Button AtkTemplate in ATTACKTEMPLATES.Controls)
                {
                    if (AtkTemplate.Text.Contains(ATKSEARCHBAR.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        AtkTemplate.Show();
                        NORESULTS.Hide();
                    }
                    else
                    {
                        NrHidden++;
                        AtkTemplate.Hide();

                        if (NrHidden >= AllAtks)
                        {
                            NORESULTS.Show();
                        }
                    }
                }
            }
            else
            {
                foreach (Button AtkTemplate in ATTACKTEMPLATES.Controls)
                {
                    AtkTemplate.Show();
                    NORESULTS.Hide();
                }
            }
        }

        private void BTN_SAVECHANGES_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm1 = new Bitmap(Properties.Resources.button_sav_pressed);
            BTN_SAVECHANGES.Image = bm1;
        }

        private void BTN_SAVECHANGES_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm2 = new Bitmap(Properties.Resources.button_sav);
            BTN_SAVECHANGES.Image = bm2;
        }

        private void BTN_SAVECHANGES_Click(object sender, EventArgs e)
        {
            if (AttackListEditor.DoAttackStringCheck(ERRORLABEL, TXT_ATTACKLEVEL.Text, TXT_ATTACKTYPE.Text, TXT_ATTACKNAME.Text))
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if ((string)row["ID"] == Globals.CurrentPokemonID)
                    {
                        List<Dictionary<string, string>> rowAttackList = (List<Dictionary<string, string>>)row["AttackList"];

                        if (rowAttackList != null)
                        {
                            foreach (Dictionary<string, string> AtkDictionary in rowAttackList)
                            {
                                if (AtkDictionary.ContainsKey("MoveName") && AtkDictionary["MoveName"] == Globals.AtkListButtonChosenForEditing.Text.Split("] ")[1])
                                {
                                    string ActualAtkName = TXT_ATTACKNAME.Text.Replace("<", "").Replace(">", "");
                                    string ActualAtkLevel = TXT_ATTACKLEVEL.Text.Replace("<", "").Replace(">", "");
                                    string ActualAtkType = TXT_ATTACKTYPE.Text.Replace("<", "").Replace(">", "");
                                    string ActualAtkDescr = TXT_ATTACKDESCR.Text.Replace("<", "").Replace(">", "");

                                    Globals.AtkListButtonChosenForEditing.Text = "[" + ActualAtkLevel + "] " + ActualAtkName;
                                    Globals.AtkListButtonChosenForEditing.BackColor = FormRefresher.ResolveTypeColor(ActualAtkType);
                                    Globals.AtkListButtonChosenForEditing.Tag = ActualAtkType;
                                    toolTip1.SetToolTip(Globals.AtkListButtonChosenForEditing, ActualAtkDescr.Replace("\r", ""));

                                    // Un-select
                                    Globals.AtkListButtonChosenForEditing.ForeColor = Color.FromName("Black");
                                    Globals.AtkListButtonChosenForEditing.FlatAppearance.BorderColor = Color.FromName("Black");
                                    Globals.AtkListButtonChosenForEditing = null;

                                    AtkDictionary["MoveName"] = ActualAtkName;
                                    AtkDictionary["Type"] = ActualAtkType;
                                    AtkDictionary["Level"] = ActualAtkLevel;
                                    AtkDictionary["Description"] = ActualAtkDescr;

                                    BTN_REMOVEATTACK.Enabled = false;
                                    BTN_SAVECHANGES.Enabled = false;

                                    Globals.DEX_UNSAVED_CHANGES = true;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BTN_ADDATTACK_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm1 = new Bitmap(Properties.Resources.button_add_pressed);
            BTN_ADDATTACK.Image = bm1;
        }

        private void BTN_ADDATTACK_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm2 = new Bitmap(Properties.Resources.button_add);
            BTN_ADDATTACK.Image = bm2;
        }

        private void BTN_ADDATTACK_Click(object sender, EventArgs e)
        {
            if (AttackListEditor.DoAttackStringCheck(ERRORLABEL, TXT_ATTACKLEVEL.Text, TXT_ATTACKTYPE.Text, TXT_ATTACKNAME.Text))
            {
                AttackListEditor.AddNewAttack(ATTACKTEMPLATES, ATTACKLIST, BTN_SAVECHANGES, BTN_REMOVEATTACK, toolTip1);
                Globals.DEX_UNSAVED_CHANGES = true;
            }
        }

        private void BTN_REMOVEATTACK_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm1 = new Bitmap(Properties.Resources.button_del_pressed);
            BTN_REMOVEATTACK.Image = bm1;
        }

        private void BTN_REMOVEATTACK_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm2 = new Bitmap(Properties.Resources.button_del);
            BTN_REMOVEATTACK.Image = bm2;
        }

        private void BTN_REMOVEATTACK_Click(object sender, EventArgs e)
        {
            if (Globals.AtkListButtonChosenForEditing != null)
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if ((string)row["ID"] == Globals.CurrentPokemonID)
                    {
                        List<Dictionary<string, string>> rowAttackList = (List<Dictionary<string, string>>)row["AttackList"];

                        if (rowAttackList != null)
                        {
                            foreach (Dictionary<string, string> AtkDictionary in rowAttackList)
                            {
                                if (AtkDictionary.ContainsKey("MoveName") && AtkDictionary["MoveName"] == Globals.AtkListButtonChosenForEditing.Text.Split("] ")[1])
                                {
                                    rowAttackList.Remove(AtkDictionary);
                                    ATTACKLIST.Controls.Remove(Globals.AtkListButtonChosenForEditing);

                                    BTN_REMOVEATTACK.Enabled = false;
                                    BTN_SAVECHANGES.Enabled = false;

                                    Globals.DEX_UNSAVED_CHANGES = true;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    public class SemiNumericComparer : IComparer<string>
    {
        /// <summary>
        /// Method to determine if a string is a number
        /// </summary>
        /// <param name="value">String to test</param>
        /// <returns>True if numeric</returns>
        public static bool IsNumeric(string value)
        {
            return int.TryParse(value, out _);
        }

        /// <inheritdoc />
        public int Compare(string s1, string s2)
        {
            const int S1GreaterThanS2 = 1;
            const int S2GreaterThanS1 = -1;

            var IsNumeric1 = IsNumeric(s1);
            var IsNumeric2 = IsNumeric(s2);

            if (IsNumeric1 && IsNumeric2)
            {
                var i1 = Convert.ToInt32(s1);
                var i2 = Convert.ToInt32(s2);

                if (i1 > i2)
                {
                    return S1GreaterThanS2;
                }

                if (i1 < i2)
                {
                    return S2GreaterThanS1;
                }

                return 0;
            }

            if (IsNumeric1)
            {
                return S2GreaterThanS1;
            }

            if (IsNumeric2)
            {
                return S1GreaterThanS2;
            }

            return string.Compare(s1, s2, true, CultureInfo.InvariantCulture);
        }
    }

    public static class AttackListEditor
    {
        public static void RebuildTemplates(FlowLayoutPanel TemplateList)
        {
            // Clear the template list
            TemplateList.Controls.Clear();

            List<string> AddedAttacks = new List<string>();
            List<Button> AttackButtons = new List<Button>();

            foreach (Dictionary<string, string> AtkDict in Globals.AttackTemplates)
            {
                string CurrentAttackName = "";
                string CurrentAttackType = "";
                string CurrentAttackDescription = "";

                foreach (KeyValuePair<string, string> Attack in AtkDict)
                {
                    if (Attack.Key == "MoveName" && !AddedAttacks.Contains(Attack.Value))
                    {
                        AddedAttacks.Add(Attack.Value);
                        CurrentAttackName = Attack.Value;
                    }
                    else if (Attack.Key == "Type")
                    {
                        CurrentAttackType = Attack.Value;
                    }
                    else if (Attack.Key == "Description")
                    {
                        CurrentAttackDescription = Attack.Value;
                    }
                }

                if (CurrentAttackName != "")
                {
                    Button NewAtkTemplateBtn = new Button();
                    NewAtkTemplateBtn.Text = CurrentAttackName;
                    NewAtkTemplateBtn.Font = new Font("Segoe UI", 11);
                    NewAtkTemplateBtn.BackColor = FormRefresher.ResolveTypeColor(CurrentAttackType);
                    NewAtkTemplateBtn.FlatStyle = FlatStyle.Flat;
                    NewAtkTemplateBtn.Width = 162;
                    NewAtkTemplateBtn.Height = 30;

                    void NewBtnFn(object sender, EventArgs e)
                    {
                        Globals.TXT_ATTACKNAME.Text = CurrentAttackName;
                        Globals.TXT_ATTACKLEVEL.Text = "???";
                        Globals.TXT_ATTACKTYPE.Text = CurrentAttackType;
                        Globals.TXT_ATTACKDESCR.Text = CurrentAttackDescription;
                    }

                    NewAtkTemplateBtn.Click += new EventHandler(NewBtnFn);

                    AttackButtons.Add(NewAtkTemplateBtn);
                }
            }

            AddedAttacks.Sort();

            foreach (string SortedAtk in AddedAttacks)
            {
                foreach (Button AtkButton in AttackButtons)
                {
                    if (AtkButton.Text == SortedAtk)
                    {
                        TemplateList.Controls.Add(AtkButton);
                    }
                }
            }
        }

        public static void RebuildAttackList(FlowLayoutPanel AttackList, Button SaveChangesBtn, Button DeleteBtn, ToolTip Tooltip1)
        {
            // Clear the attack list
            AttackList.Controls.Clear();

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    List<Dictionary<string, string>> rowAttackList = (List<Dictionary<string, string>>)row["AttackList"];

                    if (rowAttackList != null)
                    {
                        foreach (Dictionary<string, string> AtkDictionary in rowAttackList)
                        {
                            string AtkDescription = "";
                            if (AtkDictionary.ContainsKey("Description") && AtkDictionary["Description"] != null)
                            {
                                AtkDescription = AtkDictionary["Description"];
                            }

                            string AtkMoveName = "";
                            if (AtkDictionary.ContainsKey("MoveName") && AtkDictionary["MoveName"] != null)
                            {
                                AtkMoveName = AtkDictionary["MoveName"];
                            }

                            string AtkLevel = "";
                            if (AtkDictionary.ContainsKey("Level") && AtkDictionary["Level"] != null)
                            {
                                AtkLevel = AtkDictionary["Level"];
                            }

                            string AtkType = "";
                            if (AtkDictionary.ContainsKey("Type") && AtkDictionary["Type"] != null)
                            {
                                AtkType = AtkDictionary["Type"];
                            }

                            if (AtkMoveName != "")
                            {
                                Button NewAtkListBtn = new Button();
                                NewAtkListBtn.Text = "[" + AtkLevel + "] " + AtkMoveName;
                                NewAtkListBtn.Font = new Font("Segoe UI", 11);
                                NewAtkListBtn.BackColor = FormRefresher.ResolveTypeColor(AtkType);
                                NewAtkListBtn.Tag = AtkType; // store type in Tag
                                NewAtkListBtn.FlatStyle = FlatStyle.Flat;
                                NewAtkListBtn.Width = 162;
                                NewAtkListBtn.Height = 30;
                                NewAtkListBtn.AutoSize = true;
                                Tooltip1.SetToolTip(NewAtkListBtn, AtkDescription.Replace("\r", ""));

                                void NewBtnFn(object sender, EventArgs e)
                                {
                                    Globals.TXT_ATTACKNAME.Text = AtkMoveName;
                                    Globals.TXT_ATTACKLEVEL.Text = AtkLevel;
                                    Globals.TXT_ATTACKTYPE.Text = AtkType;
                                    Globals.TXT_ATTACKDESCR.Text = AtkDescription;

                                    foreach (Button entry in AttackList.Controls)
                                    {
                                        if (entry == NewAtkListBtn)
                                        {
                                            continue;
                                        }

                                        // Un-choose for editing unless user selected us
                                        entry.BackColor = FormRefresher.ResolveTypeColor(entry.Tag.ToString());
                                        entry.ForeColor = Color.FromName("Black");
                                        entry.FlatAppearance.BorderColor = Color.FromName("Black");
                                    }

                                    // Chosen for editing - if we are already chosen, then un-choose us
                                    if (Globals.AtkListButtonChosenForEditing != NewAtkListBtn)
                                    {
                                        NewAtkListBtn.BackColor = Color.FromName("Black");
                                        NewAtkListBtn.ForeColor = Color.FromName("White");
                                        NewAtkListBtn.FlatAppearance.BorderColor = Color.FromName("White");
                                        Globals.AtkListButtonChosenForEditing = NewAtkListBtn;
                                        SaveChangesBtn.Enabled = true;
                                        DeleteBtn.Enabled = true;
                                    }
                                    else
                                    {
                                        NewAtkListBtn.BackColor = FormRefresher.ResolveTypeColor(NewAtkListBtn.Tag.ToString());
                                        NewAtkListBtn.ForeColor = Color.FromName("Black");
                                        NewAtkListBtn.FlatAppearance.BorderColor = Color.FromName("Black");
                                        Globals.AtkListButtonChosenForEditing = null;
                                        SaveChangesBtn.Enabled = false;
                                        DeleteBtn.Enabled = false;
                                    }
                                }

                                NewAtkListBtn.Click += new EventHandler(NewBtnFn);

                                AttackList.Controls.Add(NewAtkListBtn);
                            }
                        }
                    }

                    break;
                }
            }
        }

        public static void AddNewAttack(FlowLayoutPanel TemplateList, FlowLayoutPanel AttackList, Button SaveChangesBtn, Button DeleteBtn, ToolTip Tooltip1)
        {
            // Declare new Lists for rebuilding
            List<string> AttackLevelList = new List<string>();
            List<Dictionary<string, string>> NewAttackList = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> OldAttackList = new List<Dictionary<string, string>>();

            // Truncate strings
            string ActualAtkName = Globals.TXT_ATTACKNAME.Text.Replace("<", "").Replace(">", "");
            string ActualAtkLevel = Globals.TXT_ATTACKLEVEL.Text.Replace("<", "").Replace(">", "");
            string ActualAtkType = Globals.TXT_ATTACKTYPE.Text.Replace("<", "").Replace(">", "");
            string ActualAtkDescr = Globals.TXT_ATTACKDESCR.Text.Replace("<", "").Replace(">", "");

            // Get information and fill out temporary Lists
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    List<Dictionary<string, string>> rowAttackList = (List<Dictionary<string, string>>)row["AttackList"];

                    if (rowAttackList != null)
                    {
                        foreach (Dictionary<string, string> AtkDictionary in rowAttackList)
                        {
                            OldAttackList.Add(AtkDictionary);

                            if (AtkDictionary.ContainsKey("Level"))
                            {
                                if (!AttackLevelList.Contains(AtkDictionary["Level"]))
                                {
                                    AttackLevelList.Add(AtkDictionary["Level"]);
                                }
                            }
                        }
                    }
                    break;
                }
            }

            // Add new attack to the temporary Lists
            if (!string.IsNullOrEmpty(ActualAtkName) && !string.IsNullOrEmpty(ActualAtkLevel) && !string.IsNullOrEmpty(ActualAtkType))
            {
                Dictionary<string, string> AtkDict = new Dictionary<string, string>();

                AtkDict.Add("Level", ActualAtkLevel);
                AtkDict.Add("MoveName", ActualAtkName);
                AtkDict.Add("Type", ActualAtkType);
                AtkDict.Add("Description", ActualAtkDescr);

                OldAttackList.Add(AtkDict);
                Globals.AttackTemplates.Add(AtkDict);

                // Add level to list
                if (!AttackLevelList.Contains(ActualAtkLevel))
                {
                    AttackLevelList.Add(ActualAtkLevel);
                }
            }

            // Sort our list by Attack Level
            AttackLevelList.Sort(new SemiNumericComparer());

            // Rebuild Attack List
            foreach (string Level in AttackLevelList)
            {
                foreach (Dictionary<string, string> AtkDictionary in OldAttackList)
                {
                    if (AtkDictionary.ContainsKey("Level") && AtkDictionary["Level"] == Level)
                    {
                        NewAttackList.Add(AtkDictionary);
                    }
                }
            }

            // Apply new list to Pokemon data
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    row["AttackList"] = NewAttackList;
                    break;
                }
            }

            // Now, rebuild our buttons, accounting for the new one!
            AttackListEditor.RebuildTemplates(TemplateList);
            AttackListEditor.RebuildAttackList(AttackList, SaveChangesBtn, DeleteBtn, Tooltip1);
        }

        public static bool DoAttackStringCheck(Label Errorlabel, string AttackLevelStr, string AttackTypeStr, string AttackNameStr)
        {
            if (string.IsNullOrEmpty(AttackLevelStr))
            {
                Errorlabel.Text = "Attack level must be at least 1 character long!";
                return false;
            }
            else if (string.IsNullOrEmpty(AttackTypeStr))
            {
                Errorlabel.Text = "Attack type must be at least 1 character long!";
                return false;
            }
            else if (string.IsNullOrEmpty(AttackNameStr))
            {
                Errorlabel.Text = "Attack name must be at least 1 character long!";
                return false;
            }

            return true;
        }
    }
}
