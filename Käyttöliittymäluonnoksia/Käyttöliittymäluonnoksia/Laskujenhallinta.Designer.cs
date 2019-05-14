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
            this.lisaabtn = new System.Windows.Forms.Button();
            this.muokkaabtn = new System.Windows.Forms.Button();
            this.poistabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLasku)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laskujen hallinta";
            // 
            // dataGridLasku
            // 
            this.dataGridLasku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLasku.Location = new System.Drawing.Point(17, 111);
            this.dataGridLasku.Name = "dataGridLasku";
            this.dataGridLasku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLasku.Size = new System.Drawing.Size(614, 434);
            this.dataGridLasku.TabIndex = 1;
            // 
            // lisaabtn
            // 
            this.lisaabtn.Location = new System.Drawing.Point(556, 562);
            this.lisaabtn.Name = "lisaabtn";
            this.lisaabtn.Size = new System.Drawing.Size(75, 23);
            this.lisaabtn.TabIndex = 2;
            this.lisaabtn.Text = "Lisää";
            this.lisaabtn.UseVisualStyleBackColor = true;
            this.lisaabtn.Click += new System.EventHandler(this.lisaabtn_Click);
            // 
            // muokkaabtn
            // 
            this.muokkaabtn.Location = new System.Drawing.Point(17, 561);
            this.muokkaabtn.Name = "muokkaabtn";
            this.muokkaabtn.Size = new System.Drawing.Size(75, 23);
            this.muokkaabtn.TabIndex = 3;
            this.muokkaabtn.Text = "Muokkaa";
            this.muokkaabtn.UseVisualStyleBackColor = true;
            // 
            // poistabtn
            // 
            this.poistabtn.Location = new System.Drawing.Point(99, 560);
            this.poistabtn.Name = "poistabtn";
            this.poistabtn.Size = new System.Drawing.Size(75, 23);
            this.poistabtn.TabIndex = 4;
            this.poistabtn.Text = "Poista";
            this.poistabtn.UseVisualStyleBackColor = true;
            this.poistabtn.Click += new System.EventHandler(this.poistabtn_Click);
            // 
            // Laskujenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 597);
            this.Controls.Add(this.poistabtn);
            this.Controls.Add(this.muokkaabtn);
            this.Controls.Add(this.lisaabtn);
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
        private System.Windows.Forms.Button lisaabtn;
        private System.Windows.Forms.Button muokkaabtn;
        private System.Windows.Forms.Button poistabtn;
    }
}