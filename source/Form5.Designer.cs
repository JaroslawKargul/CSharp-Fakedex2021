
namespace Fakedex_2021
{
    partial class EditAttackListPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ATTACKLIST = new System.Windows.Forms.FlowLayoutPanel();
            this.AtkListEditOK = new System.Windows.Forms.Button();
            this.BTN_ADDATTACK = new System.Windows.Forms.Button();
            this.ATTACKTEMPLATES = new System.Windows.Forms.FlowLayoutPanel();
            this.NORESULTS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_REMOVEATTACK = new System.Windows.Forms.Button();
            this.TXT_ATTACKNAME = new System.Windows.Forms.TextBox();
            this.TXT_ATTACKDESCR = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BTN_SAVECHANGES = new System.Windows.Forms.Button();
            this.ERRORLABEL = new System.Windows.Forms.Label();
            this.TXT_ATTACKTYPE = new System.Windows.Forms.TextBox();
            this.TXT_ATTACKLEVEL = new System.Windows.Forms.TextBox();
            this.ATKSEARCHBAR = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ATTACKLIST
            // 
            this.ATTACKLIST.AutoScroll = true;
            this.ATTACKLIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.ATTACKLIST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ATTACKLIST.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ATTACKLIST.Location = new System.Drawing.Point(33, 89);
            this.ATTACKLIST.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ATTACKLIST.Name = "ATTACKLIST";
            this.ATTACKLIST.Size = new System.Drawing.Size(215, 323);
            this.ATTACKLIST.TabIndex = 0;
            this.ATTACKLIST.WrapContents = false;
            // 
            // AtkListEditOK
            // 
            this.AtkListEditOK.BackColor = System.Drawing.Color.Transparent;
            this.AtkListEditOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AtkListEditOK.FlatAppearance.BorderSize = 0;
            this.AtkListEditOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AtkListEditOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AtkListEditOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AtkListEditOK.Image = global::Fakedex_2021.Properties.Resources.BUTTONSEDIT_closewindow;
            this.AtkListEditOK.Location = new System.Drawing.Point(682, 1);
            this.AtkListEditOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AtkListEditOK.Name = "AtkListEditOK";
            this.AtkListEditOK.Size = new System.Drawing.Size(67, 71);
            this.AtkListEditOK.TabIndex = 1;
            this.AtkListEditOK.UseVisualStyleBackColor = false;
            this.AtkListEditOK.Click += new System.EventHandler(this.AtkListEditOK_Click);
            // 
            // BTN_ADDATTACK
            // 
            this.BTN_ADDATTACK.BackColor = System.Drawing.Color.Transparent;
            this.BTN_ADDATTACK.FlatAppearance.BorderSize = 0;
            this.BTN_ADDATTACK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_ADDATTACK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_ADDATTACK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ADDATTACK.Image = global::Fakedex_2021.Properties.Resources.button_add1;
            this.BTN_ADDATTACK.Location = new System.Drawing.Point(298, 28);
            this.BTN_ADDATTACK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_ADDATTACK.Name = "BTN_ADDATTACK";
            this.BTN_ADDATTACK.Size = new System.Drawing.Size(47, 45);
            this.BTN_ADDATTACK.TabIndex = 4;
            this.toolTip1.SetToolTip(this.BTN_ADDATTACK, "Add a new attack to Attack List.");
            this.BTN_ADDATTACK.UseVisualStyleBackColor = false;
            this.BTN_ADDATTACK.Click += new System.EventHandler(this.BTN_ADDATTACK_Click);
            this.BTN_ADDATTACK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_ADDATTACK_MouseDown);
            this.BTN_ADDATTACK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_ADDATTACK_MouseUp);
            // 
            // ATTACKTEMPLATES
            // 
            this.ATTACKTEMPLATES.AutoScroll = true;
            this.ATTACKTEMPLATES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.ATTACKTEMPLATES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ATTACKTEMPLATES.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ATTACKTEMPLATES.Location = new System.Drawing.Point(502, 139);
            this.ATTACKTEMPLATES.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ATTACKTEMPLATES.Name = "ATTACKTEMPLATES";
            this.ATTACKTEMPLATES.Size = new System.Drawing.Size(213, 274);
            this.ATTACKTEMPLATES.TabIndex = 1;
            this.ATTACKTEMPLATES.WrapContents = false;
            // 
            // NORESULTS
            // 
            this.NORESULTS.AutoSize = true;
            this.NORESULTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.NORESULTS.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NORESULTS.ForeColor = System.Drawing.Color.White;
            this.NORESULTS.Location = new System.Drawing.Point(527, 148);
            this.NORESULTS.Name = "NORESULTS";
            this.NORESULTS.Size = new System.Drawing.Size(185, 25);
            this.NORESULTS.TabIndex = 7;
            this.NORESULTS.Text = "No matching results.";
            this.NORESULTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Attack List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(499, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Existing Attacks (Templates)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_REMOVEATTACK
            // 
            this.BTN_REMOVEATTACK.BackColor = System.Drawing.Color.Transparent;
            this.BTN_REMOVEATTACK.FlatAppearance.BorderSize = 0;
            this.BTN_REMOVEATTACK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_REMOVEATTACK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_REMOVEATTACK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_REMOVEATTACK.Image = global::Fakedex_2021.Properties.Resources.button_del;
            this.BTN_REMOVEATTACK.Location = new System.Drawing.Point(410, 28);
            this.BTN_REMOVEATTACK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_REMOVEATTACK.Name = "BTN_REMOVEATTACK";
            this.BTN_REMOVEATTACK.Size = new System.Drawing.Size(47, 45);
            this.BTN_REMOVEATTACK.TabIndex = 7;
            this.toolTip1.SetToolTip(this.BTN_REMOVEATTACK, "Remove selected attack from Attack List.");
            this.BTN_REMOVEATTACK.UseVisualStyleBackColor = false;
            this.BTN_REMOVEATTACK.Click += new System.EventHandler(this.BTN_REMOVEATTACK_Click);
            this.BTN_REMOVEATTACK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_REMOVEATTACK_MouseDown);
            this.BTN_REMOVEATTACK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_REMOVEATTACK_MouseUp);
            // 
            // TXT_ATTACKNAME
            // 
            this.TXT_ATTACKNAME.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_ATTACKNAME.Location = new System.Drawing.Point(279, 89);
            this.TXT_ATTACKNAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_ATTACKNAME.Name = "TXT_ATTACKNAME";
            this.TXT_ATTACKNAME.PlaceholderText = "Attack Name";
            this.TXT_ATTACKNAME.Size = new System.Drawing.Size(194, 32);
            this.TXT_ATTACKNAME.TabIndex = 8;
            // 
            // TXT_ATTACKDESCR
            // 
            this.TXT_ATTACKDESCR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_ATTACKDESCR.Location = new System.Drawing.Point(279, 181);
            this.TXT_ATTACKDESCR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_ATTACKDESCR.Multiline = true;
            this.TXT_ATTACKDESCR.Name = "TXT_ATTACKDESCR";
            this.TXT_ATTACKDESCR.PlaceholderText = "Attack Description...";
            this.TXT_ATTACKDESCR.Size = new System.Drawing.Size(194, 231);
            this.TXT_ATTACKDESCR.TabIndex = 9;
            // 
            // BTN_SAVECHANGES
            // 
            this.BTN_SAVECHANGES.BackColor = System.Drawing.Color.Transparent;
            this.BTN_SAVECHANGES.FlatAppearance.BorderSize = 0;
            this.BTN_SAVECHANGES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_SAVECHANGES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_SAVECHANGES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SAVECHANGES.Image = global::Fakedex_2021.Properties.Resources.button_sav;
            this.BTN_SAVECHANGES.Location = new System.Drawing.Point(354, 28);
            this.BTN_SAVECHANGES.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_SAVECHANGES.Name = "BTN_SAVECHANGES";
            this.BTN_SAVECHANGES.Size = new System.Drawing.Size(47, 45);
            this.BTN_SAVECHANGES.TabIndex = 14;
            this.toolTip1.SetToolTip(this.BTN_SAVECHANGES, "Save changes to selected attack.");
            this.BTN_SAVECHANGES.UseVisualStyleBackColor = false;
            this.BTN_SAVECHANGES.Click += new System.EventHandler(this.BTN_SAVECHANGES_Click);
            this.BTN_SAVECHANGES.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_SAVECHANGES_MouseDown);
            this.BTN_SAVECHANGES.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_SAVECHANGES_MouseUp);
            // 
            // ERRORLABEL
            // 
            this.ERRORLABEL.AutoSize = true;
            this.ERRORLABEL.BackColor = System.Drawing.Color.Transparent;
            this.ERRORLABEL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ERRORLABEL.ForeColor = System.Drawing.Color.Red;
            this.ERRORLABEL.Location = new System.Drawing.Point(199, 423);
            this.ERRORLABEL.Name = "ERRORLABEL";
            this.ERRORLABEL.Size = new System.Drawing.Size(400, 25);
            this.ERRORLABEL.TabIndex = 10;
            this.ERRORLABEL.Text = "Attack name must be at least 1 character long!";
            this.ERRORLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXT_ATTACKTYPE
            // 
            this.TXT_ATTACKTYPE.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_ATTACKTYPE.Location = new System.Drawing.Point(385, 135);
            this.TXT_ATTACKTYPE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_ATTACKTYPE.Name = "TXT_ATTACKTYPE";
            this.TXT_ATTACKTYPE.PlaceholderText = "Type";
            this.TXT_ATTACKTYPE.Size = new System.Drawing.Size(87, 32);
            this.TXT_ATTACKTYPE.TabIndex = 12;
            // 
            // TXT_ATTACKLEVEL
            // 
            this.TXT_ATTACKLEVEL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TXT_ATTACKLEVEL.Location = new System.Drawing.Point(279, 135);
            this.TXT_ATTACKLEVEL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_ATTACKLEVEL.Name = "TXT_ATTACKLEVEL";
            this.TXT_ATTACKLEVEL.PlaceholderText = "Level";
            this.TXT_ATTACKLEVEL.Size = new System.Drawing.Size(87, 32);
            this.TXT_ATTACKLEVEL.TabIndex = 13;
            // 
            // ATKSEARCHBAR
            // 
            this.ATKSEARCHBAR.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ATKSEARCHBAR.Location = new System.Drawing.Point(502, 89);
            this.ATKSEARCHBAR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ATKSEARCHBAR.Name = "ATKSEARCHBAR";
            this.ATKSEARCHBAR.PlaceholderText = "Search...";
            this.ATKSEARCHBAR.Size = new System.Drawing.Size(213, 32);
            this.ATKSEARCHBAR.TabIndex = 15;
            this.ATKSEARCHBAR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ATKSEARCHBAR_KeyUp);
            // 
            // EditAttackListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.BackgroundImage = global::Fakedex_2021.Properties.Resources.WINDOW_ATKEDIT;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 471);
            this.Controls.Add(this.NORESULTS);
            this.Controls.Add(this.ATKSEARCHBAR);
            this.Controls.Add(this.BTN_SAVECHANGES);
            this.Controls.Add(this.TXT_ATTACKLEVEL);
            this.Controls.Add(this.TXT_ATTACKTYPE);
            this.Controls.Add(this.ERRORLABEL);
            this.Controls.Add(this.TXT_ATTACKDESCR);
            this.Controls.Add(this.TXT_ATTACKNAME);
            this.Controls.Add(this.BTN_REMOVEATTACK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ATTACKTEMPLATES);
            this.Controls.Add(this.BTN_ADDATTACK);
            this.Controls.Add(this.AtkListEditOK);
            this.Controls.Add(this.ATTACKLIST);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditAttackListPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ATTACKLIST;
        private System.Windows.Forms.Button AtkListEditOK;
        private System.Windows.Forms.Button BTN_ADDATTACK;
        private System.Windows.Forms.FlowLayoutPanel ATTACKTEMPLATES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_REMOVEATTACK;
        private System.Windows.Forms.TextBox TXT_ATTACKNAME;
        private System.Windows.Forms.TextBox TXT_ATTACKDESCR;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label ERRORLABEL;
        private System.Windows.Forms.TextBox TXT_ATTACKTYPE;
        private System.Windows.Forms.TextBox TXT_ATTACKLEVEL;
        private System.Windows.Forms.Button BTN_SAVECHANGES;
        private System.Windows.Forms.TextBox ATKSEARCHBAR;
        private System.Windows.Forms.Label NORESULTS;
    }
}