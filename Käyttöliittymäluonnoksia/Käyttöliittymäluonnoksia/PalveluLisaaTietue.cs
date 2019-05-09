using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Käyttöliittymäluonnoksia
{
    public partial class PalveluLisaaTietue : Form
    {
        public PalveluLisaaTietue()
        {
            InitializeComponent();
        }

        private void LisaaTietue()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string palveluid = textBox1.Text;
            string toimipisteid = textBox2.Text;
            string nimi = textBox4.Text;
            string kuvaus = textBox6.Text;
            string hinta = textBox5.Text;
            string alv = textBox7.Text;
            if (textBox1.Text != null && textBox2.Text != null)
            {
                //Tällä kyselyllä haetaan tieto mysql tietokannasta
                string kysely = @"INSERT INTO palvelu
                            VALUES('"+palveluid+"', '"+toimipisteid+"', '"+nimi+"', '"+kuvaus+"', '"+hinta+"', '"+alv+"'); ";

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }
                this.Close();
            }
            else
            {

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LisaaTietue();
        }
    }
}
