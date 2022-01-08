
namespace Cars
{
    partial class Map
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
            this.MapBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // MapBox
            // 
            this.MapBox.Location = new System.Drawing.Point(12, 23);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(1247, 636);
            this.MapBox.TabIndex = 0;
            this.MapBox.TabStop = false;
            this.MapBox.Text = "Map Box";
            this.MapBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MapBox_Paint);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 671);
            this.Controls.Add(this.MapBox);
            this.Name = "Map";
            this.Text = "Map";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MapBox;
    }
}