namespace Käyttöliittymäluonnoksia
{
    partial class Alkuvalikko
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
            this.varausbtn = new System.Windows.Forms.Button();
            this.laskubtn = new System.Windows.Forms.Button();
            this.mökkibtn = new System.Windows.Forms.Button();
            this.palvelubtn = new System.Windows.Forms.Button();
            this.toimipistebtn = new System.Windows.Forms.Button();
            this.lisavarausbtn = new System.Windows.Forms.Button();
            this.asiakasbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mökin varausjärjestelmän";
            // 
            // varausbtn
            // 
            this.varausbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.varausbtn.Location = new System.Drawing.Point(13, 108);
            this.varausbtn.Name = "varausbtn";
            this.varausbtn.Size = new System.Drawing.Size(156, 54);
            this.varausbtn.TabIndex = 1;
            this.varausbtn.Text = "Varaukset";
            this.varausbtn.UseVisualStyleBackColor = true;
            this.varausbtn.Click += new System.EventHandler(this.varausbtn_Click);
            // 
            // laskubtn
            // 
            this.laskubtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.laskubtn.Location = new System.Drawing.Point(13, 399);
            this.laskubtn.Name = "laskubtn";
            this.laskubtn.Size = new System.Drawing.Size(156, 54);
            this.laskubtn.TabIndex = 2;
            this.laskubtn.Text = "Laskut";
            this.laskubtn.UseVisualStyleBackColor = true;
            // 
            // mökkibtn
            // 
            this.mökkibtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.mökkibtn.Location = new System.Drawing.Point(12, 263);
            this.mökkibtn.Name = "mökkibtn";
            this.mökkibtn.Size = new System.Drawing.Size(156, 54);
            this.mökkibtn.TabIndex = 3;
            this.mökkibtn.Text = "Mökit";
            this.mökkibtn.UseVisualStyleBackColor = true;
            this.mökkibtn.Click += new System.EventHandler(this.mökkibtn_Click);
            // 
            // palvelubtn
            // 
            this.palvelubtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.palvelubtn.Location = new System.Drawing.Point(475, 263);
            this.palvelubtn.Name = "palvelubtn";
            this.palvelubtn.Size = new System.Drawing.Size(156, 54);
            this.palvelubtn.TabIndex = 4;
            this.palvelubtn.Text = "Palvelu";
            this.palvelubtn.UseVisualStyleBackColor = true;
            this.palvelubtn.Click += new System.EventHandler(this.palvelubtn_Click);
            // 
            // toimipistebtn
            // 
            this.toimipistebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.toimipistebtn.Location = new System.Drawing.Point(12, 531);
            this.toimipistebtn.Name = "toimipistebtn";
            this.toimipistebtn.Size = new System.Drawing.Size(156, 54);
            this.toimipistebtn.TabIndex = 5;
            this.toimipistebtn.Text = "Toimipisteet";
            this.toimipistebtn.UseVisualStyleBackColor = true;
            this.toimipistebtn.Click += new System.EventHandler(this.toimipistebtn_Click);
            // 
            // lisavarausbtn
            // 
            this.lisavarausbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lisavarausbtn.Location = new System.Drawing.Point(475, 108);
            this.lisavarausbtn.Name = "lisavarausbtn";
            this.lisavarausbtn.Size = new System.Drawing.Size(156, 54);
            this.lisavarausbtn.TabIndex = 6;
            this.lisavarausbtn.Text = "Lisää varaus";
            this.lisavarausbtn.UseVisualStyleBackColor = true;
            // 
            // asiakasbtn
            // 
            this.asiakasbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.asiakasbtn.Location = new System.Drawing.Point(475, 399);
            this.asiakasbtn.Name = "asiakasbtn";
            this.asiakasbtn.Size = new System.Drawing.Size(156, 54);
            this.asiakasbtn.TabIndex = 7;
            this.asiakasbtn.Text = "Asiakkaat";
            this.asiakasbtn.UseVisualStyleBackColor = true;
            // 
            // Alkuvalikko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 597);
            this.Controls.Add(this.asiakasbtn);
            this.Controls.Add(this.lisavarausbtn);
            this.Controls.Add(this.toimipistebtn);
            this.Controls.Add(this.palvelubtn);
            this.Controls.Add(this.mökkibtn);
            this.Controls.Add(this.laskubtn);
            this.Controls.Add(this.varausbtn);
            this.Controls.Add(this.label1);
            this.Name = "Alkuvalikko";
            this.Text = "Alkuvalikko";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button varausbtn;
        private System.Windows.Forms.Button laskubtn;
        private System.Windows.Forms.Button mökkibtn;
        private System.Windows.Forms.Button palvelubtn;
        private System.Windows.Forms.Button toimipistebtn;
        private System.Windows.Forms.Button lisavarausbtn;
        private System.Windows.Forms.Button asiakasbtn;
    }
}