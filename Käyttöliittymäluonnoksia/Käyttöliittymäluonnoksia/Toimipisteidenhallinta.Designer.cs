namespace Käyttöliittymäluonnoksia
{
    partial class Toimipisteidenhallinta
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
            this.dataGridToimipiste = new System.Windows.Forms.DataGridView();
            this.muokkaabtn = new System.Windows.Forms.Button();
            this.lisääbtn = new System.Windows.Forms.Button();
            this.poistabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridToimipiste)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valitse toimipiste";
            // 
            // dataGridToimipiste
            // 
            this.dataGridToimipiste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridToimipiste.Location = new System.Drawing.Point(12, 36);
            this.dataGridToimipiste.Name = "dataGridToimipiste";
            this.dataGridToimipiste.Size = new System.Drawing.Size(615, 520);
            this.dataGridToimipiste.TabIndex = 1;
            // 
            // muokkaabtn
            // 
            this.muokkaabtn.Location = new System.Drawing.Point(12, 562);
            this.muokkaabtn.Name = "muokkaabtn";
            this.muokkaabtn.Size = new System.Drawing.Size(75, 23);
            this.muokkaabtn.TabIndex = 2;
            this.muokkaabtn.Text = "Muokkaa";
            this.muokkaabtn.UseVisualStyleBackColor = true;
            // 
            // lisääbtn
            // 
            this.lisääbtn.Location = new System.Drawing.Point(556, 562);
            this.lisääbtn.Name = "lisääbtn";
            this.lisääbtn.Size = new System.Drawing.Size(75, 23);
            this.lisääbtn.TabIndex = 3;
            this.lisääbtn.Text = "Lisää";
            this.lisääbtn.UseVisualStyleBackColor = true;
            this.lisääbtn.Click += new System.EventHandler(this.lisääbtn_Click);
            // 
            // poistabtn
            // 
            this.poistabtn.Location = new System.Drawing.Point(93, 562);
            this.poistabtn.Name = "poistabtn";
            this.poistabtn.Size = new System.Drawing.Size(75, 23);
            this.poistabtn.TabIndex = 4;
            this.poistabtn.Text = "Poista";
            this.poistabtn.UseVisualStyleBackColor = true;
            // 
            // Toimipisteidenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 597);
            this.Controls.Add(this.poistabtn);
            this.Controls.Add(this.lisääbtn);
            this.Controls.Add(this.muokkaabtn);
            this.Controls.Add(this.dataGridToimipiste);
            this.Controls.Add(this.label1);
            this.Name = "Toimipisteidenhallinta";
            this.Text = "Toimipisteidenhallinta";
            this.Load += new System.EventHandler(this.Toimipisteidenhallinta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridToimipiste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridToimipiste;
        private System.Windows.Forms.Button muokkaabtn;
        private System.Windows.Forms.Button lisääbtn;
        private System.Windows.Forms.Button poistabtn;
    }
}