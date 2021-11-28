
namespace Fakedex_2021
{
    partial class AddPkmnPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPkmnPanel));
            this.NewPkmnOK = new System.Windows.Forms.Button();
            this.NewPkmnCANCEL = new System.Windows.Forms.Button();
            this.NewPkmnLabel1 = new System.Windows.Forms.Label();
            this.NewPkmnDexIDBox = new System.Windows.Forms.TextBox();
            this.NewPkmnNameBox = new System.Windows.Forms.TextBox();
            this.NewPkmnLabel2 = new System.Windows.Forms.Label();
            this.NewPkmnWarning1 = new System.Windows.Forms.Label();
            this.NewPkmnWarning2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewPkmnOK
            // 
            this.NewPkmnOK.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.NewPkmnOK.FlatAppearance.BorderSize = 0;
            this.NewPkmnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NewPkmnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NewPkmnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPkmnOK.ForeColor = System.Drawing.Color.Transparent;
            this.NewPkmnOK.Image = global::Fakedex_2021.Properties.Resources.question_window_OK;
            this.NewPkmnOK.Location = new System.Drawing.Point(106, 237);
            this.NewPkmnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPkmnOK.Name = "NewPkmnOK";
            this.NewPkmnOK.Size = new System.Drawing.Size(86, 40);
            this.NewPkmnOK.TabIndex = 0;
            this.NewPkmnOK.TabStop = false;
            this.NewPkmnOK.UseVisualStyleBackColor = false;
            this.NewPkmnOK.Click += new System.EventHandler(this.NewPkmnOK_Click);
            this.NewPkmnOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewPkmnOK_MouseDown);
            this.NewPkmnOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewPkmnOK_MouseUp);
            // 
            // NewPkmnCANCEL
            // 
            this.NewPkmnCANCEL.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnCANCEL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NewPkmnCANCEL.FlatAppearance.BorderSize = 0;
            this.NewPkmnCANCEL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.NewPkmnCANCEL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.NewPkmnCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPkmnCANCEL.ForeColor = System.Drawing.Color.Transparent;
            this.NewPkmnCANCEL.Image = global::Fakedex_2021.Properties.Resources.question_window_CANCEL;
            this.NewPkmnCANCEL.Location = new System.Drawing.Point(249, 237);
            this.NewPkmnCANCEL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPkmnCANCEL.Name = "NewPkmnCANCEL";
            this.NewPkmnCANCEL.Size = new System.Drawing.Size(86, 40);
            this.NewPkmnCANCEL.TabIndex = 1;
            this.NewPkmnCANCEL.TabStop = false;
            this.NewPkmnCANCEL.UseVisualStyleBackColor = false;
            this.NewPkmnCANCEL.Click += new System.EventHandler(this.NewPkmnCANCEL_Click);
            this.NewPkmnCANCEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewPkmnCANCEL_MouseDown);
            this.NewPkmnCANCEL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewPkmnCANCEL_MouseUp);
            // 
            // NewPkmnLabel1
            // 
            this.NewPkmnLabel1.AutoSize = true;
            this.NewPkmnLabel1.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPkmnLabel1.ForeColor = System.Drawing.Color.White;
            this.NewPkmnLabel1.Location = new System.Drawing.Point(49, 129);
            this.NewPkmnLabel1.Name = "NewPkmnLabel1";
            this.NewPkmnLabel1.Size = new System.Drawing.Size(164, 23);
            this.NewPkmnLabel1.TabIndex = 2;
            this.NewPkmnLabel1.Text = "New creature name:";
            // 
            // NewPkmnDexIDBox
            // 
            this.NewPkmnDexIDBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPkmnDexIDBox.Location = new System.Drawing.Point(49, 61);
            this.NewPkmnDexIDBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPkmnDexIDBox.MaxLength = 4;
            this.NewPkmnDexIDBox.Name = "NewPkmnDexIDBox";
            this.NewPkmnDexIDBox.PlaceholderText = "001, 002, etc.";
            this.NewPkmnDexIDBox.Size = new System.Drawing.Size(337, 32);
            this.NewPkmnDexIDBox.TabIndex = 99;
            this.NewPkmnDexIDBox.Tag = "Dex ID";
            this.NewPkmnDexIDBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewPkmnDexIDBox_KeyDown);
            this.NewPkmnDexIDBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewPkmnDexIDBox_KeyUp);
            // 
            // NewPkmnNameBox
            // 
            this.NewPkmnNameBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPkmnNameBox.Location = new System.Drawing.Point(49, 156);
            this.NewPkmnNameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewPkmnNameBox.MaxLength = 20;
            this.NewPkmnNameBox.Name = "NewPkmnNameBox";
            this.NewPkmnNameBox.PlaceholderText = "NewCreature";
            this.NewPkmnNameBox.Size = new System.Drawing.Size(337, 32);
            this.NewPkmnNameBox.TabIndex = 100;
            this.NewPkmnNameBox.Tag = "Name";
            this.NewPkmnNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewPkmnNameBox_KeyDown);
            this.NewPkmnNameBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewPkmnNameBox_KeyUp);
            // 
            // NewPkmnLabel2
            // 
            this.NewPkmnLabel2.AutoSize = true;
            this.NewPkmnLabel2.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPkmnLabel2.ForeColor = System.Drawing.Color.White;
            this.NewPkmnLabel2.Location = new System.Drawing.Point(49, 33);
            this.NewPkmnLabel2.Name = "NewPkmnLabel2";
            this.NewPkmnLabel2.Size = new System.Drawing.Size(172, 23);
            this.NewPkmnLabel2.TabIndex = 5;
            this.NewPkmnLabel2.Text = "New creature Dex ID:";
            // 
            // NewPkmnWarning1
            // 
            this.NewPkmnWarning1.AutoSize = true;
            this.NewPkmnWarning1.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnWarning1.ForeColor = System.Drawing.Color.Red;
            this.NewPkmnWarning1.Location = new System.Drawing.Point(51, 100);
            this.NewPkmnWarning1.Name = "NewPkmnWarning1";
            this.NewPkmnWarning1.Size = new System.Drawing.Size(281, 20);
            this.NewPkmnWarning1.TabIndex = 6;
            this.NewPkmnWarning1.Text = "A creature with this Dex ID already exists.";
            // 
            // NewPkmnWarning2
            // 
            this.NewPkmnWarning2.AutoSize = true;
            this.NewPkmnWarning2.BackColor = System.Drawing.Color.Transparent;
            this.NewPkmnWarning2.ForeColor = System.Drawing.Color.Red;
            this.NewPkmnWarning2.Location = new System.Drawing.Point(53, 195);
            this.NewPkmnWarning2.Name = "NewPkmnWarning2";
            this.NewPkmnWarning2.Size = new System.Drawing.Size(273, 20);
            this.NewPkmnWarning2.TabIndex = 7;
            this.NewPkmnWarning2.Text = "A creature with this name already exists.";
            // 
            // AddPkmnPanel
            // 
            this.AcceptButton = this.NewPkmnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.BackgroundImage = global::Fakedex_2021.Properties.Resources.question_window_color_create;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.NewPkmnCANCEL;
            this.ClientSize = new System.Drawing.Size(435, 293);
            this.ControlBox = false;
            this.Controls.Add(this.NewPkmnWarning2);
            this.Controls.Add(this.NewPkmnWarning1);
            this.Controls.Add(this.NewPkmnLabel2);
            this.Controls.Add(this.NewPkmnNameBox);
            this.Controls.Add(this.NewPkmnDexIDBox);
            this.Controls.Add(this.NewPkmnLabel1);
            this.Controls.Add(this.NewPkmnCANCEL);
            this.Controls.Add(this.NewPkmnOK);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPkmnPanel";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddPkmnPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewPkmnOK;
        private System.Windows.Forms.Button NewPkmnCANCEL;
        private System.Windows.Forms.Label NewPkmnLabel1;
        private System.Windows.Forms.TextBox NewPkmnDexIDBox;
        private System.Windows.Forms.TextBox NewPkmnNameBox;
        private System.Windows.Forms.Label NewPkmnLabel2;
        private System.Windows.Forms.Label NewPkmnWarning1;
        private System.Windows.Forms.Label NewPkmnWarning2;
    }
}