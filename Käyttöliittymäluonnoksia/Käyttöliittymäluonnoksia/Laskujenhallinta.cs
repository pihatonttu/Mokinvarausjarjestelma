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
    public partial class Laskujenhallinta : Form
    {
        public Laskujenhallinta()
        {
            InitializeComponent();
        }
        //Mysql serverin tiedot
        string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

        //Haetaan tieto ja linkitetään se Datagridiin
        private void LinkitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Luodaan kysely jolla saadaan tarvittava tieto tietokannasta
            string kysely = @"SELECT mökki.nimi, mökki.osoite, asiakas.etunimi, asiakas.sukunimi, asiakas.lahiosoite, asiakas.postitoimipaikka, asiakas.postinro, lasku.summa, lasku.alv, lasku.Maksettu
                              FROM lasku
                              INNER JOIN asiakas ON lasku.asiakas_id = asiakas.asiakas_id
                              INNER JOIN mökki_varaus ON lasku.varaus_id = mökki_varaus.varaus_id
                              INNER JOIN mökki ON mökki_varaus.mökki_id = mökki.mökki_id";

            //Lähetään kysely serverille
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                //Näytetään tieto jos sitä löytyy
                if (dt.Rows.Count > 0)
                {
                    dataGridLasku.DataSource = dt;
                }
            }
        }

        //Poista funktio
        private void PoistaTietue()
        {
            string laskuid;

            //Tarkistetaan että jotain on valittu
            if (dataGridLasku.SelectedRows.Count != 0)
            {
                laskuid = this.dataGridLasku.SelectedRows[0].Cells["lasku_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM lasku WHERE lasku_id=" + laskuid;

                //Lähetetään kysely serverille
                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                }
                //Poistetaan rivi näkyvistä
                this.dataGridLasku.Rows.RemoveAt(this.dataGridLasku.SelectedRows[0].Index);
            }
        }

        //Poista nappi
        private void poistabtn_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        //Kun formi avataan
        private void Laskujenhallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }
    }
}
