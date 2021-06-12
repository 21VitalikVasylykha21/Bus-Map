namespace Bus_Map
{
    partial class BusMapFrm
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
            this.GMapUzhorod = new GMap.NET.WindowsForms.GMapControl();
            this.PanelElements = new System.Windows.Forms.Panel();
            this.GroupBoxRotate = new System.Windows.Forms.GroupBox();
            this.RotateGMapUzhorod = new System.Windows.Forms.TrackBar();
            this.GroupBoxAdres = new System.Windows.Forms.GroupBox();
            this.txtBoxAdres = new System.Windows.Forms.TextBox();
            this.GroupBoxInfoBus = new System.Windows.Forms.GroupBox();
            this.txtTimeBus = new System.Windows.Forms.TextBox();
            this.txtIntervalBus = new System.Windows.Forms.TextBox();
            this.txtDayBus = new System.Windows.Forms.TextBox();
            this.txtRoutBus = new System.Windows.Forms.TextBox();
            this.txtPriceBus = new System.Windows.Forms.TextBox();
            this.txtNameBus = new System.Windows.Forms.TextBox();
            this.PanelElements.SuspendLayout();
            this.GroupBoxRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotateGMapUzhorod)).BeginInit();
            this.GroupBoxAdres.SuspendLayout();
            this.GroupBoxInfoBus.SuspendLayout();
            this.SuspendLayout();
            // 
            // GMapUzhorod
            // 
            this.GMapUzhorod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GMapUzhorod.Bearing = 0F;
            this.GMapUzhorod.CanDragMap = true;
            this.GMapUzhorod.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMapUzhorod.GrayScaleMode = false;
            this.GMapUzhorod.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapUzhorod.LevelsKeepInMemmory = 5;
            this.GMapUzhorod.Location = new System.Drawing.Point(-1, 1);
            this.GMapUzhorod.MarkersEnabled = true;
            this.GMapUzhorod.MaxZoom = 2;
            this.GMapUzhorod.MinZoom = 2;
            this.GMapUzhorod.MouseWheelZoomEnabled = true;
            this.GMapUzhorod.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMapUzhorod.Name = "GMapUzhorod";
            this.GMapUzhorod.NegativeMode = false;
            this.GMapUzhorod.PolygonsEnabled = true;
            this.GMapUzhorod.RetryLoadTile = 0;
            this.GMapUzhorod.RoutesEnabled = true;
            this.GMapUzhorod.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMapUzhorod.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMapUzhorod.ShowTileGridLines = false;
            this.GMapUzhorod.Size = new System.Drawing.Size(1395, 825);
            this.GMapUzhorod.TabIndex = 1;
            this.GMapUzhorod.Zoom = 0D;
            this.GMapUzhorod.Load += new System.EventHandler(this.GMapUzhorod_Load);
            // 
            // PanelElements
            // 
            this.PanelElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelElements.BackColor = System.Drawing.Color.SteelBlue;
            this.PanelElements.Controls.Add(this.GroupBoxRotate);
            this.PanelElements.Controls.Add(this.GroupBoxAdres);
            this.PanelElements.Controls.Add(this.GroupBoxInfoBus);
            this.PanelElements.Location = new System.Drawing.Point(849, 1);
            this.PanelElements.Name = "PanelElements";
            this.PanelElements.Size = new System.Drawing.Size(551, 809);
            this.PanelElements.TabIndex = 2;
            // 
            // GroupBoxRotate
            // 
            this.GroupBoxRotate.Controls.Add(this.RotateGMapUzhorod);
            this.GroupBoxRotate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupBoxRotate.Location = new System.Drawing.Point(6, 709);
            this.GroupBoxRotate.Name = "GroupBoxRotate";
            this.GroupBoxRotate.Size = new System.Drawing.Size(539, 97);
            this.GroupBoxRotate.TabIndex = 4;
            this.GroupBoxRotate.TabStop = false;
            this.GroupBoxRotate.Text = "Поворот карти";
            // 
            // RotateGMapUzhorod
            // 
            this.RotateGMapUzhorod.BackColor = System.Drawing.Color.SteelBlue;
            this.RotateGMapUzhorod.Cursor = System.Windows.Forms.Cursors.Default;
            this.RotateGMapUzhorod.Location = new System.Drawing.Point(1, 34);
            this.RotateGMapUzhorod.Margin = new System.Windows.Forms.Padding(4);
            this.RotateGMapUzhorod.Maximum = 360;
            this.RotateGMapUzhorod.Name = "RotateGMapUzhorod";
            this.RotateGMapUzhorod.Size = new System.Drawing.Size(532, 56);
            this.RotateGMapUzhorod.TabIndex = 43;
            this.RotateGMapUzhorod.TickFrequency = 10;
            this.RotateGMapUzhorod.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.RotateGMapUzhorod.Scroll += new System.EventHandler(this.RotateGMapUzhorod_Scroll);
            // 
            // GroupBoxAdres
            // 
            this.GroupBoxAdres.Controls.Add(this.txtBoxAdres);
            this.GroupBoxAdres.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupBoxAdres.Location = new System.Drawing.Point(4, 610);
            this.GroupBoxAdres.Name = "GroupBoxAdres";
            this.GroupBoxAdres.Size = new System.Drawing.Size(542, 93);
            this.GroupBoxAdres.TabIndex = 45;
            this.GroupBoxAdres.TabStop = false;
            this.GroupBoxAdres.Text = "Знайти адрес:";
            // 
            // txtBoxAdres
            // 
            this.txtBoxAdres.AccessibleDescription = "";
            this.txtBoxAdres.AccessibleName = "";
            this.txtBoxAdres.Location = new System.Drawing.Point(110, 35);
            this.txtBoxAdres.Name = "txtBoxAdres";
            this.txtBoxAdres.Size = new System.Drawing.Size(423, 34);
            this.txtBoxAdres.TabIndex = 3;
            this.txtBoxAdres.Tag = "";
            this.txtBoxAdres.Text = "Ужгород, ";
            // 
            // GroupBoxInfoBus
            // 
            this.GroupBoxInfoBus.Controls.Add(this.txtTimeBus);
            this.GroupBoxInfoBus.Controls.Add(this.txtIntervalBus);
            this.GroupBoxInfoBus.Controls.Add(this.txtDayBus);
            this.GroupBoxInfoBus.Controls.Add(this.txtRoutBus);
            this.GroupBoxInfoBus.Controls.Add(this.txtPriceBus);
            this.GroupBoxInfoBus.Controls.Add(this.txtNameBus);
            this.GroupBoxInfoBus.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupBoxInfoBus.Location = new System.Drawing.Point(7, 250);
            this.GroupBoxInfoBus.Name = "GroupBoxInfoBus";
            this.GroupBoxInfoBus.Size = new System.Drawing.Size(539, 354);
            this.GroupBoxInfoBus.TabIndex = 44;
            this.GroupBoxInfoBus.TabStop = false;
            this.GroupBoxInfoBus.Text = "Інформація про автобуси";
            // 
            // txtTimeBus
            // 
            this.txtTimeBus.Location = new System.Drawing.Point(186, 233);
            this.txtTimeBus.Name = "txtTimeBus";
            this.txtTimeBus.ReadOnly = true;
            this.txtTimeBus.Size = new System.Drawing.Size(327, 34);
            this.txtTimeBus.TabIndex = 45;
            this.txtTimeBus.Text = "  -";
            this.txtTimeBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIntervalBus
            // 
            this.txtIntervalBus.Location = new System.Drawing.Point(186, 133);
            this.txtIntervalBus.Name = "txtIntervalBus";
            this.txtIntervalBus.ReadOnly = true;
            this.txtIntervalBus.Size = new System.Drawing.Size(327, 34);
            this.txtIntervalBus.TabIndex = 3;
            this.txtIntervalBus.Text = "  -";
            this.txtIntervalBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDayBus
            // 
            this.txtDayBus.Location = new System.Drawing.Point(186, 183);
            this.txtDayBus.Name = "txtDayBus";
            this.txtDayBus.ReadOnly = true;
            this.txtDayBus.Size = new System.Drawing.Size(327, 34);
            this.txtDayBus.TabIndex = 44;
            this.txtDayBus.Text = "  -";
            this.txtDayBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRoutBus
            // 
            this.txtRoutBus.Location = new System.Drawing.Point(186, 280);
            this.txtRoutBus.Multiline = true;
            this.txtRoutBus.Name = "txtRoutBus";
            this.txtRoutBus.ReadOnly = true;
            this.txtRoutBus.Size = new System.Drawing.Size(325, 60);
            this.txtRoutBus.TabIndex = 1;
            this.txtRoutBus.Text = "  -";
            this.txtRoutBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPriceBus
            // 
            this.txtPriceBus.Location = new System.Drawing.Point(186, 83);
            this.txtPriceBus.Name = "txtPriceBus";
            this.txtPriceBus.ReadOnly = true;
            this.txtPriceBus.Size = new System.Drawing.Size(327, 34);
            this.txtPriceBus.TabIndex = 2;
            this.txtPriceBus.Text = "  -";
            this.txtPriceBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNameBus
            // 
            this.txtNameBus.Location = new System.Drawing.Point(186, 33);
            this.txtNameBus.Name = "txtNameBus";
            this.txtNameBus.ReadOnly = true;
            this.txtNameBus.Size = new System.Drawing.Size(327, 34);
            this.txtNameBus.TabIndex = 0;
            this.txtNameBus.Text = "  -";
            this.txtNameBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BusMapFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 821);
            this.Controls.Add(this.PanelElements);
            this.Controls.Add(this.GMapUzhorod);
            this.KeyPreview = true;
            this.Name = "BusMapFrm";
            this.Text = "BusMapFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusMapFrm_FormClosing);
            this.Load += new System.EventHandler(this.BusMapFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BusMapFrm_KeyDown);
            this.PanelElements.ResumeLayout(false);
            this.GroupBoxRotate.ResumeLayout(false);
            this.GroupBoxRotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotateGMapUzhorod)).EndInit();
            this.GroupBoxAdres.ResumeLayout(false);
            this.GroupBoxAdres.PerformLayout();
            this.GroupBoxInfoBus.ResumeLayout(false);
            this.GroupBoxInfoBus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl GMapUzhorod;
        private System.Windows.Forms.Panel PanelElements;
        private System.Windows.Forms.GroupBox GroupBoxInfoBus;
        private System.Windows.Forms.TextBox txtTimeBus;
        private System.Windows.Forms.TextBox txtIntervalBus;
        private System.Windows.Forms.TextBox txtDayBus;
        private System.Windows.Forms.TextBox txtRoutBus;
        private System.Windows.Forms.TextBox txtPriceBus;
        private System.Windows.Forms.TextBox txtNameBus;
        private System.Windows.Forms.TrackBar RotateGMapUzhorod;
        private System.Windows.Forms.GroupBox GroupBoxAdres;
        private System.Windows.Forms.TextBox txtBoxAdres;
        private System.Windows.Forms.GroupBox GroupBoxRotate;
    }
}