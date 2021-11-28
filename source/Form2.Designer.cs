
namespace Fakedex_2021
{
    partial class DeleteConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteConfirmation));
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_YES = new System.Windows.Forms.Button();
            this.BTN_NO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you sure you want to delete this Pokemon?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_YES
            // 
            this.BTN_YES.BackColor = System.Drawing.Color.Transparent;
            this.BTN_YES.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BTN_YES.FlatAppearance.BorderSize = 0;
            this.BTN_YES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_YES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_YES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_YES.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_YES.Image = global::Fakedex_2021.Properties.Resources.question_window_YES;
            this.BTN_YES.Location = new System.Drawing.Point(97, 64);
            this.BTN_YES.Name = "BTN_YES";
            this.BTN_YES.Size = new System.Drawing.Size(79, 44);
            this.BTN_YES.TabIndex = 2;
            this.BTN_YES.TabStop = false;
            this.BTN_YES.UseVisualStyleBackColor = false;
            this.BTN_YES.Click += new System.EventHandler(this.BTN_YES_Click);
            this.BTN_YES.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_YES_MouseDown);
            this.BTN_YES.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_YES_MouseUp);
            // 
            // BTN_NO
            // 
            this.BTN_NO.BackColor = System.Drawing.Color.Transparent;
            this.BTN_NO.DialogResult = System.Windows.Forms.DialogResult.No;
            this.BTN_NO.FlatAppearance.BorderSize = 0;
            this.BTN_NO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BTN_NO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BTN_NO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_NO.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_NO.Image = global::Fakedex_2021.Properties.Resources.question_window_NO;
            this.BTN_NO.Location = new System.Drawing.Point(224, 64);
            this.BTN_NO.Name = "BTN_NO";
            this.BTN_NO.Size = new System.Drawing.Size(78, 44);
            this.BTN_NO.TabIndex = 3;
            this.BTN_NO.TabStop = false;
            this.BTN_NO.UseVisualStyleBackColor = false;
            this.BTN_NO.Click += new System.EventHandler(this.BTN_NO_Click);
            this.BTN_NO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BTN_NO_MouseDown);
            this.BTN_NO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BTN_NO_MouseUp);
            // 
            // DeleteConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(157)))));
            this.BackgroundImage = global::Fakedex_2021.Properties.Resources.question_window_color;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(390, 119);
            this.ControlBox = false;
            this.Controls.Add(this.BTN_NO);
            this.Controls.Add(this.BTN_YES);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeleteConfirmation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button BTN_YES;
        public System.Windows.Forms.Button BTN_NO;
    }
}