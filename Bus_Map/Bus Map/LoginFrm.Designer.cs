namespace Bus_Map
{
    partial class LoginFrm
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
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.txtBoxLog = new System.Windows.Forms.TextBox();
            this.checkBoxSaveUser = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxPass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBoxPass.Location = new System.Drawing.Point(294, 310);
            this.txtBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPass.MaxLength = 32;
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.PasswordChar = '*';
            this.txtBoxPass.Size = new System.Drawing.Size(285, 34);
            this.txtBoxPass.TabIndex = 27;
            // 
            // txtBoxLog
            // 
            this.txtBoxLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxLog.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxLog.Location = new System.Drawing.Point(294, 230);
            this.txtBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxLog.MaxLength = 32;
            this.txtBoxLog.Name = "txtBoxLog";
            this.txtBoxLog.Size = new System.Drawing.Size(285, 34);
            this.txtBoxLog.TabIndex = 26;
            // 
            // checkBoxSaveUser
            // 
            this.checkBoxSaveUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxSaveUser.AutoSize = true;
            this.checkBoxSaveUser.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSaveUser.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSaveUser.Location = new System.Drawing.Point(246, 375);
            this.checkBoxSaveUser.Name = "checkBoxSaveUser";
            this.checkBoxSaveUser.Size = new System.Drawing.Size(333, 46);
            this.checkBoxSaveUser.TabIndex = 31;
            this.checkBoxSaveUser.Text = "Зберегти користувача";
            this.checkBoxSaveUser.UseVisualStyleBackColor = false;
            this.checkBoxSaveUser.CheckedChanged += new System.EventHandler(this.сheckBoxSaveUser_CheckedChanged);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.checkBoxSaveUser);
            this.Controls.Add(this.txtBoxPass);
            this.Controls.Add(this.txtBoxLog);
            this.KeyPreview = true;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginFrm_FormClosing);
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginFrm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.TextBox txtBoxLog;
        private System.Windows.Forms.CheckBox checkBoxSaveUser;
    }
}