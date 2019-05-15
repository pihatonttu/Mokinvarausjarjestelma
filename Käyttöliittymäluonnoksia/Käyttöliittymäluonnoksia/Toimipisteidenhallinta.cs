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
    public partial class Toimipisteidenhallinta : Form
    {
        public Toimipisteidenhallinta()
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
            string kysely = "SELECT * FROM toimipiste";


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();

                if (dt.Rows.Count > 0)
                {
                    dataGridToimipiste.DataSource = null;
                    dataGridToimipiste.DataSource = dt;
                }
            }
        }
        private void PoistaTietue()
        {
            string toimipisteid;
            if (dataGridToimipiste.SelectedRows.Count != 0)
            {
                toimipisteid = this.dataGridToimipiste.SelectedRows[0].Cells["toimipiste_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM toimipiste WHERE toimipiste_id=" + toimipisteid;

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                }

                //Poistetaan rivi näkyvistä
                this.dataGridToimipiste.Rows.RemoveAt(this.dataGridToimipiste.SelectedRows[0].Index);
            }
        }

        private void Toimipisteidenhallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }

        private void lisääbtn_Click(object sender, EventArgs e)
        {
            new Lisaatoimipiste().ShowDialog();
            LinkitaTietokanta();
        }

        private void poistabtn_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        //Muokkaa nappi
        private void muokkaabtn_Click(object sender, EventArgs e)
        {
            //Otetaan tiedot talteen
            int toimipisteid = int.Parse(this.dataGridToimipiste.SelectedRows[0].Cells["toimipiste_id"].Value.ToString());
            string nimi = this.dataGridToimipiste.SelectedRows[0].Cells["nimi"].Value.ToString();
            string lahiosoite = this.dataGridToimipiste.SelectedRows[0].Cells["lahiosoite"].Value.ToString();
            string postitoimipaikka = this.dataGridToimipiste.SelectedRows[0].Cells["postitoimipaikka"].Value.ToString();
            string postinro = this.dataGridToimipiste.SelectedRows[0].Cells["postinro"].Value.ToString();
            string email = this.dataGridToimipiste.SelectedRows[0].Cells["email"].Value.ToString();
            string puhelinnro = this.dataGridToimipiste.SelectedRows[0].Cells["puhelinnro"].Value.ToString();

            //Viedään ne Lisää ikkunaan
            new Lisaatoimipiste(toimipisteid, nimi, lahiosoite, postitoimipaikka, postinro, email, puhelinnro).ShowDialog();

            //Päivitetään sen jälkeen lista
            LinkitaTietokanta();
        }
    }
}
