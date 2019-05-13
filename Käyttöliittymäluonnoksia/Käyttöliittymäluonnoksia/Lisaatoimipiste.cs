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
    public partial class Lisaatoimipiste : Form
    {
        public Lisaatoimipiste()
        {
            InitializeComponent();
        }

        private void LisaaTietue()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            
            string nimi = nimitxtbox.Text;
            string lahiosoite = lahitxtbox.Text;
            string postitoimipaikka = postitoimitxtbox.Text;
            string postinro = postinrotxtbox.Text;
            string email = emailtxtbox.Text;
            string puhelinnro = puhelinnrotxtbox.Text;

            if (postitoimitxtbox.Text != null && lahitxtbox.Text != null)
            {
                //Tällä kyselyllä haetaan tieto mysql tietokannasta
                string kysely = @"INSERT INTO toimipiste (nimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro)
                            VALUES('" + nimi + "', '" + lahiosoite + "', '" + postitoimipaikka + "', '" + postinro + "', '" + email + "' , '" + puhelinnro + "'); ";

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
            LisaaTietue();
        }
    }
}
