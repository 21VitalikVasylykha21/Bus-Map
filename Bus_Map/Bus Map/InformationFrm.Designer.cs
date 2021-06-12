namespace Bus_Map
{
    partial class InformationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationFrm));
            this.lblInfoProgram = new System.Windows.Forms.Label();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabPageInfoProgram = new System.Windows.Forms.TabPage();
            this.tabPageInfoInstruction = new System.Windows.Forms.TabPage();
            this.txtBoxInfoInstruction = new System.Windows.Forms.TextBox();
            this.tabPageInfoAuthor = new System.Windows.Forms.TabPage();
            this.lblInfoAuthor = new System.Windows.Forms.Label();
            this.Fon = new System.Windows.Forms.PictureBox();
            this.tabControlInfo.SuspendLayout();
            this.tabPageInfoProgram.SuspendLayout();
            this.tabPageInfoInstruction.SuspendLayout();
            this.tabPageInfoAuthor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfoProgram
            // 
            this.lblInfoProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoProgram.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoProgram.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoProgram.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInfoProgram.Location = new System.Drawing.Point(30, 30);
            this.lblInfoProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoProgram.Name = "lblInfoProgram";
            this.lblInfoProgram.Size = new System.Drawing.Size(882, 234);
            this.lblInfoProgram.TabIndex = 3;
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlInfo.Controls.Add(this.tabPageInfoProgram);
            this.tabControlInfo.Controls.Add(this.tabPageInfoInstruction);
            this.tabControlInfo.Controls.Add(this.tabPageInfoAuthor);
            this.tabControlInfo.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlInfo.Location = new System.Drawing.Point(139, 269);
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(947, 312);
            this.tabControlInfo.TabIndex = 4;
            // 
            // tabPageInfoProgram
            // 
            this.tabPageInfoProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tabPageInfoProgram.Controls.Add(this.lblInfoProgram);
            this.tabPageInfoProgram.Location = new System.Drawing.Point(4, 44);
            this.tabPageInfoProgram.Name = "tabPageInfoProgram";
            this.tabPageInfoProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfoProgram.Size = new System.Drawing.Size(939, 264);
            this.tabPageInfoProgram.TabIndex = 0;
            this.tabPageInfoProgram.Text = "Про додаток";
            // 
            // tabPageInfoInstruction
            // 
            this.tabPageInfoInstruction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tabPageInfoInstruction.Controls.Add(this.txtBoxInfoInstruction);
            this.tabPageInfoInstruction.Location = new System.Drawing.Point(4, 44);
            this.tabPageInfoInstruction.Name = "tabPageInfoInstruction";
            this.tabPageInfoInstruction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfoInstruction.Size = new System.Drawing.Size(939, 264);
            this.tabPageInfoInstruction.TabIndex = 1;
            this.tabPageInfoInstruction.Text = "Інструкція по використанню";
            // 
            // txtBoxInfoInstruction
            // 
            this.txtBoxInfoInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxInfoInstruction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.txtBoxInfoInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxInfoInstruction.Font = new System.Drawing.Font("Segoe Print", 13.8F);
            this.txtBoxInfoInstruction.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtBoxInfoInstruction.Location = new System.Drawing.Point(6, 6);
            this.txtBoxInfoInstruction.Multiline = true;
            this.txtBoxInfoInstruction.Name = "txtBoxInfoInstruction";
            this.txtBoxInfoInstruction.ReadOnly = true;
            this.txtBoxInfoInstruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxInfoInstruction.Size = new System.Drawing.Size(930, 252);
            this.txtBoxInfoInstruction.TabIndex = 5;
            // 
            // tabPageInfoAuthor
            // 
            this.tabPageInfoAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tabPageInfoAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageInfoAuthor.Controls.Add(this.lblInfoAuthor);
            this.tabPageInfoAuthor.Location = new System.Drawing.Point(4, 44);
            this.tabPageInfoAuthor.Name = "tabPageInfoAuthor";
            this.tabPageInfoAuthor.Size = new System.Drawing.Size(939, 264);
            this.tabPageInfoAuthor.TabIndex = 2;
            this.tabPageInfoAuthor.Text = "Про автора";
            // 
            // lblInfoAuthor
            // 
            this.lblInfoAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoAuthor.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoAuthor.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoAuthor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInfoAuthor.Location = new System.Drawing.Point(30, 30);
            this.lblInfoAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoAuthor.Name = "lblInfoAuthor";
            this.lblInfoAuthor.Size = new System.Drawing.Size(997, 355);
            this.lblInfoAuthor.TabIndex = 4;
            // 
            // Fon
            // 
            this.Fon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Fon.BackgroundImage")));
            this.Fon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fon.Location = new System.Drawing.Point(0, 0);
            this.Fon.Name = "Fon";
            this.Fon.Size = new System.Drawing.Size(1168, 590);
            this.Fon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fon.TabIndex = 5;
            this.Fon.TabStop = false;
            // 
            // InformationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 602);
            this.Controls.Add(this.tabControlInfo);
            this.Controls.Add(this.Fon);
            this.KeyPreview = true;
            this.Name = "InformationFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformationFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InformationFrm_FormClosing);
            this.Load += new System.EventHandler(this.InformationFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InformationFrm_KeyDown);
            this.tabControlInfo.ResumeLayout(false);
            this.tabPageInfoProgram.ResumeLayout(false);
            this.tabPageInfoInstruction.ResumeLayout(false);
            this.tabPageInfoInstruction.PerformLayout();
            this.tabPageInfoAuthor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Fon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblInfoProgram;
        private System.Windows.Forms.TabControl tabControlInfo;
        private System.Windows.Forms.TabPage tabPageInfoProgram;
        private System.Windows.Forms.TabPage tabPageInfoInstruction;
        private System.Windows.Forms.TabPage tabPageInfoAuthor;
        private System.Windows.Forms.Label lblInfoAuthor;
        private System.Windows.Forms.TextBox txtBoxInfoInstruction;
        private System.Windows.Forms.PictureBox Fon;
    }
}