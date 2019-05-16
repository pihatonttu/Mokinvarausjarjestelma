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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLasku)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(226, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
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
            this.dataGridLasku.Location = new System.Drawing.Point(17, 40);
            this.dataGridLasku.Name = "dataGridLasku";
            this.dataGridLasku.RowHeadersVisible = false;
            this.dataGridLasku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLasku.Size = new System.Drawing.Size(614, 518);
            this.dataGridLasku.TabIndex = 1;
            // 
            // poistabtn
            // 
            this.poistabtn.Location = new System.Drawing.Point(17, 564);
            this.poistabtn.Name = "poistabtn";
            this.poistabtn.Size = new System.Drawing.Size(75, 23);
            this.poistabtn.TabIndex = 4;
            this.poistabtn.Text = "Poista";
            this.poistabtn.UseVisualStyleBackColor = true;
            this.poistabtn.Click += new System.EventHandler(this.poistabtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Paperilasku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(525, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Lasku sähköpostiin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Laskujenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 597);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.poistabtn);
            this.Controls.Add(this.dataGridLasku);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}