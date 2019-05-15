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
    public partial class LisaaAsiakas : Form
    {
        bool muokkaa = false;
        string etunimi, sukunimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro;
        int asiakasid;

        private void LisaaAsiakas_Load(object sender, EventArgs e)
        {
            textBox1.Text = etunimi;
            textBox2.Text = sukunimi;
            textBox3.Text = lahiosoite;
            textBox4.Text = postitoimipaikka;
            textBox5.Text = postinro;
            textBox6.Text = email;
            textBox7.Text = puhelinnro;
        }

        

        public LisaaAsiakas()
        {
            InitializeComponent();
        }

        public LisaaAsiakas(int asiakasid, string etunimi, string sukunimi, string lahiosoite, string postitoimipaikka, string postinro, string email, string puhelinnro)
        {
            InitializeComponent();

            this.asiakasid = asiakasid;
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.lahiosoite = lahiosoite;
            this.postitoimipaikka = postitoimipaikka;
            this.postinro = postinro;
            this.email = email;
            this.puhelinnro = puhelinnro;
            muokkaa = true;
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void lisaamuokkaaAsiakas()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string etunimi = textBox1.Text;
            string sukunimi = textBox2.Text;
            string lahisoite = textBox3.Text;
            string postitoimipaikka = textBox4.Text;
            string postinro = textBox5.Text;
            string email = textBox6.Text;
            string puhelinro = textBox7.Text;

            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null &&
                textBox5.Text != null && textBox6.Text != null && textBox7.Text != null)
            {
                string kysely;
                if (muokkaa)
                {
                    kysely = @"UPDATE asiakas SET etunimi='" + etunimi + "', sukunimi='" + sukunimi + "', lahiosoite='" + lahiosoite + "'," +
                        " postitoimipaikka='" + postitoimipaikka + "', postinro='" + postinro + "', email='" + email + 
                        "', puhelinnro='" + puhelinnro + "'WHERE asiakas_id='" + asiakasid + "';";
                }
                else
                {
                    //Tällä kyselyllä haetaan tieto mysql tietokannasta
                    kysely = @"INSERT INTO asiakas (etunimi, sukunimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro)
                            VALUES('" + etunimi + "', '" + sukunimi + "', '" + lahisoite + "', '"
                                + postitoimipaikka + "', '" + postinro + "', '" + email +
                                "', '" + puhelinro + "'); ";
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
            lisaamuokkaaAsiakas();

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
