namespace Geo.Tools.Viewer.Win
{
    partial class WktForm
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
            this.eWkt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pWkt = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWkt)).BeginInit();
            this.SuspendLayout();
            // 
            // eWkt
            // 
            this.eWkt.Dock = System.Windows.Forms.DockStyle.Top;
            this.eWkt.Location = new System.Drawing.Point(0, 0);
            this.eWkt.Multiline = true;
            this.eWkt.Name = "eWkt";
            this.eWkt.Size = new System.Drawing.Size(800, 116);
            this.eWkt.TabIndex = 0;
            this.eWkt.Text = "POLYGON ((0 0, 50 35, 100 0, 50 -35, 0 0), (0.2 0, 50 34.8, 99.8 0, 50 -34.8, 0.2" +
    " 0))";
            this.eWkt.TextChanged += new System.EventHandler(this.eWkt_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pWkt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 334);
            this.panel1.TabIndex = 1;
            // 
            // pWkt
            // 
            this.pWkt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pWkt.Location = new System.Drawing.Point(0, 0);
            this.pWkt.Name = "pWkt";
            this.pWkt.Size = new System.Drawing.Size(800, 334);
            this.pWkt.TabIndex = 0;
            this.pWkt.TabStop = false;
            // 
            // WktForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eWkt);
            this.Name = "WktForm";
            this.Text = "WktForm";
            this.Load += new System.EventHandler(this.WktForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pWkt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox eWkt;
        private Panel panel1;
        private PictureBox pWkt;
    }
}