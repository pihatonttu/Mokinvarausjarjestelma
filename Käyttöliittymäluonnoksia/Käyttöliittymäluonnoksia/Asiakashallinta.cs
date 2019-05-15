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
    public partial class Asiakashallinta : Form
    {
        public Asiakashallinta()
        {
            InitializeComponent();
        }

        //Mysql serverin tiedot
        string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

        //Haetaan tieto ja linkitetään se Datagridiin
        private void LinkitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = "SELECT *  FROM asiakas";

            //Lähetetään kysely serverille
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();

                //Jos lista ei ole tyhjä näytetään se käyttäjälle
                if (dt.Rows.Count > 0)
                {
                    dataGridAsiakas.DataSource = dt;
                }
            }
        }

        //Tietueen poisto funktio
        private void PoistaTietue()
        {
            string asiakasid;

            //Onko valittu mitään
            if (dataGridAsiakas.SelectedRows.Count != 0)
            {
                //Otetaan talteen ensimmäisen valitun asiakas id
                asiakasid = this.dataGridAsiakas.SelectedRows[0].Cells["asiakas_id"].Value.ToString();

                //Tietueen poisto mysql kysely
                string kysely = @"DELETE FROM asiakas WHERE asiakas_id=" + asiakasid;

                //Otetaan yhteys serveriin ja lähetetään poisto mysql kysely sinne
                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }
                //Poistetaan rivi näkyvistä
                this.dataGridAsiakas.Rows.RemoveAt(this.dataGridAsiakas.SelectedRows[0].Index);
            }
        }

        //formin latautuessa
        private void Asiakashallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }

        //Poistanappi
        private void button2_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        //Lisäänappi
        private void button1_Click(object sender, EventArgs e)
        {
            new LisaaAsiakas().ShowDialog();
            LinkitaTietokanta();
        }

        //Muokkausnappi
        private void button3_Click(object sender, EventArgs e)
        {
            //Kerätään tiedot
            int asiakasid = int.Parse(this.dataGridAsiakas.SelectedRows[0].Cells["asiakas_id"].Value.ToString());
            string etunimi = this.dataGridAsiakas.SelectedRows[0].Cells["etunimi"].Value.ToString();
            string sukunimi = this.dataGridAsiakas.SelectedRows[0].Cells["sukunimi"].Value.ToString();
            string lahiosoite = this.dataGridAsiakas.SelectedRows[0].Cells["lahiosoite"].Value.ToString();
            string postitoimipaikka = this.dataGridAsiakas.SelectedRows[0].Cells["postitoimipaikka"].Value.ToString();
            string postinro = this.dataGridAsiakas.SelectedRows[0].Cells["postinro"].Value.ToString();
            string email = this.dataGridAsiakas.SelectedRows[0].Cells["email"].Value.ToString();
            string puhelinnro = this.dataGridAsiakas.SelectedRows[0].Cells["puhelinnro"].Value.ToString();

            //Viedään tiedot "lisää asiakas" tauluun jossa sitä voidaan muokata
            new LisaaAsiakas(asiakasid, etunimi, sukunimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro).ShowDialog();

            //Kun muokkaus on valmis päivitetään lista
            LinkitaTietokanta();

        }
    }
}
