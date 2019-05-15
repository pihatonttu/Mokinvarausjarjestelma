namespace Käyttöliittymäluonnoksia
{
    partial class PalveluLisaaTietue
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
            this.nimitxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hintatxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kuvaustxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.alvtxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TallennaBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Toimipiste";
            // 
            // nimitxt
            // 
            this.nimitxt.Location = new System.Drawing.Point(96, 152);
            this.nimitxt.Name = "nimitxt";
            this.nimitxt.Size = new System.Drawing.Size(219, 22);
            this.nimitxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nimi";
            // 
            // hintatxt
            // 
            this.hintatxt.Location = new System.Drawing.Point(96, 208);
            this.hintatxt.Name = "hintatxt";
            this.hintatxt.Size = new System.Drawing.Size(219, 22);
            this.hintatxt.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hinta";
            // 
            // kuvaustxt
            // 
            this.kuvaustxt.Location = new System.Drawing.Point(96, 180);
            this.kuvaustxt.Name = "kuvaustxt";
            this.kuvaustxt.Size = new System.Drawing.Size(219, 22);
            this.kuvaustxt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kuvaus";
            // 
            // alvtxt
            // 
            this.alvtxt.Location = new System.Drawing.Point(96, 236);
            this.alvtxt.Name = "alvtxt";
            this.alvtxt.Size = new System.Drawing.Size(219, 22);
            this.alvtxt.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Alv";
            // 
            // TallennaBtn
            // 
            this.TallennaBtn.Location = new System.Drawing.Point(180, 290);
            this.TallennaBtn.Name = "TallennaBtn";
            this.TallennaBtn.Size = new System.Drawing.Size(135, 51);
            this.TallennaBtn.TabIndex = 14;
            this.TallennaBtn.Text = "Tallenna";
            this.TallennaBtn.UseVisualStyleBackColor = true;
            this.TallennaBtn.Click += new System.EventHandler(this.TallennaBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 24);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 36);
            this.label2.TabIndex = 16;
            this.label2.Text = "Lisää Palvelu";
            // 
            // PalveluLisaaTietue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 366);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TallennaBtn);
            this.Controls.Add(this.alvtxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hintatxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kuvaustxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nimitxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "PalveluLisaaTietue";
            this.Text = "PalveluLisaaTietue";
            this.Load += new System.EventHandler(this.PalveluLisaaTietue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nimitxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hintatxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kuvaustxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alvtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button TallennaBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}