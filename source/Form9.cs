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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();

            GridCancelButton.FlatStyle = FlatStyle.Flat;
            GridCancelButton.FlatAppearance.BorderSize = 0;

            // No weird white border on buttons when form is out of focus...
            GridCancelButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            int NEW_ROW_STYLE_HEIGHT = 170;

            // Build a grid view window using creature data
            foreach (DataRow row in Globals.POKEDEX_DATA.Rows)
            {
                if (row["ID"].ToString() != null && Int32.Parse(row["ID"].ToString()) < 9990)
                {
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
                            
                            dynamic GridViewTable = GetNextControl(flowLayoutPanel1, true);

                            if (GridViewTable != null && GridViewTable.GetType().Name == "TableLayoutPanel")
                            {
                                TableLayoutPanel GrdVwTbl = GridViewTable;

                                string PokeColumn_str = row["ID"].ToString();
                                int PokeColumn = Int32.Parse(PokeColumn_str) - 1;

                                int ActualPokeColumn = PokeColumn % 3;

                                int PokeRow = 0;
                                for (var i = PokeColumn; i > 0; i--)
                                {
                                    if (i % 3 == 0)
                                    {
                                        PokeRow = i / 3;
                                        break;
                                    }
                                }

                                dynamic dynPokeImageBox = GrdVwTbl.GetControlFromPosition(ActualPokeColumn, PokeRow);
                                //MessageBox.Show("Putting creature ID:" + row["ID"].ToString() + ", Name: " + row["Name"].ToString() + "; to column:" + ActualPokeColumn + " row:" + PokeRow + "...", "BuildInfo");

                                // Set our variable at first chance - at (0,0) cell
                                if (ActualPokeColumn == 0 && PokeRow == 0)
                                {
                                    NEW_ROW_STYLE_HEIGHT = GrdVwTbl.Height / GrdVwTbl.RowCount;
                                }

                                if (dynPokeImageBox == null)
                                {
                                    //MessageBox.Show("Control at pos. " + ActualPokeColumn + ":" + PokeRow + " is NOT a PictureBox! This is: NULL", "Unexpected Control Type Error");
                                    
                                    GrdVwTbl.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                                    GrdVwTbl.AutoSize = true;

                                    var oldRowCount = GrdVwTbl.RowCount;

                                    // Add new empty rows
                                    for (var u = oldRowCount; u <= PokeRow; u++)
                                    {
                                        GrdVwTbl.RowCount += 1;

                                        RowStyle newRowStyle = new RowStyle();
                                        newRowStyle.SizeType = SizeType.Absolute;
                                        newRowStyle.Height = NEW_ROW_STYLE_HEIGHT;

                                        GrdVwTbl.RowStyles.Insert(u, newRowStyle);
                                        GrdVwTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, NEW_ROW_STYLE_HEIGHT));

                                        GrdVwTbl.Controls.Add(new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, Width = 200, Height = 154, Dock = DockStyle.Fill, Visible = true }, 0, u);
                                        GrdVwTbl.Controls.Add(new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, Width = 200, Height = 154, Dock = DockStyle.Fill, Visible = true }, 1, u);
                                        GrdVwTbl.Controls.Add(new PictureBox() { SizeMode = PictureBoxSizeMode.StretchImage, Width = 200, Height = 154, Dock = DockStyle.Fill, Visible = true }, 2, u);
                                    }

                                    dynPokeImageBox = GrdVwTbl.GetControlFromPosition(ActualPokeColumn, PokeRow);
                                }

                                if (dynPokeImageBox != null && dynPokeImageBox.GetType().Name == "PictureBox")
                                {
                                    PictureBox PokePictureBox = dynPokeImageBox;
                                    PokePictureBox.Image = MainImage;
                                    PokePictureBox.Cursor = Cursors.Hand;
                                    GridToolTip.SetToolTip(PokePictureBox, "#" + row["ID"].ToString() + " " + row["Name"].ToString());

                                    void PicBox_Click(object sender, EventArgs e)
                                    {
                                        FormRefresher.Refresh(row["ID"].ToString());
                                        this.Close();
                                    }

                                    PokePictureBox.MouseClick += new MouseEventHandler(PicBox_Click);

                                    /* Scale PictureBox to match creature's image size ratio
                                    var OriginalRatio = MainImage.Width / MainImage.Height;
                                    if (OriginalRatio > 1)
                                    {
                                        // The width of original image is bigger than its height, change Picturebox ratio by cutting height
                                        Size _newsize = new Size();
                                        _newsize.Height = PokePictureBox.Height * OriginalRatio;
                                        _newsize.Width = PokePictureBox.Width;
                                        PokePictureBox.Size = _newsize;
                                        PokePictureBox.ClientSize = _newsize;
                                    }
                                    else if (OriginalRatio < 1)
                                    {
                                        // The height of original image is bigger than its width, change Picturebox ratio by cutting width
                                        Size _newsize = new Size();
                                        _newsize.Height = PokePictureBox.Height;
                                        _newsize.Width = PokePictureBox.Width * OriginalRatio;
                                        PokePictureBox.Size = _newsize;
                                        PokePictureBox.ClientSize = _newsize;
                                    }
                                    */
                                }
                                else
                                {
                                    MessageBox.Show("Control at column:" + ActualPokeColumn + ", row:" + PokeRow + " is NOT a PictureBox! This is: NULL", "Unexpected Control Type Error");
                                }
                            }
                            else
                            {
                                if (GridViewTable == null)
                                {
                                    MessageBox.Show("Loaded control is NOT a TableLayoutPanel! This is: NULL", "Unexpected Control Type Error");
                                }
                                else
                                {
                                    MessageBox.Show("Loaded control is NOT a TableLayoutPanel! This is: " + GridViewTable.GetType().Name, "Unexpected Control Type Error");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not load main Pokemon image from declared path: '" + MainImagePath + "'!", "Image Load Error");

                            Bitmap bmp1 = new Bitmap(Properties.Resources.unknownpoke_image);
                            Globals.pictureBox1.Image = bmp1;
                        }
                    }
                }
            }
        }

        private void GridCancelButton_Click(object sender, EventArgs e)
        {

        }

        private void GridCancelButton_MouseDown(object sender, EventArgs e)
        {
            Bitmap bm93 = new Bitmap(Properties.Resources.question_window_CANCEL_press);
            GridCancelButton.Image = bm93;
        }

        private void GridCancelButton_MouseUp(object sender, EventArgs e)
        {
            Bitmap bm93 = new Bitmap(Properties.Resources.question_window_CANCEL);
            GridCancelButton.Image = bm93;
        }
    }
}
