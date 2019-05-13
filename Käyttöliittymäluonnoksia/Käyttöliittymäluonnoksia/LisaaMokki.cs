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
    public partial class LisaaMokki : Form
    {
        public LisaaMokki()
        {
            InitializeComponent();
        }


        //Haetaan tieto ja linkitetään se Datagridiin
        private void PalveluLisaaMokki()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            String mokinNimi = textBox1.Text;
            String mokinOsoite = textBox2.Text;
            String mokinKuvaus = textBox4.Text;
            int mokinHinta = int.Parse(textBox3.Text);

            if (textBox1.Text != null && textBox4.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                //Tällä kyselyllä haetaan tieto mysql tietokannasta
                string kysely = @"INSERT INTO mökki (nimi, osoite, kuvaus, hinta)
                            VALUES('" + mokinNimi + "', '" + mokinOsoite + "', '" + mokinKuvaus + "', '" + mokinHinta + "'); ";

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

        private void button1_Click(object sender, EventArgs e)
        {
            PalveluLisaaMokki();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
