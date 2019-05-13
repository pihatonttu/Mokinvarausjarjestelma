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
    public partial class Lisaa_muokkaa_mokki : Form
    {
        public Lisaa_muokkaa_mokki()
        {
            InitializeComponent();
        }

        private class Tiedot
        {
            private string nimi;
            private string osoite;
            private string toimipiste;
            private string kuvaus;
            private double hinta;

            public Tiedot(string nimi, string osoite, string toimipiste, string kuvaus, double hinta)
            {
                this.nimi = nimi;
                this.osoite = osoite;
                this.toimipiste = toimipiste;
                this.kuvaus = kuvaus;
                this.hinta = hinta;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tiedot tiedot = new Tiedot(textBox2.Text, textBox3.Text, textBox1.Text, richTextBox1.Text, double.Parse(textBox4.Text));

            
        }

        private void Lisaa_tietue() {

            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string kysely = @"INSERT INTO `mökki` (`nimi`, `osoite`, `mökki_id`, `kuvaus`) 
                            VALUES('mökki1', 'opistotie', '1', 'Tämä on hyvä mökki')";

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
            }
        }
    }
}
