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
        bool muokkaa = false;
        string nimi, osoite, kuvaus;
        int mökkiid, hinta;

        public LisaaMokki()
        {
            InitializeComponent();
        }

        public LisaaMokki(string nimi, string osoite, int mökkiid, string kuvaus,int hinta)
        {           
            InitializeComponent();
            this.nimi = nimi;
            this.osoite = osoite;
            this.kuvaus = kuvaus;
            this.mökkiid = mökkiid;
            this.hinta = hinta;
            muokkaa = true;
        }

        private void LisaaMokki_Load(object sender, EventArgs e)
        {
            textBox1.Text = nimi;
            textBox2.Text = osoite;
            textBox4.Text = kuvaus;
            numericUpDown1.Value = hinta;
        }


        //Haetaan tieto ja linkitetään se Datagridiin
        private void lisaamuokkaaMokki()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string nimi = textBox1.Text;
            string osoite = textBox2.Text;
            string kuvaus = textBox4.Text;
            string hinta = numericUpDown1.Value.ToString();

            if (textBox1.Text != null && textBox4.Text != null && textBox2.Text != null && numericUpDown1.Value != 0)
            {
                string kysely;
                if (muokkaa)
                {
                    kysely = @"UPDATE mökki SET nimi='" + nimi + "', osoite='" + osoite + "', kuvaus='" + kuvaus + "', hinta='" + hinta + "'WHERE mökki_id='" + mökkiid + "';";
                }
                else
                {
                    //Tällä kyselyllä haetaan tieto mysql tietokannasta
                    kysely = @"INSERT INTO mökki (nimi, osoite, kuvaus, hinta)
                            VALUES('" + nimi + "', '" + osoite + "', '" + kuvaus + "', '" + hinta + "'); ";
                }
                

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
                MessageBox.Show("Et voi tallentaa tyhjiä kenttiä.", "Virheilmoitus");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lisaamuokkaaMokki();

            if (muokkaa)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
