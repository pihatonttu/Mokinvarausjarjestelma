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
    public partial class Mokkivaraustenhallinta : Form
    {
        public Mokkivaraustenhallinta()
        {
            InitializeComponent();
        }

        private void Mokkivaraustenhallinta_Load(object sender, EventArgs e)
        {
            PaivitaTietokanta();
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void PaivitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Mysql serverin tiedot
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = @"SELECT varaus.varaus_id, mökki.mökki_id, mökki.nimi, mökki.osoite, mökki.hinta, mökki.kuvaus, mökki_varaus.lkm, 
                              mökki_varaus.alkamispäivämäärä, mökki_varaus.loppumispäivämäärä, asiakas.etunimi, asiakas.sukunimi, varaus.varattu_pvm
                              FROM mökki
                              INNER JOIN mökki_varaus ON mökki.mökki_id = mökki_varaus.mökki_id
                              INNER JOIN varaus ON mökki_varaus.varaus_id = varaus.varaus_id
                              INNER JOIN asiakas ON varaus.asiakas_id = asiakas.asiakas_id";

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    dataGridVaraus.DataSource = null;
                    dataGridVaraus.DataSource = dt;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lkm = int.Parse(this.dataGridVaraus.SelectedRows[0].Cells["lkm"].Value.ToString());
            DateTime alku = DateTime.Parse(this.dataGridVaraus.SelectedRows[0].Cells["alkamispäivämäärä"].Value.ToString());
            DateTime loppu = DateTime.Parse(this.dataGridVaraus.SelectedRows[0].Cells["loppumispäivämäärä"].Value.ToString());
            int id = int.Parse(this.dataGridVaraus.SelectedRows[0].Cells["varaus_id"].Value.ToString());

            // Avataan uusi ikkuna, jonne viedään muuttujia parametreinä
            new Muokkaa_mokkivaraus(lkm, alku, loppu, id).ShowDialog();
            // Kun ikkuna suljetaan, päivitetään datagridview
            PaivitaTietokanta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Uusi_varaus().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        private void PoistaTietue()
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
            string varausid;

            if (dataGridVaraus.SelectedRows.Count != 0) {
                varausid = this.dataGridVaraus.SelectedRows[0].Cells["varaus_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM varaus WHERE varaus_id=" + varausid;

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }

                this.dataGridVaraus.Rows.RemoveAt(this.dataGridVaraus.SelectedRows[0].Index);
            }
        }
    }
}
