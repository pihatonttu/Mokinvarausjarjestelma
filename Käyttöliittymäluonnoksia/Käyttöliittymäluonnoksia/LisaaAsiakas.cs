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
        public LisaaAsiakas()
        {
            InitializeComponent();
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void palveluLisaaAsiakas()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string asiakkaanEtunimi = textBox1.Text;
            string asiakkaanSukunimi = textBox2.Text;
            string asiakkaanLahisoite = textBox3.Text;
            string asiakkaanPostitoimipaikka = textBox4.Text;
            string asiakkaanPostinro = textBox5.Text;
            string asiakkaanSahkoposti = textBox6.Text;
            string asiakkaanPuhelinro = textBox7.Text;

            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null &&
                textBox5.Text != null && textBox6.Text != null && textBox7.Text != null)
            {
                //Tällä kyselyllä haetaan tieto mysql tietokannasta
                string kysely = @"INSERT INTO asiakas (etunimi, sukunimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro)
                            VALUES('" + asiakkaanEtunimi + "', '" + asiakkaanSukunimi + "', '" + asiakkaanLahisoite + "', '" 
                            + asiakkaanPostitoimipaikka + "', '" + asiakkaanPostinro + "', '" + asiakkaanSahkoposti +
                            "', '" +asiakkaanPuhelinro + "'); ";

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
            palveluLisaaAsiakas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
