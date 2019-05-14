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
    public partial class Lisaalasku : Form
    {
        public Lisaalasku()
        {
            InitializeComponent();
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void lisaaLasku()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string nimi = textBox1.Text;
            string lahiosoite = textBox2.Text;
            string postitoimipaikka = textBox3.Text;
            string postinumero = textBox4.Text;
            string summa = textBox5.Text;
            string alv = textBox6.Text;
            

            if (textBox1.Text != null && textBox4.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                //Tällä kyselyllä haetaan tieto mysql tietokannasta
                string kysely = @"INSERT INTO lasku (nimi, lahiosoite,postitoimipaikka , postinro, summa, alv)
                            VALUES('" + nimi + "', '" + lahiosoite + "', '" + postitoimipaikka + "', '" + postinumero + "', '" + summa + "','" + alv + "');";

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

        private void tallennabtn_Click(object sender, EventArgs e)
        {
            lisaaLasku();
        }
    }
}
