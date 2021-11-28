using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace Fakedex_2021
{
    public partial class Fakedex2021 : Form
    {
        public Fakedex2021()
        {
            // Make our form's backcolor a special color, then make it transparent.
            this.BackColor = Color.FromArgb(3, 252, 28);
            this.TransparencyKey = Color.FromArgb(3, 252, 28);
            //this.Icon = Properties.Resources.icon_smolbirb2;

            InitializeComponent();

            Globals.label1 = label1;
            Globals.TYPE1 = TYPE1;
            Globals.TYPE2 = TYPE2;
            Globals.ATKNUM = ATKNUM;
            Globals.DEFNUM = DEFNUM;
            Globals.SPDNUM = SPDNUM;
            Globals.HPNUM = HPNUM;
            Globals.HEIGHTNUM = HEIGHTNUM;
            Globals.WEIGHTNUM = WEIGHTNUM;
            Globals.pictureBox1 = pictureBox1;
            Globals.pictureBox2 = pictureBox2;
            Globals.SIZECOMP = SIZECOMP;
            Globals.DESCRBOX = DESCRBOX;
            Globals.CONCEPTDESCR = CONCEPTDESCR;
            Globals.ABILDESCR = ABILDESCR;
            Globals.ATTACKLIST = ATTACKLIST;
            Globals.EVO1 = EVO1;
            Globals.EVO2 = EVO2;
            Globals.EVO3 = EVO3;
            Globals.EVOTYPE1 = EVOTYPE1;
            Globals.EVOTYPE2 = EVOTYPE2;
            Globals.PokeSearch = PokeSearch;
            Globals.button1 = button1;
            Globals.NOEVO = NOEVO;
            Globals.BTN_SAVE = BTN_SAVE;
            Globals.BTN_ADD = BTN_ADD;
            Globals.BTN_DELETE = BTN_DELETE;
            Globals.BTN_EDIT = BTN_EDIT;
            Globals.IMAGES = IMAGES;
            Globals.toolTip1 = toolTip1;
            Globals.EDITING_IMPORTBIGIMAGE = EDITING_IMPORTBIGIMAGE;
            Globals.EDITING_TEXTICON1 = EDITING_TEXTICON1;
            Globals.EDITING_TEXTICON2 = EDITING_TEXTICON2;
            Globals.EDITING_TEXTICON3 = EDITING_TEXTICON3;
            Globals.EDITING_TYPE1 = EDITING_TYPE1;
            Globals.EDITING_TYPE2 = EDITING_TYPE2;
            Globals.EDITING_IMPORTSIZECOMPIMAGE = EDITING_IMPORTSIZECOMPIMAGE;
            Globals.EDITING_BASESTATS = EDITING_BASESTATS;
            Globals.EDITING_ATTACKLIST = EDITING_ATTACKLIST;
            Globals.EDITING_EVOLIST = EDITING_EVOLIST;
            Globals.EDITING_ALTFORMS = EDITING_ALTFORMS;
            Globals.BTN_GRIDVIEW = BTN_GRIDVIEW;

            // Make our form's backcolor a special color, then make it transparent.
            this.BackColor = Color.FromArgb(3, 252, 28);
            this.TransparencyKey = Color.FromArgb(3, 252, 28);

            // Change ATTACKLIST FlowDirection value! Also, no wrapping and show scrollbar!
            ATTACKLIST.FlowDirection = FlowDirection.TopDown;
            ATTACKLIST.WrapContents = false;
            ATTACKLIST.AutoScroll = true;

            // Change EVO imageboxes to stretch images!
            EVO1.SizeMode = PictureBoxSizeMode.StretchImage;
            EVO2.SizeMode = PictureBoxSizeMode.StretchImage;
            EVO3.SizeMode = PictureBoxSizeMode.StretchImage;

            // No weird white border on buttons when form is out of focus...
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            BTN_EDIT.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            BTN_ADD.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            BTN_SAVE.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            BTN_DELETE.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_IMPORTBIGIMAGE.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_IMPORTSIZECOMPIMAGE.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_BASESTATS.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_ATTACKLIST.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_EVOLIST.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            EDITING_ALTFORMS.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            BTN_CLOSE_DEX.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            BTN_GRIDVIEW.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            //string currentdir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string currentdir = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string parentdir = Path.GetDirectoryName(currentdir);

            string FirstPokemonID = "";

            if (Directory.Exists(parentdir + "\\POKEDEX"))
            {
                Globals.MainPokedexDirectory = parentdir + "\\POKEDEX";

                var directories = Directory.GetDirectories(parentdir + "\\POKEDEX");
                foreach (string dir in directories)
                {
                    if (File.Exists(dir + "\\data.xml"))
                    {
                        XmlDocument PokeData = new XmlDocument();
                        PokeData.Load(dir + "\\data.xml");

                        string dirName = new DirectoryInfo(dir).Name;
                        DataRow workRow = Globals.POKEDEX_DATA.NewRow();

                        workRow["ID"] = dirName;

                        string currentlyProcessedPkmnImage = "";

                        if (FirstPokemonID == "")
                        {
                            FirstPokemonID = dirName;
                        }

                        foreach (XmlNode node in PokeData.DocumentElement.ChildNodes)
                        {
                            switch (node.Name)
                            {
                                case "Name":
                                    string StrName = node.InnerText;
                                    workRow["Name"] = StrName;
                                    break;

                                case "Type1":
                                    string StrType1 = node.InnerText;
                                    workRow["Type1"] = StrType1;
                                    break;

                                case "Type2":
                                    string StrType2 = node.InnerText;
                                    workRow["Type2"] = StrType2;
                                    break;

                                case "Description":
                                    string StrDescription = node.InnerText;
                                    StrDescription = StrDescription.Replace("\\n", "\n");
                                    workRow["Description"] = StrDescription;
                                    break;

                                case "Stats":
                                    string StrStats = node.InnerText;
                                    foreach (string thing in StrStats.Split(" "))
                                    {
                                        if (thing.Contains("Attack=") && !thing.Contains("SpAttack="))
                                        {
                                            string AtkValue = thing.Split("Attack=")[1];
                                            workRow["ATK"] = AtkValue;
                                        }
                                        else if (thing.Contains("Defense=") && !thing.Contains("SpDefense="))
                                        {
                                            string DefValue = thing.Split("Defense=")[1];
                                            workRow["DEF"] = DefValue;
                                        }
                                        else if (thing.Contains("SpAttack="))
                                        {
                                            string SpAtkValue = thing.Split("SpAttack=")[1];
                                            workRow["SPATK"] = SpAtkValue;
                                        }
                                        else if (thing.Contains("SpDefense="))
                                        {
                                            string SpDefValue = thing.Split("SpDefense=")[1];
                                            workRow["SPDEF"] = SpDefValue;
                                        }
                                        else if (thing.Contains("Speed="))
                                        {
                                            string SpeedValue = thing.Split("Speed=")[1];
                                            workRow["SPEED"] = SpeedValue;
                                        }
                                        else if (thing.Contains("Hp="))
                                        {
                                            string HPValue = thing.Split("Hp=")[1];
                                            workRow["HP"] = HPValue;
                                        }
                                    }
                                    break;

                                case "PhysicalStats":
                                    string StrPhysStats = node.InnerText;
                                    foreach (string thing in StrPhysStats.Split(" "))
                                    {
                                        if (thing.Contains("Height="))
                                        {
                                            string HeightValue = thing.Split("Height=")[1];
                                            workRow["Height"] = HeightValue;
                                        }
                                        else if (thing.Contains("Weight="))
                                        {
                                            string HeightValue = thing.Split("Weight=")[1];
                                            workRow["Weight"] = HeightValue;
                                        }
                                    }
                                    break;

                                case "AttackList":
                                    if (node.HasChildNodes)
                                    {
                                        List<Dictionary<string, string>> NewAtkList = new List<Dictionary<string, string>>();

                                        foreach (XmlNode subnode in node.ChildNodes)
                                        {
                                            string StrAtkTxt = subnode.InnerText;
                                            Dictionary<string, string> AtkDict = new Dictionary<string, string>();

                                            string CurrentAtkName = "";
                                            string CurrentAtkType = "";
                                            string CurrentAtkDescr = "";

                                            foreach (string thing in StrAtkTxt.Split(" "))
                                            {
                                                if (thing.Contains("Level="))
                                                {
                                                    string StrLevelAtk = thing.Split("=")[1];
                                                    AtkDict.Add("Level", StrLevelAtk);
                                                }
                                                else if (thing.Contains("MoveName="))
                                                {
                                                    CurrentAtkName = thing.Split("=")[1];
                                                    //StrMoveNameAtk = StrMoveNameAtk.Replace("\"", "");
                                                    CurrentAtkName = CurrentAtkName.Replace("_", " ");
                                                    AtkDict.Add("MoveName", CurrentAtkName);
                                                }
                                                else if (thing.Contains("Type="))
                                                {
                                                    CurrentAtkType = thing.Split("=")[1];
                                                    AtkDict.Add("Type", CurrentAtkType);
                                                }
                                                else if (thing.Contains("Description="))
                                                {
                                                    CurrentAtkDescr = thing.Split("=")[1];
                                                    CurrentAtkDescr = CurrentAtkDescr.Replace("_", " ");
                                                    CurrentAtkDescr = CurrentAtkDescr.Replace("\\n", "\r\n");
                                                    AtkDict.Add("Description", CurrentAtkDescr);
                                                }
                                            }

                                            NewAtkList.Add(AtkDict);
                                            Globals.AttackTemplates.Add(AtkDict);
                                        }

                                        workRow["AttackList"] = NewAtkList;
                                    }
                                    break;

                                case "Ability":
                                    string StrAbility = node.InnerText;
                                    StrAbility = StrAbility.Replace("\\n", "\n");
                                    workRow["AbilityDescription"] = StrAbility;
                                    break;

                                case "ConceptOrigin":
                                    string StrConceptOrigin = node.InnerText;
                                    StrConceptOrigin = StrConceptOrigin.Replace("\\n", "\n");
                                    workRow["ConceptOrigin"] = StrConceptOrigin;
                                    break;

                                case "BaseImage":
                                    string StrBaseImage = node.InnerText;
                                    workRow["BaseImage"] = StrBaseImage;
                                    currentlyProcessedPkmnImage = StrBaseImage;
                                    break;

                                case "ShinyImage":
                                    string StrShinyImage = node.InnerText;
                                    workRow["ShinyImage"] = StrShinyImage;
                                    break;

                                case "SizeComparisonImage":
                                    string StrSizeComparisonImage = node.InnerText;
                                    workRow["SizeComparisonImage"] = StrSizeComparisonImage;
                                    break;

                                case "AlternateForms":
                                    if (node.HasChildNodes)
                                    {
                                        List<Dictionary<string, string>> NewAltFormsList = new List<Dictionary<string, string>>();

                                        foreach (XmlNode subnode in node.ChildNodes)
                                        {
                                            string StrAltFrmTxt = subnode.InnerText;
                                            Dictionary<string, string> AltFormDict = new Dictionary<string, string>();

                                            foreach (string thing in StrAltFrmTxt.Split(" "))
                                            {
                                                if (thing.Contains("FormName="))
                                                {
                                                    string StrAltFormName = thing.Split("=")[1];
                                                    StrAltFormName = StrAltFormName.Replace("_", " ");
                                                    AltFormDict.Add("FormName", StrAltFormName);
                                                }
                                                else if (thing.Contains("BaseImage="))
                                                {
                                                    string StrAltBaseImg = thing.Split("=")[1];
                                                    AltFormDict.Add("BaseImage", StrAltBaseImg);
                                                }
                                                else if (thing.Contains("ShinyImage="))
                                                {
                                                    string StrAltShinyImg = thing.Split("=")[1];
                                                    AltFormDict.Add("ShinyImage", StrAltShinyImg);
                                                }
                                            }
                                            NewAltFormsList.Add(AltFormDict);
                                        }

                                        workRow["AlternateForms"] = NewAltFormsList;
                                    }
                                    break;

                                case "Stage1":
                                    string StrStage1Txt = node.InnerText;
                                    if (StrStage1Txt == "This_Pokemon")
                                    {
                                        workRow["Stage1ID"] = dirName;
                                        workRow["Stage1Image"] = currentlyProcessedPkmnImage;
                                    }
                                    else if (StrStage1Txt == "None")
                                    {
                                        // Do nothing;
                                    }
                                    else if (StrStage1Txt.Contains("ID=") && StrStage1Txt.Contains("Image="))
                                    {
                                        foreach (string thing in StrStage1Txt.Split(" "))
                                        {
                                            if (thing.Contains("ID="))
                                            {
                                                string Stage1IDTxt = thing.Split("=")[1];
                                                workRow["Stage1ID"] = Stage1IDTxt;
                                            }
                                            else if (thing.Contains("Image="))
                                            {
                                                string Stage1ImageTxt = thing.Split("=")[1];
                                                workRow["Stage1Image"] = Stage1ImageTxt;
                                            }
                                        }
                                    }
                                    break;

                                case "Stage2":
                                    string StrStage2Txt = node.InnerText;
                                    if (StrStage2Txt == "This_Pokemon")
                                    {
                                        workRow["Stage2ID"] = dirName;
                                        workRow["Stage2Image"] = currentlyProcessedPkmnImage;
                                    }
                                    else if (StrStage2Txt == "None")
                                    {
                                        // Do nothing;
                                    }
                                    else if (StrStage2Txt.Contains("ID=") && StrStage2Txt.Contains("Image="))
                                    {
                                        foreach (string thing in StrStage2Txt.Split(" "))
                                        {
                                            if (thing.Contains("ID="))
                                            {
                                                string Stage2IDTxt = thing.Split("=")[1];
                                                workRow["Stage2ID"] = Stage2IDTxt;
                                            }
                                            else if (thing.Contains("Image="))
                                            {
                                                string Stage2ImageTxt = thing.Split("=")[1];
                                                workRow["Stage2Image"] = Stage2ImageTxt;
                                            }
                                        }
                                    }
                                    break;

                                case "Stage3":
                                    string StrStage3Txt = node.InnerText;
                                    if (StrStage3Txt == "This_Pokemon")
                                    {
                                        workRow["Stage3ID"] = dirName;
                                        workRow["Stage3Image"] = currentlyProcessedPkmnImage;
                                    }
                                    else if (StrStage3Txt == "None")
                                    {
                                        // Do nothing;
                                    }
                                    else if (StrStage3Txt.Contains("ID=") && StrStage3Txt.Contains("Image="))
                                    {
                                        foreach (string thing in StrStage3Txt.Split(" "))
                                        {
                                            if (thing.Contains("ID="))
                                            {
                                                string Stage3IDTxt = thing.Split("=")[1];
                                                workRow["Stage3ID"] = Stage3IDTxt;
                                            }
                                            else if (thing.Contains("Image="))
                                            {
                                                string Stage3ImageTxt = thing.Split("=")[1];
                                                workRow["Stage3Image"] = Stage3ImageTxt;
                                            }
                                        }
                                    }
                                    break;

                                case "Stage1To2EvoMethod":
                                    string StrStage1To2EvoMethod = node.InnerText;
                                    if (StrStage1To2EvoMethod == "None")
                                    {
                                        // Do nothing;
                                    }
                                    else
                                    {
                                        workRow["Stage1To2EvoMethod"] = StrStage1To2EvoMethod;
                                    }
                                    break;

                                case "Stage2To3EvoMethod":
                                    string StrStage2To3EvoMethod = node.InnerText;
                                    if (StrStage2To3EvoMethod == "None")
                                    {
                                        // Do nothing;
                                    }
                                    else
                                    {
                                        workRow["Stage2To3EvoMethod"] = StrStage2To3EvoMethod;
                                    }
                                    break;
                            }
                        }

                        // Check if Pokemon has no evo and add a proper line in case that's a thing
                        if ((workRow["Stage1ID"] == null || workRow["Stage1ID"].ToString() == "") &&
                            (workRow["Stage2ID"] == null || workRow["Stage2ID"].ToString() == "") &&
                            (workRow["Stage3ID"] == null || workRow["Stage3ID"].ToString() == "") &&
                            (workRow["Stage1To2EvoMethod"] == null || workRow["Stage1To2EvoMethod"].ToString() == ""))
                        {
                            workRow["Stage1To2EvoMethod"] = "This creature does not evolve.";
                        }

                        Globals.POKEDEX_DATA.Rows.Add(workRow);
                    }
                }

                // When starting the Pokedex, always start on first Pokemon
                FormRefresher.Refresh(FirstPokemonID);
                FormRefresher.BuildSearch();

                // Dex editing is disabled by default.
                FormRefresher.DexEditingWrangler(false);
            }
            else
            {
                MessageBox.Show("'POKEDEX' directory not found! Could not load data!", "Data Load Error");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HEIGHTNUM_Click(object sender, EventArgs e)
        {

        }

        private void EVO1_Click(object sender, EventArgs e)
        {
            if (Globals.EVO1.Tag != null && !string.IsNullOrEmpty(Globals.EVO1.Tag.ToString()))
            {
                FormRefresher.Refresh(Globals.EVO1.Tag.ToString());
            }
        }

        private void EVO2_Click(object sender, EventArgs e)
        {
            if (Globals.EVO2.Tag != null && !string.IsNullOrEmpty(Globals.EVO2.Tag.ToString()))
            {
                FormRefresher.Refresh(Globals.EVO2.Tag.ToString());
            }
        }

        private void EVO3_Click(object sender, EventArgs e)
        {
            if (Globals.EVO3.Tag != null && !string.IsNullOrEmpty(Globals.EVO3.Tag.ToString()))
            {
                FormRefresher.Refresh(Globals.EVO3.Tag.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRefresher.Refresh(Globals.PokeSearch.Text.Split(" ")[0]);
        }

        private void button1_MouseDown(object sender, EventArgs e)
        {
            Globals.button1.Image.Dispose();
            Bitmap bm1 = new Bitmap(Properties.Resources.fakedexbackground_GOBUTTON_press);
            Globals.button1.Image = bm1;
        }

        private void button1_MouseUp(object sender, EventArgs e)
        {
            Globals.button1.Image.Dispose();
            Bitmap bm2 = new Bitmap(Properties.Resources.fakedexbackground_GOBUTTON);
            Globals.button1.Image = bm2;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((this.ActiveControl == PokeSearch) && (keyData == Keys.Return))
            {
                FormRefresher.Refresh(Globals.PokeSearch.Text.Split(" ")[0]);
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void BTN_ADD_MouseDown(object sender, EventArgs e)
        {
            if (Globals.BTN_ADD.Enabled)
            {
                Globals.BTN_ADD.Image.Dispose();
                Bitmap bm1 = new Bitmap(Properties.Resources.button_add_pressed);
                Globals.BTN_ADD.Image = bm1;
            }
        }

        private void BTN_ADD_MouseUp(object sender, EventArgs e)
        {
            if (Globals.BTN_ADD.Enabled)
            {
                Bitmap bm2 = new Bitmap(Properties.Resources.button_add);
                Globals.BTN_ADD.Image = bm2;
            }
        }

        private void BTN_SAVE_MouseDown(object sender, EventArgs e)
        {
            if (Globals.BTN_SAVE.Enabled)
            {
                Bitmap bm1 = new Bitmap(Properties.Resources.button_sav_pressed);
                Globals.BTN_SAVE.Image = bm1;
            }
        }

        private void BTN_SAVE_MouseUp(object sender, EventArgs e)
        {
            if (Globals.BTN_SAVE.Enabled)
            {
                Bitmap bm2 = new Bitmap(Properties.Resources.button_sav);
                Globals.BTN_SAVE.Image = bm2;
            }
        }

        private void BTN_DELETE_MouseDown(object sender, EventArgs e)
        {
            if (Globals.BTN_DELETE.Enabled)
            {
                Bitmap bm1 = new Bitmap(Properties.Resources.button_del_pressed);
                Globals.BTN_DELETE.Image = bm1;
            }
        }

        private void BTN_DELETE_MouseUp(object sender, EventArgs e)
        {
            if (Globals.BTN_DELETE.Enabled)
            {
                Bitmap bm2 = new Bitmap(Properties.Resources.button_del);
                Globals.BTN_DELETE.Image = bm2;
            }
        }

        private void BTN_EDIT_Click(object sender, EventArgs e)
        {
            // Enable when disabled, disable when enabled
            if (Globals.IsDexEditingEnabled)
            {
                FormRefresher.DexEditingWrangler(false);
                FormRefresher.Refresh(Globals.CurrentPokemonID);
            }
            else
            {
                FormRefresher.DexEditingWrangler(true);
            }
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            if (Globals.IsDexEditingEnabled)
            {
                FormRefresher.DexEditingSaver();
            }
        }

        private void CONCEPTDESCR_LostFocus(object sender, EventArgs e)
        {
            if (Globals.IsDexEditingEnabled)
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if ((string)row["ID"] != Globals.CurrentPokemonID)
                    {
                        continue;
                    }

                    Globals.CONCEPTDESCR.Text = Globals.CONCEPTDESCR.Text.Replace("<", "");
                    Globals.CONCEPTDESCR.Text = Globals.CONCEPTDESCR.Text.Replace(">", "");

                    row["ConceptOrigin"] = Globals.CONCEPTDESCR.Text;

                    //Changes were probably made...
                    Globals.DEX_UNSAVED_CHANGES = true;

                    break;
                }
            }
        }

        private void DESCRBOX_LostFocus(object sender, EventArgs e)
        {
            if (Globals.IsDexEditingEnabled)
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if ((string)row["ID"] != Globals.CurrentPokemonID)
                    {
                        continue;
                    }

                    Globals.DESCRBOX.Text = Globals.DESCRBOX.Text.Replace("<", "");
                    Globals.DESCRBOX.Text = Globals.DESCRBOX.Text.Replace(">", "");

                    row["Description"] = Globals.DESCRBOX.Text;

                    //Changes were probably made...
                    Globals.DEX_UNSAVED_CHANGES = true;

                    break;
                }
            }
        }

        private void ABILDESCR_LostFocus(object sender, EventArgs e)
        {
            if (Globals.IsDexEditingEnabled)
            {
                foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
                {
                    if ((string)row["ID"] != Globals.CurrentPokemonID)
                    {
                        continue;
                    }

                    Globals.ABILDESCR.Text = Globals.ABILDESCR.Text.Replace("<", "");
                    Globals.ABILDESCR.Text = Globals.ABILDESCR.Text.Replace(">", "");

                    row["AbilityDescription"] = Globals.ABILDESCR.Text;

                    //Changes were probably made...
                    Globals.DEX_UNSAVED_CHANGES = true;

                    break;
                }
            }
        }


        // Allow dragging the Pokedex application around with mouse!

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // Exit the application on special button press.

        private void BTN_CLOSE_DEX_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.IsDisposed)
            {
                Application.Exit();
            }
        }

        private void BTN_DELETE_Click(object sender, EventArgs e)
        {
            Form Confirmation = new DeleteConfirmation();
            if (Confirmation.ShowDialog(this) == DialogResult.Yes)
            {
                FormRefresher.DexEditingDeleter();
            }
        }

        private void BTN_ADD_Click(object sender, EventArgs e)
        {
            Form AddNewPkmnDialog = new AddPkmnPanel();
            if (AddNewPkmnDialog.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.DexEditingAdder();
            }
        }

        private void EDITING_IMPORTBIGIMAGE_Click(object sender, EventArgs e)
        {
            foreach (dynamic SelectedTabControl in Globals.IMAGES.SelectedTab.Controls)
            { 
                if (SelectedTabControl.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    FormRefresher.DexEditingBigImgImporter(SelectedTabControl);
                    break;
                }
            }
        }

        private void EDITING_IMPORTBIGIMAGE_MouseDown(object sender, EventArgs e)
        {
            if (Globals.EDITING_IMPORTBIGIMAGE.Visible)
            {
                Bitmap bm3 = new Bitmap(Properties.Resources.upload_pic_press_small);
                Globals.EDITING_IMPORTBIGIMAGE.Image = bm3;
            }
        }

        private void EDITING_IMPORTBIGIMAGE_MouseUp(object sender, EventArgs e)
        {
            if (Globals.EDITING_IMPORTBIGIMAGE.Visible)
            {
                Bitmap bm3 = new Bitmap(Properties.Resources.upload_pic_small);
                Globals.EDITING_IMPORTBIGIMAGE.Image = bm3;
            }
        }

        // Edit Size Comparison Image

        private void EDITING_IMPORTSIZECOMPIMAGE_Click(object sender, EventArgs e)
        {
            FormRefresher.DexEditingBigImgImporter(Globals.SIZECOMP);
        }

        private void EDITING_IMPORTSIZECOMPIMAGE_MouseDown(object sender, EventArgs e)
        {
            if (Globals.EDITING_IMPORTSIZECOMPIMAGE.Visible)
            {
                Bitmap bm3 = new Bitmap(Properties.Resources.upload_pic_press_small);
                Globals.EDITING_IMPORTBIGIMAGE.Image = bm3;
            }
        }

        private void EDITING_IMPORTSIZECOMPIMAGE_MouseUp(object sender, EventArgs e)
        {
            if (Globals.EDITING_IMPORTSIZECOMPIMAGE.Visible)
            {
                Bitmap bm3 = new Bitmap(Properties.Resources.upload_pic_small);
                Globals.EDITING_IMPORTSIZECOMPIMAGE.Image = bm3;
            }
        }

        // Edit types

        private void EDITING_TYPE1_Changed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Globals.TYPE1.Text.Trim()))
            {
                Globals.TYPE1.Text = Globals.EDITING_TYPE1.Text.Trim().ToUpper();
                Globals.TYPE1.Image = FormRefresher.ResolveTypeImage(Globals.EDITING_TYPE1.Text);
            }
            else
            {
                Globals.TYPE1.Hide();
            }

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    row["Type1"] = Globals.EDITING_TYPE1.Text.Trim();
                }
            }
        }

        private void EDITING_TYPE2_Changed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Globals.TYPE2.Text.Trim()))
            {
                Globals.TYPE2.Text = Globals.EDITING_TYPE2.Text.Trim().ToUpper();
                Globals.TYPE2.Image = FormRefresher.ResolveTypeImage(Globals.EDITING_TYPE2.Text);
            }
            else
            {
                Globals.TYPE2.Hide();
            }

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    row["Type2"] = Globals.EDITING_TYPE2.Text.Trim();
                }
            }
        }

        private void EDITING_BASESTATS_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt_pressed);
            EDITING_BASESTATS.Image = bm3;
        }

        private void EDITING_BASESTATS_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt);
            EDITING_BASESTATS.Image = bm3;
        }

        private void EDITING_BASESTATS_Click(object sender, EventArgs e)
        {
            Form EditBaseStatsDialog = new EditBaseStatsPanel();
            if (EditBaseStatsDialog.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.DexEditingBaseStatsModifier();
            }
        }

        private void EDITING_ATTACKLIST_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt_pressed);
            EDITING_ATTACKLIST.Image = bm3;
        }

        private void EDITING_ATTACKLIST_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt);
            EDITING_ATTACKLIST.Image = bm3;
        }

        private void EDITING_ATTACKLIST_Click(object sender, EventArgs e)
        {
            Form EditAttackListDialog = new EditAttackListPanel();
            if (EditAttackListDialog.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.Refresh(Globals.CurrentPokemonID);
            }
        }

        private void EDITING_EVOLIST_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt_pressed);
            EDITING_EVOLIST.Image = bm3;
        }

        private void EDITING_EVOLIST_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt);
            EDITING_EVOLIST.Image = bm3;
        }

        private void EDITING_EVOLIST_Click(object sender, EventArgs e)
        {
            Form EditEvoListDialog = new EditEvoLineForm();
            if (EditEvoListDialog.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.Refresh(Globals.CurrentPokemonID);
            }
        }

        private void EDITING_ALTFORMS_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt_pressed);
            EDITING_ALTFORMS.Image = bm3;
        }

        private void EDITING_ALTFORMS_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm3 = new Bitmap(Properties.Resources.button_edt);
            EDITING_ALTFORMS.Image = bm3;
        }

        private void EDITING_ALTFORMS_Click(object sender, EventArgs e)
        {
            Form AltFormEditDialog = new AltFormEditForm();
            if (AltFormEditDialog.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.Refresh(Globals.CurrentPokemonID);
            }
        }

        // New code - Added on 23.10.2021 - New feature - Grid View
        private void BTN_GRIDVIEW_Click(object sender, EventArgs e)
        {
            Form GridDisplayWindow = new Form9();
            if (GridDisplayWindow.ShowDialog(this) == DialogResult.OK)
            {
                FormRefresher.Refresh(Globals.CurrentPokemonID);
            }
        }

        private void BTN_GRIDVIEW_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm93 = new Bitmap(Properties.Resources.button_tileview_pressed);
            BTN_GRIDVIEW.Image = bm93;
        }

        private void BTN_GRIDVIEW_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm93 = new Bitmap(Properties.Resources.button_tileview);
            BTN_GRIDVIEW.Image = bm93;
        }
        // New code end

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // Are there any unsaved changes?
            if (Globals.DEX_UNSAVED_CHANGES == true)
            {
                Form Confirmation = new DeleteConfirmation();
                foreach (dynamic ctrl in Confirmation.Controls)
                {
                    if (ctrl.GetType().Name.Contains("Label"))
                    {
                        ctrl.Text = "       Exit while there are unsaved changes?";
                        break;
                    }
                }

                if (Confirmation.ShowDialog(this) == DialogResult.No)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                }
                else
                {
                    // Delete new unsaved images
                    FormRefresher.DoActualPokemonImagesDeletion(Globals.NewImagesToDelete);

                    // Get rid of empty folders in main Pokedex directory
                    string[] subdirectoryEntries = Directory.GetDirectories(Globals.MainPokedexDirectory);
                    foreach (string subDir in subdirectoryEntries)
                    {
                        if (!Directory.EnumerateFileSystemEntries(subDir).Any())
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(subDir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        }
                    }
                }
            }
        }
    }

    public static class Globals
    {
        public static DataTable POKEDEX_DATA = new DataTable
        {
            Columns = {
                { "ID", typeof(string) },
                { "Name", typeof(string) },
                { "Type1", typeof(string) },
                { "Type2", typeof(string) },
                { "Description", typeof(string) },
                { "HP", typeof(string) },
                { "ATK", typeof(string) },
                { "DEF", typeof(string) },
                { "SPATK", typeof(string) },
                { "SPDEF", typeof(string) },
                { "SPEED", typeof(string) },
                { "Height", typeof(string) },
                { "Weight", typeof(string) },
                { "AttackList", typeof(List<Dictionary<string, string>>) },
                { "AbilityDescription", typeof(string) },
                { "ConceptOrigin", typeof(string) },
                { "BaseImage", typeof(string) },
                { "ShinyImage", typeof(string) },
                { "SizeComparisonImage", typeof(string) },
                { "AlternateForms", typeof(List<Dictionary<string, string>>) },
                { "Stage1ID", typeof(string) },
                { "Stage1Image", typeof(string) },
                { "Stage2ID", typeof(string) },
                { "Stage2Image", typeof(string) },
                { "Stage3ID", typeof(string) },
                { "Stage3Image", typeof(string) },
                { "Stage1To2EvoMethod", typeof(string) },
                { "Stage2To3EvoMethod", typeof(string) },
            },
            //Rows = { { 0 } }
        };

        public static string MainPokedexDirectory;

        public static bool IsDexEditingEnabled;

        public static string CurrentPokemonID;

        public static List<string> PokemonToDelete = new List<string>();

        public static Label label1;
        public static Label ATKNUM;
        public static Label DEFNUM;
        public static Label SPDNUM;
        public static Label HPNUM;
        public static Label HEIGHTNUM;
        public static Label WEIGHTNUM;
        public static Label TYPE1;
        public static Label TYPE2;
        public static PictureBox pictureBox1;
        public static PictureBox pictureBox2;
        public static PictureBox SIZECOMP;
        public static RichTextBox DESCRBOX;
        public static RichTextBox CONCEPTDESCR;
        public static RichTextBox ABILDESCR;
        public static FlowLayoutPanel ATTACKLIST;
        public static PictureBox EVO1;
        public static PictureBox EVO2;
        public static PictureBox EVO3;
        public static Label EVOTYPE1;
        public static Label EVOTYPE2;
        public static ComboBox PokeSearch;
        public static Button button1;
        public static Label NOEVO;
        public static Button BTN_SAVE;
        public static Button BTN_ADD;
        public static Button BTN_DELETE;
        public static Button BTN_EDIT;
        public static TabControl IMAGES;
        public static ToolTip toolTip1;
        public static Button EDITING_IMPORTBIGIMAGE;
        public static Label EDITING_TEXTICON1;
        public static Label EDITING_TEXTICON2;
        public static Label EDITING_TEXTICON3;
        public static ComboBox EDITING_TYPE1;
        public static ComboBox EDITING_TYPE2;
        public static Button EDITING_IMPORTSIZECOMPIMAGE;
        public static Button EDITING_BASESTATS;
        public static Button EDITING_ATTACKLIST;
        public static Button EDITING_EVOLIST;
        public static Button EDITING_ALTFORMS;
        public static Button BTN_GRIDVIEW;

        public static List<string> OldImagesToDelete = new List<string>();
        public static List<string> NewImagesToDelete = new List<string>();

        public static bool DEX_UNSAVED_CHANGES = false;

        // Form2 (Delete Confirmation)
        //public static Button BTN_YES;
        //public static Button BTN_NO;

        // Form3 (Add New Pokemon Dialog)
        public static string Request_NewPkmnDexID;
        public static string Request_NewPkmnName;

        public static List<string> IllegalChars = new List<string>
        {
            " ",
            "#",
            "&",
            "{",
            "}",
            "\\",
            "<",
            ">",
            "*",
            "?",
            "/",
            "$",
            "!",
            "'",
            "\"",
            ":",
            "@",
            "+",
            "`",
            "|",
            "=",
        };

        // Form4 (Edit Base Stats)
        public static string Request_NewBaseHP;
        public static string Request_NewBaseATK;
        public static string Request_NewBaseDEF;
        public static string Request_NewBaseSPD;
        public static string Request_NewBaseWT;
        public static string Request_NewBaseHT;

        // Form5 (Edit AttackList)
        public static List<Dictionary<string, string>> AttackTemplates = new List<Dictionary<string, string>>();
        public static TextBox TXT_ATTACKNAME;
        public static TextBox TXT_ATTACKLEVEL;
        public static TextBox TXT_ATTACKTYPE;
        public static TextBox TXT_ATTACKDESCR;
        public static Button AtkListButtonChosenForEditing;

        // Form6 (Edit Evolution List)
    }

    public static class FormRefresher
    {
        public static void Refresh(string PokemonID)
        {
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] != PokemonID)
                {
                    continue;
                }

                Globals.ATTACKLIST.Controls.Clear();

                foreach (TabPage PokemonFormImg in Globals.IMAGES.TabPages)
                {
                    if (PokemonFormImg.Name != "imgnormal" && PokemonFormImg.Name != "imgshiny")
                    {
                        Globals.IMAGES.TabPages.Remove(PokemonFormImg);
                    }
                }

                Globals.CurrentPokemonID = (string)row["ID"];

                // Convert values which may be null to string to prevent crashes

                Globals.PokeSearch.Text = (string)row["ID"] + " " + row["Name"].ToString();

                Globals.label1.Text = "#" + (string)row["ID"] + " " + row["Name"].ToString();

                Globals.ATKNUM.Text = row["ATK"].ToString();
                Globals.DEFNUM.Text = row["DEF"].ToString();
                Globals.SPDNUM.Text = row["SPEED"].ToString();
                Globals.HPNUM.Text = row["HP"].ToString();

                Globals.TYPE1.Text = row["Type1"].ToString().ToUpper();
                if (row["Type1"].ToString() != "")
                {
                    Globals.TYPE1.Show();
                    Globals.TYPE1.Image = FormRefresher.ResolveTypeImage(row["Type1"].ToString());
                    Globals.EDITING_TYPE1.SelectedIndex = Globals.EDITING_TYPE1.FindStringExact(row["Type1"].ToString());
                }
                else
                {
                    Globals.TYPE1.Hide();
                    Globals.EDITING_TYPE1.SelectedItem = null;
                }

                Globals.TYPE2.Text = row["Type2"].ToString().ToUpper();
                if (row["Type2"].ToString() != "")
                {
                    Globals.TYPE2.Show();
                    Globals.TYPE2.Image = FormRefresher.ResolveTypeImage(row["Type2"].ToString());
                    Globals.EDITING_TYPE2.SelectedIndex = Globals.EDITING_TYPE2.FindStringExact(row["Type2"].ToString());
                }
                else
                {
                    Globals.TYPE2.Hide();
                    Globals.EDITING_TYPE2.SelectedItem = null;
                }

                Globals.DESCRBOX.Text = row["Description"].ToString();
                Globals.ABILDESCR.Text = row["AbilityDescription"].ToString();
                Globals.CONCEPTDESCR.Text = row["ConceptOrigin"].ToString();

                Globals.HEIGHTNUM.Text = row["Height"].ToString();
                Globals.WEIGHTNUM.Text = row["Weight"].ToString();

                if (row["Stage1To2EvoMethod"].ToString() != "This creature does not evolve.")
                {
                    Globals.NOEVO.Hide();
                    Globals.EVOTYPE1.Show();
                    Globals.EVOTYPE2.Show();
                    Globals.EVOTYPE1.Text = row["Stage1To2EvoMethod"].ToString();
                    Globals.EVOTYPE2.Text = row["Stage2To3EvoMethod"].ToString();
                }
                else
                {
                    Globals.EVOTYPE1.Hide();
                    Globals.EVOTYPE2.Hide();
                    Globals.NOEVO.Show();
                    Globals.NOEVO.Text = row["Stage1To2EvoMethod"].ToString();
                }

                // PART#1: This is a very dumb workaround fix for scrollbar rendering bug.
                Globals.ATTACKLIST.Visible = false;
                Globals.ATTACKLIST.FlowDirection = FlowDirection.LeftToRight;

                List<Dictionary<string, string>> rowAttackList = (List<Dictionary<string, string>>)row["AttackList"];

                if (rowAttackList != null && rowAttackList.Count() > 0)
                {
                    foreach (Dictionary<string, string> AtkDictionary in rowAttackList)
                    {
                        string AttackString = "";
                        Color AtkTypeColor = new Color();
                        string AtkDescString = "";

                        foreach (KeyValuePair<string, string> rowAtk in AtkDictionary)
                        {
                            if (rowAtk.Key == "Level")
                            {
                                AttackString += "Level " + rowAtk.Value + ":";
                            }
                            else if (rowAtk.Key == "MoveName")
                            {
                                AttackString += " " + rowAtk.Value;
                            }
                            else if (rowAtk.Key == "Type")
                            {
                                //string rowAtkUppercase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rowAtk.Value.ToLower());
                                //AttackString += "Type: " + rowAtkUppercase;
                                AtkTypeColor = FormRefresher.ResolveTypeColor(rowAtk.Value);
                            }
                            else if (rowAtk.Key == "Description")
                            {
                                AtkDescString = rowAtk.Value;
                            }
                        }

                        Label newLabel = new Label();
                        Size newSize = new Size(200, 25);
                        newLabel.Size = newSize;
                        newLabel.Text = AttackString;
                        newLabel.ForeColor = AtkTypeColor;

                        if (AtkDescString != "")
                        {
                            string _AtkDescString = AtkDescString.Replace("\r", "");
                            Globals.toolTip1.SetToolTip(newLabel, _AtkDescString);
                        }

                        Globals.ATTACKLIST.Controls.Add(newLabel);
                    }
                }
                // PART#2: This is a very dumb workaround fix for scrollbar rendering bug.
                Globals.ATTACKLIST.FlowDirection = FlowDirection.TopDown;
                Globals.ATTACKLIST.Visible = true;

                // New feature: Import alternate forms!
                List<Dictionary<string, string>> rowAlternateFormList = null;

                if (!(row.IsNull("AlternateForms")))
                {
                    rowAlternateFormList = (List<Dictionary<string, string>>)row["AlternateForms"];
                }

                if (rowAlternateFormList != null && rowAlternateFormList.Count() > 0)
                {
                    foreach (Dictionary<string, string> AltFormDictionary in rowAlternateFormList)
                    {
                        string AltFormNameStr = "";
                        Dictionary<string, string> AltFormImages = new Dictionary<string, string>();

                        AltFormNameStr = AltFormDictionary["FormName"].ToString();

                        foreach (KeyValuePair<string, string> rowAltForm in AltFormDictionary)
                        {
                            if (rowAltForm.Key == "BaseImage")
                            {
                                AltFormImages.Add(AltFormNameStr + "~BaseImage", rowAltForm.Value);
                            }
                            else if (rowAltForm.Key == "ShinyImage")
                            {
                                AltFormImages.Add(AltFormNameStr + "~ShinyImage", rowAltForm.Value);
                            }
                        }

                        foreach (KeyValuePair<string, string> AltFormImage in AltFormImages)
                        {
                            string temp_AltFormNameStr = AltFormNameStr;

                            if (AltFormImage.Key.Contains("~ShinyImage"))
                            {
                                temp_AltFormNameStr = temp_AltFormNameStr + "(S)";
                            }

                            TabPage NewTabPage = new TabPage(temp_AltFormNameStr);
                            NewTabPage.Dock = DockStyle.Fill;
                            NewTabPage.BackColor = Color.FromArgb(39, 42, 44);

                            string AltFormMainImagePath = Globals.MainPokedexDirectory + "\\" + row["ID"].ToString() + "\\" + AltFormImage.Value;
                            if (File.Exists(AltFormMainImagePath))
                            {
                                // Copy bits of the image into the memory instead of accessing them directly from the file.
                                // It's done this way to still allow us to delete contents of the folder.
                                Image MainImage;
                                using (var bmpTemp = new Bitmap(AltFormMainImagePath))
                                {
                                    MainImage = new Bitmap(bmpTemp);
                                }

                                PictureBox NewPictureBox = new PictureBox
                                {
                                    Size = Globals.pictureBox1.Size,
                                    Location = Globals.pictureBox1.Location,
                                    Image = MainImage,
                                    SizeMode = Globals.pictureBox1.SizeMode,
                                    Tag = temp_AltFormNameStr,
                                };

                                NewTabPage.Controls.Add(NewPictureBox);
                            }
                            else
                            {
                                MessageBox.Show("Could not load image of #" + row["ID"].ToString() + " Pokemon's form \"" + AltFormNameStr + "\" from declared path: '" + AltFormMainImagePath + "'!", "Image Load Error");
                            }

                            Globals.IMAGES.TabPages.Add(NewTabPage);
                        }
                    }
                }

                if (!String.IsNullOrEmpty(row["BaseImage"].ToString()))
                {
                    string MainImagePath = Globals.MainPokedexDirectory + "\\" + row["ID"].ToString() + "\\" + row["BaseImage"].ToString();
                    if (File.Exists(MainImagePath))
                    {
                        Image MainImage;
                        using (var bmpTemp = new Bitmap(MainImagePath))
                        {
                            MainImage = new Bitmap(bmpTemp);
                        }

                        Globals.pictureBox1.Image = MainImage;
                    }
                    else
                    {
                        MessageBox.Show("Could not load main Pokemon image from declared path: '" + MainImagePath + "'!", "Image Load Error");

                        Bitmap bmp1 = new Bitmap(Properties.Resources.unknownpoke_image);
                        Globals.pictureBox1.Image = bmp1;
                    }
                }
                else
                {
                    Bitmap bmp1 = new Bitmap(Properties.Resources.unknownpoke_image);
                    Globals.pictureBox1.Image = bmp1;
                }

                if (!String.IsNullOrEmpty(row["ShinyImage"].ToString()))
                {
                    string ShinyImagePath = Globals.MainPokedexDirectory + "\\" + row["ID"].ToString() + "\\" + row["ShinyImage"].ToString();
                    if (File.Exists(ShinyImagePath))
                    {
                        Image ShinyImage;
                        using (var bmpTemp = new Bitmap(ShinyImagePath))
                        {
                            ShinyImage = new Bitmap(bmpTemp);
                        }

                        Globals.pictureBox2.Image = ShinyImage;
                    }
                    else
                    {
                        MessageBox.Show("Could not load shiny Pokemon image from declared path: '" + ShinyImagePath + "'!", "Image Load Error");

                        Bitmap bmp2 = new Bitmap(Properties.Resources.unknownpoke_image);
                        Globals.pictureBox2.Image = bmp2;
                    }
                }
                else
                {
                    Bitmap bmp2 = new Bitmap(Properties.Resources.unknownpoke_image);
                    Globals.pictureBox2.Image = bmp2;
                }

                if (!String.IsNullOrEmpty(row["SizeComparisonImage"].ToString()))
                {
                    string SizeComparisonImagePath = Globals.MainPokedexDirectory + "\\" + row["ID"].ToString() + "\\" + row["SizeComparisonImage"].ToString();
                    if (File.Exists(SizeComparisonImagePath))
                    {
                        Image SizeComparisonImage;
                        using (var bmpTemp = new Bitmap(SizeComparisonImagePath))
                        {
                            SizeComparisonImage = new Bitmap(bmpTemp);
                        }
                        Globals.SIZECOMP.Image = SizeComparisonImage;
                    }
                    else
                    {
                        MessageBox.Show("Could not load size comparison image from declared path: '" + SizeComparisonImagePath + "'!", "Image Load Error");

                        Bitmap bmp3 = new Bitmap(Properties.Resources.unknownpoke_sizeimage);
                        Globals.SIZECOMP.Image = bmp3;
                    }
                }
                else
                {
                    Bitmap bmp3 = new Bitmap(Properties.Resources.unknownpoke_sizeimage);
                    Globals.SIZECOMP.Image = bmp3;
                }

                if (!String.IsNullOrEmpty(row["Stage1ID"].ToString()))
                {
                    string Stage1ImagePath = Globals.MainPokedexDirectory + "\\" + row["Stage1ID"].ToString() + "\\" + row["Stage1Image"].ToString();
                    if (File.Exists(Stage1ImagePath))
                    {
                        Image Stage1Image;
                        using (var bmpTemp = new Bitmap(Stage1ImagePath))
                        {
                            Stage1Image = new Bitmap(bmpTemp);
                        }

                        Globals.EVO1.Image = Stage1Image;
                        Globals.EVO1.Tag = row["Stage1ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Could not load stage 1 image from declared path: '" + Stage1ImagePath + "'!", "Image Load Error");

                        Bitmap bmp4 = new Bitmap(Properties.Resources.unknownpoke_image);
                        Globals.EVO1.Image = bmp4;
                        Globals.EVO1.Tag = row["Stage1ID"].ToString();
                    }
                }
                else
                {
                    Globals.EVO1.Image = null;
                    Globals.EVO1.Tag = null;
                }


                if (!String.IsNullOrEmpty(row["Stage2ID"].ToString()))
                {
                    string Stage2ImagePath = Globals.MainPokedexDirectory + "\\" + row["Stage2ID"].ToString() + "\\" + row["Stage2Image"].ToString();
                    if (File.Exists(Stage2ImagePath))
                    {
                        Image Stage2Image;
                        using (var bmpTemp = new Bitmap(Stage2ImagePath))
                        {
                            Stage2Image = new Bitmap(bmpTemp);
                        }

                        Globals.EVO2.Image = Stage2Image;
                        Globals.EVO2.Tag = row["Stage2ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Could not load stage 2 image from declared path: '" + Stage2ImagePath + "'!", "Image Load Error");

                        Bitmap bmp5 = new Bitmap(Properties.Resources.unknownpoke_image);
                        Globals.EVO2.Image = bmp5;
                        Globals.EVO2.Tag = row["Stage1ID"].ToString();
                    }
                }
                else
                {
                    Globals.EVO2.Image = null;
                    Globals.EVO2.Tag = null;
                }

                if (!String.IsNullOrEmpty(row["Stage3ID"].ToString()))
                {
                    string Stage3ImagePath = Globals.MainPokedexDirectory + "\\" + row["Stage3ID"].ToString() + "\\" + row["Stage3Image"].ToString();
                    if (File.Exists(Stage3ImagePath))
                    {
                        Image Stage3Image;
                        using (var bmpTemp = new Bitmap(Stage3ImagePath))
                        {
                            Stage3Image = new Bitmap(bmpTemp);
                        }

                        Globals.EVO3.Image = Stage3Image;
                        Globals.EVO3.Tag = row["Stage3ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Could not load stage 3 image from declared path: '" + Stage3ImagePath + "'!", "Image Load Error");

                        Bitmap bmp6 = new Bitmap(Properties.Resources.unknownpoke_image);
                        Globals.EVO3.Image = bmp6;
                        Globals.EVO3.Tag = row["Stage1ID"].ToString();
                    }
                }
                else
                {
                    Globals.EVO3.Image = null;
                    Globals.EVO3.Tag = null;
                }
            }
        }

        public static void BuildSearch()
        {
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if (row["ID"].ToString() != "")
                {
                    Globals.PokeSearch.Items.Add(row["ID"].ToString() + " " + row["Name"].ToString());
                }
            }
        }

        public static Color ResolveTypeColor(string StrTypeName)
        {
            Color TypeColor = new Color();
            switch (StrTypeName)
            {
                case "normal":
                    TypeColor = Color.FromName("LightSalmon");
                    break;

                case "fighting":
                    TypeColor = Color.FromName("IndianRed");
                    break;

                case "fairy":
                    TypeColor = Color.FromName("Orchid");
                    break;

                case "water":
                    TypeColor = Color.FromName("DodgerBlue");
                    break;

                case "fire":
                    TypeColor = Color.FromName("Crimson");
                    break;

                case "grass":
                    TypeColor = Color.FromName("LimeGreen");
                    break;

                case "bug":
                    TypeColor = Color.FromName("LightSeaGreen");
                    break;

                case "flying":
                    TypeColor = Color.FromName("Gainsboro");
                    break;

                case "ice":
                    TypeColor = Color.FromName("PaleTurquoise");
                    break;

                case "steel":
                    TypeColor = Color.FromName("LightSteelBlue");
                    break;

                case "dark":
                    TypeColor = Color.FromName("DimGray");
                    break;

                case "ghost":
                    TypeColor = Color.FromName("MediumPurple");
                    break;

                case "psychic":
                    TypeColor = Color.FromName("MediumOrchid");
                    break;

                case "poison":
                    TypeColor = Color.FromName("DarkOrchid");
                    break;

                case "electric":
                    TypeColor = Color.FromName("Gold");
                    break;

                case "dragon":
                    TypeColor = Color.FromName("SlateBlue");
                    break;

                case "rock":
                    TypeColor = Color.FromName("LightSlateGray");
                    break;

                case "ground":
                    TypeColor = Color.FromName("Sienna");
                    break;

                // Custom types!
                case "darkness":
                    TypeColor = Color.FromName("DimGray");
                    break;

                case "earth":
                    TypeColor = Color.FromName("Sienna");
                    break;

                case "generic":
                    TypeColor = Color.FromName("LightSalmon");
                    break;

                case "light":
                    TypeColor = Color.FromName("Gold");
                    break;

                case "nature":
                    TypeColor = Color.FromName("LimeGreen");
                    break;

                case "wind":
                    TypeColor = Color.FromName("Gainsboro");
                    break;

            }
            return TypeColor;
        }

        public static Bitmap ResolveTypeImage(string StrTypeName)
        {
            string ResourceName = "type_" + StrTypeName;

            if (Properties.Resources.ResourceManager.GetObject(ResourceName) == null)
            {
                ResourceName = "type_bug";
            }
            return new Bitmap((Image)Properties.Resources.ResourceManager.GetObject(ResourceName));
        }

        public static void DexEditingWrangler(bool Enabled)
        {
            if (Enabled)
            {
                Globals.IsDexEditingEnabled = true;

                // Allow adding images!
                Globals.EDITING_IMPORTBIGIMAGE.Show();
                Globals.EDITING_IMPORTSIZECOMPIMAGE.Show();

                // Allow text editing in the form!
                Globals.DESCRBOX.ReadOnly = false;
                Globals.ABILDESCR.ReadOnly = false;
                Globals.CONCEPTDESCR.ReadOnly = false;

                // Make the "Edit" button appear pressed
                Globals.BTN_EDIT.Image.Dispose();
                Bitmap bm0 = new Bitmap(Properties.Resources.button_edt_pressed);
                Globals.BTN_EDIT.Image = bm0;

                // Enable buttons (Add, Save, Delete)
                Globals.BTN_ADD.Enabled = true;
                Globals.BTN_SAVE.Enabled = true;
                Globals.BTN_DELETE.Enabled = true;

                // Disable gridview access
                Globals.BTN_GRIDVIEW.Enabled = false;

                Globals.BTN_ADD.Image.Dispose();
                Bitmap bm1 = new Bitmap(Properties.Resources.button_add);
                Globals.BTN_ADD.Image = bm1;

                Globals.BTN_SAVE.Image.Dispose();
                Bitmap bm2 = new Bitmap(Properties.Resources.button_sav);
                Globals.BTN_SAVE.Image = bm2;

                Globals.BTN_DELETE.Image.Dispose();
                Bitmap bm3 = new Bitmap(Properties.Resources.button_del);
                Globals.BTN_DELETE.Image = bm3;

                // Other controls
                Globals.EDITING_TEXTICON1.Show();
                Globals.EDITING_TEXTICON2.Show();
                Globals.EDITING_TEXTICON3.Show();

                Globals.EDITING_TYPE1.Show();
                Globals.EDITING_TYPE2.Show();

                Globals.EDITING_BASESTATS.Show();
                Globals.EDITING_ATTACKLIST.Show();
                Globals.EDITING_EVOLIST.Show();
                Globals.EDITING_ALTFORMS.Show();
            }
            else
            {
                Globals.IsDexEditingEnabled = false;

                // Disallow adding images!
                Globals.EDITING_IMPORTBIGIMAGE.Hide();
                Globals.EDITING_IMPORTSIZECOMPIMAGE.Hide();

                // Block text editing in the form!
                Globals.DESCRBOX.ReadOnly = true;
                Globals.ABILDESCR.ReadOnly = true;
                Globals.CONCEPTDESCR.ReadOnly = true;

                // Make the "Edit" button appear not pressed
                Globals.BTN_EDIT.Image.Dispose();
                Bitmap bm0 = new Bitmap(Properties.Resources.button_edt);
                Globals.BTN_EDIT.Image = bm0;

                // Grey out disabled buttons (Add, Save, Delete)
                Globals.BTN_ADD.Enabled = false;
                Globals.BTN_SAVE.Enabled = false;
                Globals.BTN_DELETE.Enabled = false;

                // Enable gridview access
                Globals.BTN_GRIDVIEW.Enabled = true;

                Globals.BTN_ADD.Image.Dispose();
                Bitmap bm1 = new Bitmap(Properties.Resources.button_add_disabled);
                Globals.BTN_ADD.Image = bm1;

                Globals.BTN_SAVE.Image.Dispose();
                Bitmap bm2 = new Bitmap(Properties.Resources.button_sav_disabled);
                Globals.BTN_SAVE.Image = bm2;

                Globals.BTN_DELETE.Image.Dispose();
                Bitmap bm3 = new Bitmap(Properties.Resources.button_del_disabled);
                Globals.BTN_DELETE.Image = bm3;

                // Other controls
                Globals.EDITING_TEXTICON1.Hide();
                Globals.EDITING_TEXTICON2.Hide();
                Globals.EDITING_TEXTICON3.Hide();

                Globals.EDITING_TYPE1.Hide();
                Globals.EDITING_TYPE2.Hide();

                Globals.EDITING_BASESTATS.Hide();
                Globals.EDITING_ATTACKLIST.Hide();
                Globals.EDITING_EVOLIST.Hide();
                Globals.EDITING_ALTFORMS.Hide();
            }
        }

        public static void DexEditingSaver()
        {
            // Delete requested creatures.
            // A pokemon with an existing ID could have been added.
            // Check if such pokemon exists, and if yes, don't delete its folder.
            FormRefresher.DoActualPokemonFolderDeletion(false);

            // Generate Xml!

            List<string> StringStats = new List<string>(new string[] {
                "Name",
                "Type1",
                "Type2",
                "Stage1To2EvoMethod",
                "Stage2To3EvoMethod",
                "BaseImage",
                "ShinyImage",
                "SizeComparisonImage",
            });

            List<string> FormattedStringStats = new List<string>(new string[] {
                "Description",
                "AbilityDescription",
                "ConceptOrigin",
            });

            // Dictionary<string, List<string>> NormalStats = new Dictionary<string, List<string>>

            Dictionary<string, string> NormalStats = new Dictionary<string, string>
            {
                ["HP"] = "Hp=",
                ["ATK"] = "Attack=",
                ["DEF"] = "Defense=",
                ["SPEED"] = "Speed=",
                ["SPATK"] = "SpAttack=",
                ["SPDEF"] = "SpDefense=",
            };

            Dictionary<string, string> PhysicalStats = new Dictionary<string, string>
            {
                ["Height"] = "Height=",
                ["Weight"] = "Weight=",
            };

            Dictionary<string, string> PokemonStage1Stat = new Dictionary<string, string>
            {
                ["Stage1ID"] = "ID=",
                ["Stage1Image"] = "Image=",
            };

            Dictionary<string, string> PokemonStage2Stat = new Dictionary<string, string>
            {
                ["Stage2ID"] = "ID=",
                ["Stage2Image"] = "Image=",
            };

            Dictionary<string, string> PokemonStage3Stat = new Dictionary<string, string>
            {
                ["Stage3ID"] = "ID=",
                ["Stage3Image"] = "Image=",
            };

            foreach (DataRow Pokemon in Globals.POKEDEX_DATA.Rows)
            {
                string CurrentPkmnXmlDir = Globals.MainPokedexDirectory + "\\" + (string)Pokemon["ID"] + "\\data.xml";
                string CurrentPkmnDir = Globals.MainPokedexDirectory + "\\" + (string)Pokemon["ID"];
                XmlDocument doc = new XmlDocument();

                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode MainXmlNode = doc.CreateElement("Pokemon");
                doc.AppendChild(MainXmlNode);

                string CurrentPkmnNormalStatsString = "";
                string CurrentPkmnPhysicalStatsString = "";
                string CurrentPkmnStage1String = "";
                string CurrentPkmnStage2String = "";
                string CurrentPkmnStage3String = "";

                foreach (DataColumn PkmnStat in Globals.POKEDEX_DATA.Columns)
                {
                    if (StringStats.Contains(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();

                        XmlNode NewStatNode = doc.CreateElement(PkmnStat.ColumnName);
                        NewStatNode.InnerText = StatValue;

                        MainXmlNode.AppendChild(NewStatNode);
                    }
                    else if (FormattedStringStats.Contains(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        StatValue = StatValue.Replace("\n", "\\n");
                        StatValue = StatValue.Replace("\r", "");
                        StatValue = StatValue.Replace("<", "");
                        StatValue = StatValue.Replace(">", "");

                        string ActualXmlNodeName;
                        if (PkmnStat.ColumnName != "AbilityDescription")
                        {
                            ActualXmlNodeName = PkmnStat.ColumnName;
                        }
                        else
                        {
                            ActualXmlNodeName = "Ability";
                        }

                        XmlNode NewStatNode = doc.CreateElement(ActualXmlNodeName);
                        NewStatNode.InnerText = StatValue;

                        MainXmlNode.AppendChild(NewStatNode);
                    }
                    else if (NormalStats.ContainsKey(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        CurrentPkmnNormalStatsString += NormalStats[PkmnStat.ColumnName] + StatValue + " ";
                    }
                    else if (PhysicalStats.ContainsKey(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        CurrentPkmnPhysicalStatsString += PhysicalStats[PkmnStat.ColumnName] + StatValue + " ";
                    }
                    else if (PokemonStage1Stat.ContainsKey(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        CurrentPkmnStage1String += PokemonStage1Stat[PkmnStat.ColumnName] + StatValue + " ";
                    }
                    else if (PokemonStage2Stat.ContainsKey(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        CurrentPkmnStage2String += PokemonStage2Stat[PkmnStat.ColumnName] + StatValue + " ";
                    }
                    else if (PokemonStage3Stat.ContainsKey(PkmnStat.ColumnName))
                    {
                        var StatValue = Pokemon[PkmnStat].ToString();
                        CurrentPkmnStage3String += PokemonStage3Stat[PkmnStat.ColumnName] + StatValue + " ";
                    }
                    else if (PkmnStat.ColumnName == "AlternateForms")
                    {
                        if (Pokemon.IsNull("AlternateForms"))
                        {
                            continue;
                        }

                        List<Dictionary<string, string>> PkmnAltFormList = (List<Dictionary<string, string>>)Pokemon[PkmnStat];

                        XmlNode AlternateFormNode = doc.CreateElement(PkmnStat.ColumnName);
                        MainXmlNode.AppendChild(AlternateFormNode);

                        foreach (Dictionary<string, string> AltFormDictionary in PkmnAltFormList)
                        {
                            string CurrentPkmnAltFormString = "";

                            foreach (KeyValuePair<string, string> AltForm in AltFormDictionary)
                            {
                                if (AltForm.Key.ToString() == "FormName")
                                {
                                    string XmlAltFormName = AltForm.Value.ToString();
                                    XmlAltFormName = XmlAltFormName.Replace(" ", "_");
                                    CurrentPkmnAltFormString += "FormName=" + XmlAltFormName + " ";
                                }
                                else if (AltForm.Key.ToString() == "BaseImage")
                                {
                                    CurrentPkmnAltFormString += "BaseImage=" + AltForm.Value.ToString() + " ";
                                }
                                else if (AltForm.Key.ToString() == "ShinyImage")
                                {
                                    CurrentPkmnAltFormString += "ShinyImage=" + AltForm.Value.ToString() + " ";
                                }
                            }

                            if (CurrentPkmnAltFormString != "")
                            {
                                XmlNode NewAttackNode = doc.CreateElement("Attack");
                                NewAttackNode.InnerText = CurrentPkmnAltFormString.Trim();

                                AlternateFormNode.AppendChild(NewAttackNode);
                            }
                        }
                    }
                    else if (PkmnStat.ColumnName == "AttackList")
                    {
                        List<Dictionary<string, string>> PkmnAttackList = (List<Dictionary<string, string>>)Pokemon[PkmnStat];

                        XmlNode AttackListNode = doc.CreateElement(PkmnStat.ColumnName);
                        MainXmlNode.AppendChild(AttackListNode);

                        foreach (Dictionary<string, string> AtkDictionary in PkmnAttackList)
                        {
                            string CurrentPkmnAttackString = "";

                            foreach (KeyValuePair<string, string> PkmnAtk in AtkDictionary)
                            {
                                if (PkmnAtk.Key.ToString() == "Level")
                                {
                                    CurrentPkmnAttackString += "Level=" + PkmnAtk.Value.ToString() + " ";
                                }
                                else if (PkmnAtk.Key.ToString() == "MoveName")
                                {
                                    string XmlMoveName = PkmnAtk.Value.ToString();
                                    XmlMoveName = XmlMoveName.Replace(" ", "_");
                                    CurrentPkmnAttackString += "MoveName=" + XmlMoveName + " ";
                                }
                                else if (PkmnAtk.Key.ToString() == "Type")
                                {
                                    CurrentPkmnAttackString += "Type=" + PkmnAtk.Value.ToString() + " ";
                                }
                                else if (PkmnAtk.Key.ToString() == "Description")
                                {
                                    string XmlMoveDesc = PkmnAtk.Value.ToString();
                                    XmlMoveDesc = XmlMoveDesc.Replace(" ", "_");
                                    XmlMoveDesc = XmlMoveDesc.Replace("\n", "\\n");
                                    XmlMoveDesc = XmlMoveDesc.Replace("\r", "");
                                    CurrentPkmnAttackString += "Description=" + XmlMoveDesc + " ";
                                }
                            }

                            if (CurrentPkmnAttackString != "")
                            {
                                XmlNode NewAttackNode = doc.CreateElement("Attack");
                                NewAttackNode.InnerText = CurrentPkmnAttackString.Trim();

                                AttackListNode.AppendChild(NewAttackNode);
                            }
                        }
                    }
                }

                if (CurrentPkmnNormalStatsString != null)
                {
                    XmlNode NewStatNode = doc.CreateElement("Stats");
                    NewStatNode.InnerText = CurrentPkmnNormalStatsString.Trim();

                    MainXmlNode.AppendChild(NewStatNode);
                }

                if (CurrentPkmnPhysicalStatsString != null)
                {
                    XmlNode NewStatNode = doc.CreateElement("PhysicalStats");
                    NewStatNode.InnerText = CurrentPkmnPhysicalStatsString.Trim();

                    MainXmlNode.AppendChild(NewStatNode);
                }

                if (CurrentPkmnStage1String != null)
                {
                    XmlNode NewStatNode = doc.CreateElement("Stage1");
                    NewStatNode.InnerText = CurrentPkmnStage1String.Trim();

                    MainXmlNode.AppendChild(NewStatNode);
                }

                if (CurrentPkmnStage2String != null)
                {
                    XmlNode NewStatNode = doc.CreateElement("Stage2");
                    NewStatNode.InnerText = CurrentPkmnStage2String.Trim();

                    MainXmlNode.AppendChild(NewStatNode);
                }

                if (CurrentPkmnStage3String != null)
                {
                    XmlNode NewStatNode = doc.CreateElement("Stage3");
                    NewStatNode.InnerText = CurrentPkmnStage3String.Trim();

                    MainXmlNode.AppendChild(NewStatNode);
                }

                // Sort Xml nodes...

                List<string> XmlNodesOrder = new List<string>(new string[] {
                    "Name",
                    "Type1",
                    "Type2",
                    "Description",
                    "Stats",
                    "PhysicalStats",
                    "AttackList",
                    "Ability",
                    "ConceptOrigin",
                    "BaseImage",
                    "ShinyImage",
                    "SizeComparisonImage",
                    "AlternateForms",
                    "Stage1",
                    "Stage2",
                    "Stage3",
                    "Stage1To2EvoMethod",
                    "Stage2To3EvoMethod",
                });

                foreach (string XmlNodeName in XmlNodesOrder)
                {
                    XmlNode node = doc.SelectSingleNode("/Pokemon/" + XmlNodeName);
                    if (node != null)
                    {
                        node.ParentNode.AppendChild(node);
                    }
                }

                if (!Directory.Exists(CurrentPkmnDir))
                {
                    Directory.CreateDirectory(CurrentPkmnDir);
                }

                // Save the XmlDocument back to disk
                doc.Save(CurrentPkmnXmlDir);

                // Delete old images (if there are any)
                FormRefresher.DoActualPokemonImagesDeletion(Globals.OldImagesToDelete);

                // Clear unsaved changes variable
                Globals.DEX_UNSAVED_CHANGES = false;
            }

            if (Globals.DEX_UNSAVED_CHANGES == false)
            {
                // Display info to the user
                Form Confirmation = new FAKEDEX_SAVEPOPUP();
                if (Confirmation.ShowDialog() == DialogResult.Yes)
                {
                    Confirmation.Close();
                    if (!Confirmation.IsDisposed)
                    {
                        Confirmation.Dispose();
                    }
                }
            }
        }

        public static void DoActualPokemonFolderDeletion(bool Force)
        {
            List<string>DeletedPokemonIDsToDispose = new List<string>();
            foreach (string Creature in Globals.PokemonToDelete)
            {
                if (!Force)
                {
                    bool Skip_this_creature = false;
                    foreach (DataRow Pokemon in Globals.POKEDEX_DATA.Rows)
                    {
                        if ((string)Pokemon["ID"] == Creature)
                        {
                            Skip_this_creature = true;
                            break;
                        }
                    }

                    if (Skip_this_creature)
                    {
                        continue;
                    }
                }

                string CreatureDir = Globals.MainPokedexDirectory + "\\" + Creature;

                if (Directory.Exists(CreatureDir))
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(CreatureDir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }

                DeletedPokemonIDsToDispose.Add(Creature);
            }

            foreach(string PkmnID in DeletedPokemonIDsToDispose)
            {
                if (Globals.PokemonToDelete.Contains(PkmnID))
                {
                    Globals.PokemonToDelete.Remove(PkmnID);
                }
            }
        }

        public static void DoActualPokemonImagesDeletion(List<string>ImageList)
        {
            if (ImageList != null && ImageList.Count > 0)
            {
                int NrLoops = ImageList.Count;
                for (var index = 0; index < NrLoops; index++)
                {
                    string CurrentImgDir = ImageList[index];
                    if (File.Exists(CurrentImgDir))
                    {
                        //MessageBox.Show("DexSaver: Deleting object: " + CurrentImgDir);
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(CurrentImgDir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                }
                Globals.OldImagesToDelete = null;
                Globals.OldImagesToDelete = new List<string>();

                Globals.NewImagesToDelete = null;
                Globals.NewImagesToDelete = new List<string>();
            }
        }

        public static void DexEditingDeleter()
        {
            Globals.PokemonToDelete.Add(Globals.CurrentPokemonID);

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    row.Delete();
                    Globals.POKEDEX_DATA.AcceptChanges();
                    break;
                }

            }

            foreach (string DexEntry in Globals.PokeSearch.Items)
            {
                if (DexEntry.Contains(Globals.CurrentPokemonID))
                {
                    Globals.PokeSearch.Items.Remove(DexEntry);
                    break;
                }
            }

            foreach (string DexEntry in Globals.PokeSearch.Items)
            {
                FormRefresher.Refresh(DexEntry.Split(" ")[0]);
                break;
            }

            Globals.DEX_UNSAVED_CHANGES = true;
        }
        public static void DexEditingAdder()
        {
            if (!String.IsNullOrEmpty(Globals.Request_NewPkmnDexID) && !String.IsNullOrEmpty(Globals.Request_NewPkmnName))
            {
                // Once again, to be 101% sure we don't crash, verify input

                bool NewDataHasOnlyLegalChars = true;
                foreach (string IllegalChar in Globals.IllegalChars)
                {
                    if (Globals.Request_NewPkmnDexID.Contains(IllegalChar))
                    {
                        NewDataHasOnlyLegalChars = false;
                        MessageBox.Show("Could not add new creature with ID \"" + Globals.Request_NewPkmnDexID + "\"!", "Error");
                    }
                    if (Globals.Request_NewPkmnName.Contains(IllegalChar))
                    {
                        NewDataHasOnlyLegalChars = false;
                        MessageBox.Show("Could not add new creature with Name \"" + Globals.Request_NewPkmnName + "\"!", "Error");
                    }
                }

                if (NewDataHasOnlyLegalChars) // Create new dex entry
                {
                    DataRow workRow = Globals.POKEDEX_DATA.NewRow();

                    workRow["ID"] = Globals.Request_NewPkmnDexID;
                    workRow["Name"] = Globals.Request_NewPkmnName;

                    workRow["Type1"] = "???";
                    workRow["Type2"] = "???";
                    workRow["Description"] = "This is a new creature.";
                    workRow["HP"] = "???";
                    workRow["ATK"] = "???";
                    workRow["DEF"] = "???";
                    workRow["SPATK"] = "???";
                    workRow["SPDEF"] = "???";
                    workRow["SPEED"] = "???";
                    workRow["Height"] = "???";
                    workRow["Weight"] = "???";
                    workRow["AbilityDescription"] = "ABILITY\nThis is a new creature's ability.";
                    workRow["ConceptOrigin"] = "This is a new creature's concept origin.";

                    workRow["Stage1To2EvoMethod"] = "This creature does not evolve.";

                    List<Dictionary<string, string>> NewAtkList = new List<Dictionary<string, string>>();

                    Dictionary<string, string> AtkDict = new Dictionary<string, string>();
                    AtkDict.Add("Level", "???");
                    AtkDict.Add("Type", "bug");
                    AtkDict.Add("MoveName", "New Move");
                    AtkDict.Add("Description", "Damage: ???\nA new pokemon's attack.");
                    NewAtkList.Add(AtkDict);
                    
                    workRow["AttackList"] = NewAtkList;

                    Globals.POKEDEX_DATA.Rows.Add(workRow);

                    FormRefresher.Refresh(Globals.Request_NewPkmnDexID);

                    // New Search entry
                    string NewSearchEntry = Globals.Request_NewPkmnDexID + " " + Globals.Request_NewPkmnName;
                    Globals.PokeSearch.Items.Add(NewSearchEntry);

                    Globals.Request_NewPkmnDexID = null;
                    Globals.Request_NewPkmnName = null;

                    Globals.DEX_UNSAVED_CHANGES = true;
                }
            }
            else
            {
                MessageBox.Show("New creature ID or Name is empty! Failed to add it to the Dex!", "Error");
            }
        }

        public static string ResolvePictureBoxType(PictureBox CurrentPictureBox)
        {
            string PictureBoxType = "AlternateForms";

            if (!String.IsNullOrEmpty(CurrentPictureBox.Tag.ToString()) && (CurrentPictureBox.Tag.ToString() == "BaseImage" || CurrentPictureBox.Tag.ToString() == "ShinyImage" || CurrentPictureBox.Tag.ToString() == "SizeComparisonImage"))
            {
                PictureBoxType = CurrentPictureBox.Tag.ToString().Trim();
            }

            return PictureBoxType;
        }

        public static void DexEditingBigImgImporter(PictureBox CurrentPictureBox)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.Personal.ToString();
                openFileDialog.Filter = "PNG files (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            if (!String.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                string File_Name = Path.GetFileName(filePath);
                File_Name = File_Name.Replace(" ", "_");
                string TargetDir = Globals.MainPokedexDirectory + "\\" + Globals.CurrentPokemonID + "\\" + File_Name;

                // Rename if we already have such image in current pokemon's directory
                if (File.Exists(TargetDir))
                {
                    Random _random = new Random();
                    string num = _random.Next(1000, 9000).ToString();
                    File_Name = File_Name.Split(".")[0] + num + "." + File_Name.Split(".")[1];
                    TargetDir = Globals.MainPokedexDirectory + "\\" + Globals.CurrentPokemonID + "\\" + File_Name;
                }

                if (!File.Exists(TargetDir))
                {
                    // Add to list of images to delete (if Dex is not saved and gets closed)
                    Globals.NewImagesToDelete.Add(TargetDir);

                    if (!Directory.Exists(Path.GetDirectoryName(TargetDir)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(TargetDir));
                    }

                    File.Copy(filePath, TargetDir, true);

                    // Resolve our current picturebox type
                    string CurrentPictureBoxType = FormRefresher.ResolvePictureBoxType(CurrentPictureBox);

                    foreach (DataRow PokeEntry in Globals.POKEDEX_DATA.Rows)
                    {
                        if ((string)PokeEntry["ID"] == Globals.CurrentPokemonID)
                        {
                            if (CurrentPictureBoxType != "AlternateForms")
                            {

                                List<Dictionary<string, string>> rowAlternateFormList = null;
                                List<string> OtherAltFormUsedImages = new List<string>();

                                if (!(PokeEntry.IsNull("AlternateForms")))
                                {
                                    rowAlternateFormList = (List<Dictionary<string, string>>)PokeEntry["AlternateForms"];
                                }

                                if (rowAlternateFormList != null && rowAlternateFormList.Count() > 0)
                                {
                                    // Get a list of used images by other forms - we don't want to delete images which are being used!
                                    foreach (Dictionary<string, string> AltFormDictionary in rowAlternateFormList)
                                    {
                                        OtherAltFormUsedImages.Add(AltFormDictionary["BaseImage"].ToString());
                                        OtherAltFormUsedImages.Add(AltFormDictionary["ShinyImage"].ToString());
                                    }
                                }

                                // Remove previous image file
                                if (!PokeEntry.IsNull(CurrentPictureBoxType) && !String.IsNullOrEmpty(PokeEntry[CurrentPictureBoxType].ToString()))
                                {
                                    string CurrentImgDir = Globals.MainPokedexDirectory + "\\" + Globals.CurrentPokemonID + "\\" + PokeEntry[CurrentPictureBoxType].ToString();
                                    if (File.Exists(CurrentImgDir) && !OtherAltFormUsedImages.Contains(PokeEntry[CurrentPictureBoxType].ToString()))
                                    {
                                        // Add to list of images to delete on save
                                        //MessageBox.Show("1: Img to delete: " + CurrentImgDir);
                                        Globals.OldImagesToDelete.Add(CurrentImgDir);
                                    }
                                }

                                PokeEntry.BeginEdit();
                                PokeEntry[CurrentPictureBoxType] = File_Name;
                                PokeEntry.EndEdit();
                            }
                            else
                            {
                                // Ok, so it's an alternate form. Is it a base or shiny image?
                                string AltFormImgType = "BaseImage";
                                string AltFormActualName = (CurrentPictureBox.Tag.ToString().Trim()).Replace("(S)", "");
                                if ((CurrentPictureBox.Tag.ToString().Trim()).Contains("(S)"))
                                {
                                    AltFormImgType = "ShinyImage";
                                }

                                List<Dictionary<string, string>> rowAlternateFormList = null;

                                if (!(PokeEntry.IsNull("AlternateForms")))
                                {
                                    rowAlternateFormList = (List<Dictionary<string, string>>)PokeEntry["AlternateForms"];
                                }

                                if (rowAlternateFormList != null && rowAlternateFormList.Count() > 0)
                                {
                                    string AltFormName = "";
                                    string AltFormBaseImage = "";
                                    string AltFormShinyImage = "";
                                    int AltFormIndex = 0;

                                    // Get a list of used images by other forms - we don't want to delete images which are being used!
                                    List<string> OtherAltFormUsedImages = new List<string>();
                                    foreach (Dictionary<string, string> AltFormDictionary in rowAlternateFormList)
                                    {
                                        if (AltFormDictionary["FormName"].ToString() != AltFormActualName)
                                        {
                                            OtherAltFormUsedImages.Add(AltFormDictionary["BaseImage"].ToString());
                                            OtherAltFormUsedImages.Add(AltFormDictionary["ShinyImage"].ToString());
                                        }
                                    }

                                    foreach (Dictionary<string, string> AltFormDictionary in rowAlternateFormList)
                                    {
                                        if (AltFormDictionary["FormName"].ToString() == AltFormActualName)
                                        {
                                            string CurrentImgDir = Globals.MainPokedexDirectory + "\\" + Globals.CurrentPokemonID + "\\" + AltFormDictionary[AltFormImgType].ToString();
                                            if (File.Exists(CurrentImgDir))
                                            {
                                                // Add to list of images to delete on save
                                                // NOTE: Delete it only if it's not being used by the base form or any of alternate forms!
                                                if (PokeEntry["BaseImage"].ToString() != AltFormDictionary[AltFormImgType] && PokeEntry["ShinyImage"].ToString() != AltFormDictionary[AltFormImgType] && !OtherAltFormUsedImages.Contains(AltFormDictionary[AltFormImgType]))
                                                {
                                                    //MessageBox.Show("2: Img to delete: " + CurrentImgDir);
                                                    Globals.OldImagesToDelete.Add(CurrentImgDir);
                                                }
                                            }

                                            AltFormName = AltFormDictionary["FormName"].ToString();
                                            AltFormBaseImage = AltFormDictionary["BaseImage"].ToString();
                                            AltFormShinyImage = AltFormDictionary["ShinyImage"].ToString();

                                            AltFormIndex = rowAlternateFormList.IndexOf(AltFormDictionary);
                                        }
                                    }

                                    Dictionary<string, string> NewAltFormDict = new Dictionary<string, string>();
                                    NewAltFormDict.Add("FormName", AltFormName);

                                    if (AltFormImgType == "BaseImage")
                                    {
                                        NewAltFormDict.Add("BaseImage", File_Name);
                                        NewAltFormDict.Add("ShinyImage", AltFormShinyImage);
                                    }
                                    else if (AltFormImgType == "ShinyImage")
                                    {
                                        NewAltFormDict.Add("BaseImage", AltFormBaseImage);
                                        NewAltFormDict.Add("ShinyImage", File_Name);
                                    }

                                    PokeEntry.BeginEdit();
                                    rowAlternateFormList[AltFormIndex] = NewAltFormDict;
                                    PokeEntry["AlternateForms"] = rowAlternateFormList;
                                    PokeEntry.EndEdit();
                                }
                            }
                        }
                    }

                    FormRefresher.Refresh(Globals.CurrentPokemonID);

                    Globals.DEX_UNSAVED_CHANGES = true;
                }
                else
                {
                    MessageBox.Show("Internal error: Rename your image file and try again.", "Import Error");
                }
            }
        }

        public static void DexEditingBaseStatsModifier()
        {
            Globals.ATKNUM.Text = Globals.Request_NewBaseATK;
            Globals.DEFNUM.Text = Globals.Request_NewBaseDEF;
            Globals.SPDNUM.Text = Globals.Request_NewBaseSPD;
            Globals.HPNUM.Text = Globals.Request_NewBaseHP;
            Globals.WEIGHTNUM.Text = Globals.Request_NewBaseWT;
            Globals.HEIGHTNUM.Text = Globals.Request_NewBaseHT;

            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if ((string)row["ID"] == Globals.CurrentPokemonID)
                {
                    row["ATK"] = Globals.ATKNUM.Text;
                    row["DEF"] = Globals.DEFNUM.Text;
                    row["SPEED"] = Globals.SPDNUM.Text;
                    row["HP"] = Globals.HPNUM.Text;
                    row["Height"] = Globals.HEIGHTNUM.Text;
                    row["Weight"] = Globals.WEIGHTNUM.Text;

                    break;
                }
            }

            Globals.Request_NewBaseATK = "";
            Globals.Request_NewBaseDEF = "";
            Globals.Request_NewBaseSPD = "";
            Globals.Request_NewBaseHP = "";
            Globals.Request_NewBaseWT = "";
            Globals.Request_NewBaseHT = "";

            Globals.DEX_UNSAVED_CHANGES = true;
        }
    }
}
