namespace ForeignExchange
{
    partial class ForeignExchange
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
            this.lstRates = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.lstRates)).BeginInit();
            this.SuspendLayout();
            // 
            // lstRates
            // 
            this.lstRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstRates.Location = new System.Drawing.Point(12, 12);
            this.lstRates.Name = "lstRates";
            this.lstRates.Size = new System.Drawing.Size(797, 466);
            this.lstRates.TabIndex = 0;
            // 
            // ForeignExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 490);
            this.Controls.Add(this.lstRates);
            this.Name = "ForeignExchange";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ForeignExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstRates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lstRates;
    }
}

