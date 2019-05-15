namespace Käyttöliittymäluonnoksia
{
    partial class Seuranta
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
            this.mokkicombo = new System.Windows.Forms.ComboBox();
            this.dtpalkumokki = new System.Windows.Forms.DateTimePicker();
            this.dtploppumokki = new System.Windows.Forms.DateTimePicker();
            this.dtploppupalvelu = new System.Windows.Forms.DateTimePicker();
            this.dtpalkupalvelu = new System.Windows.Forms.DateTimePicker();
            this.palvelucombo = new System.Windows.Forms.ComboBox();
            this.dataGridpalvelut = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.datagridmok = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridpalvelut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridmok)).BeginInit();
            this.SuspendLayout();
            // 
            // mokkicombo
            // 
            this.mokkicombo.FormattingEnabled = true;
            this.mokkicombo.Location = new System.Drawing.Point(12, 56);
            this.mokkicombo.Name = "mokkicombo";
            this.mokkicombo.Size = new System.Drawing.Size(121, 21);
            this.mokkicombo.TabIndex = 0;
            // 
            // dtpalkumokki
            // 
            this.dtpalkumokki.Location = new System.Drawing.Point(12, 98);
            this.dtpalkumokki.Name = "dtpalkumokki";
            this.dtpalkumokki.Size = new System.Drawing.Size(200, 20);
            this.dtpalkumokki.TabIndex = 1;
            // 
            // dtploppumokki
            // 
            this.dtploppumokki.Location = new System.Drawing.Point(12, 141);
            this.dtploppumokki.Name = "dtploppumokki";
            this.dtploppumokki.Size = new System.Drawing.Size(200, 20);
            this.dtploppumokki.TabIndex = 2;
            // 
            // dtploppupalvelu
            // 
            this.dtploppupalvelu.Location = new System.Drawing.Point(359, 141);
            this.dtploppupalvelu.Name = "dtploppupalvelu";
            this.dtploppupalvelu.Size = new System.Drawing.Size(200, 20);
            this.dtploppupalvelu.TabIndex = 5;
            // 
            // dtpalkupalvelu
            // 
            this.dtpalkupalvelu.Location = new System.Drawing.Point(359, 98);
            this.dtpalkupalvelu.Name = "dtpalkupalvelu";
            this.dtpalkupalvelu.Size = new System.Drawing.Size(200, 20);
            this.dtpalkupalvelu.TabIndex = 4;
            // 
            // palvelucombo
            // 
            this.palvelucombo.FormattingEnabled = true;
            this.palvelucombo.Location = new System.Drawing.Point(359, 56);
            this.palvelucombo.Name = "palvelucombo";
            this.palvelucombo.Size = new System.Drawing.Size(121, 21);
            this.palvelucombo.TabIndex = 3;
            // 
            // dataGridpalvelut
            // 
            this.dataGridpalvelut.AllowUserToAddRows = false;
            this.dataGridpalvelut.AllowUserToDeleteRows = false;
            this.dataGridpalvelut.AllowUserToOrderColumns = true;
            this.dataGridpalvelut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridpalvelut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridpalvelut.Location = new System.Drawing.Point(359, 208);
            this.dataGridpalvelut.Name = "dataGridpalvelut";
            this.dataGridpalvelut.RowHeadersVisible = false;
            this.dataGridpalvelut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridpalvelut.Size = new System.Drawing.Size(304, 229);
            this.dataGridpalvelut.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Hae";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hae vapaat palvelut";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Hae";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hae vapaat mökit";
            // 
            // datagridmok
            // 
            this.datagridmok.AllowUserToAddRows = false;
            this.datagridmok.AllowUserToDeleteRows = false;
            this.datagridmok.AllowUserToOrderColumns = true;
            this.datagridmok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridmok.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datagridmok.Location = new System.Drawing.Point(12, 209);
            this.datagridmok.Name = "datagridmok";
            this.datagridmok.RowHeadersVisible = false;
            this.datagridmok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridmok.Size = new System.Drawing.Size(304, 229);
            this.datagridmok.TabIndex = 14;
            // 
            // Seuranta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.datagridmok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridpalvelut);
            this.Controls.Add(this.dtploppupalvelu);
            this.Controls.Add(this.dtpalkupalvelu);
            this.Controls.Add(this.palvelucombo);
            this.Controls.Add(this.dtploppumokki);
            this.Controls.Add(this.dtpalkumokki);
            this.Controls.Add(this.mokkicombo);
            this.Name = "Seuranta";
            this.Text = "Seuranta";
            this.Load += new System.EventHandler(this.Seuranta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridpalvelut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridmok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mokkicombo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.ComboBox palvelucombo;
        private System.Windows.Forms.DataGridView dataGridpalvelut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpalkumokki;
        private System.Windows.Forms.DateTimePicker dtploppumokki;
        private System.Windows.Forms.DateTimePicker dtploppupalvelu;
        private System.Windows.Forms.DateTimePicker dtpalkupalvelu;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView datagridmok;
    }
}