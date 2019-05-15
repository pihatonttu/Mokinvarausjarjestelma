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
        bool muokkaa = false;
        int toimipisteid;
        string nimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro;

        private void Lisaatoimipiste_Load(object sender, EventArgs e)
        {
            nimitxtbox.Text = nimi;
            lahitxtbox.Text = lahiosoite;
            postitoimitxtbox.Text = postitoimipaikka;
            postinrotxtbox.Text = postinro;
            emailtxtbox.Text = email;
            puhelinnrotxtbox.Text = puhelinnro;

        }

        public Lisaatoimipiste(int toimipisteid, string nimi, string lahiosoite, string postitoimipaikka, string postinro, string email, string puhelinnro)
        {
            InitializeComponent();

            this.toimipisteid = toimipisteid;
            this.nimi = nimi;
            this.lahiosoite = lahiosoite;
            this.postitoimipaikka = postitoimipaikka;
            this.postinro = postinro;
            this.email = email;
            this.puhelinnro = puhelinnro;
            muokkaa = true;
        }
        public Lisaatoimipiste()
        {
            InitializeComponent();
        }

        private void lisaamuokkaatietue()
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
                string kysely;
                if (muokkaa)
                {
                    kysely = @"UPDATE toimipiste SET nimi='" + nimi + "', lahiosoite='" + lahiosoite + "', postitoimipaikka='" + postitoimipaikka + "', postinro='" + postinro + "', email='" + email + "' , puhelinnro='" + puhelinnro + "'WHERE toimipiste_id='" + toimipisteid + "';";
                }
                else
                {
                    //Tällä kyselyllä haetaan tieto mysql tietokannasta
                    kysely = @"INSERT INTO toimipiste (nimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro)
                            VALUES('" + nimi + "', '" + lahiosoite + "', '" + postitoimipaikka + "', '" + postinro + "', '" + email + "' , '" + puhelinnro + "'); ";
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

            }
        }


        private void tallennabtn_Click(object sender, EventArgs e)
        {
            lisaamuokkaatietue();

            if (muokkaa)
            {

            }
        }
    }
}
