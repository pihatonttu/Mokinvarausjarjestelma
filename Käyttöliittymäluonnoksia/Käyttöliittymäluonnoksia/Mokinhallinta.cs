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
    public partial class Mokinhallinta : Form
    {
        public Mokinhallinta()
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
            string kysely = "SELECT *  FROM mökki";


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();

                if (dt.Rows.Count > 0)
                {
                    dataGridMokki.DataSource = dt;
                }
            }
        }

        private void PoistaTietue()
        {
            string mökkiid;
            if (dataGridMokki.SelectedRows.Count != 0)
            {
                mökkiid = this.dataGridMokki.SelectedRows[0].Cells["mökki_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM mökki WHERE mökki_id=" + mökkiid;

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }

                //Poistetaan rivi näkyvistä
                this.dataGridMokki.Rows.RemoveAt(this.dataGridMokki.SelectedRows[0].Index);
            }
        }

        private void Mokinhallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new LisaaMokki().ShowDialog();
            LinkitaTietokanta();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nimi = this.dataGridMokki.SelectedRows[0].Cells["nimi"].Value.ToString();
            string osoite = this.dataGridMokki.SelectedRows[0].Cells["osoite"].Value.ToString();
            int mökkiid = int.Parse(this.dataGridMokki.SelectedRows[0].Cells["mökki_id"].Value.ToString());
            string kuvaus = this.dataGridMokki.SelectedRows[0].Cells["kuvaus"].Value.ToString();
            int hinta = int.Parse(this.dataGridMokki.SelectedRows[0].Cells["hinta"].Value.ToString());
            new LisaaMokki(nimi, osoite, mökkiid, kuvaus, hinta).ShowDialog();
            LinkitaTietokanta();
        }
    }
}
