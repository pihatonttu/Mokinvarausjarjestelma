namespace Käyttöliittymäluonnoksia
{
    partial class Laskujenhallinta
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridLasku = new System.Windows.Forms.DataGridView();
            this.poistabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLasku)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laskujen hallinta";
            // 
            // dataGridLasku
            // 
            this.dataGridLasku.AllowUserToAddRows = false;
            this.dataGridLasku.AllowUserToDeleteRows = false;
            this.dataGridLasku.AllowUserToOrderColumns = true;
            this.dataGridLasku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLasku.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridLasku.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridLasku.Location = new System.Drawing.Point(23, 49);
            this.dataGridLasku.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridLasku.Name = "dataGridLasku";
            this.dataGridLasku.RowHeadersVisible = false;
            this.dataGridLasku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLasku.Size = new System.Drawing.Size(819, 622);
            this.dataGridLasku.TabIndex = 1;
            // 
            // poistabtn
            // 
            this.poistabtn.Location = new System.Drawing.Point(23, 689);
            this.poistabtn.Margin = new System.Windows.Forms.Padding(4);
            this.poistabtn.Name = "poistabtn";
            this.poistabtn.Size = new System.Drawing.Size(100, 28);
            this.poistabtn.TabIndex = 4;
            this.poistabtn.Text = "Poista";
            this.poistabtn.UseVisualStyleBackColor = true;
            this.poistabtn.Click += new System.EventHandler(this.poistabtn_Click);
            // 
            // Laskujenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 735);
            this.Controls.Add(this.poistabtn);
            this.Controls.Add(this.dataGridLasku);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Laskujenhallinta";
            this.Text = "Laskujenhallinta";
            this.Load += new System.EventHandler(this.Laskujenhallinta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLasku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridLasku;
        private System.Windows.Forms.Button poistabtn;
    }
}