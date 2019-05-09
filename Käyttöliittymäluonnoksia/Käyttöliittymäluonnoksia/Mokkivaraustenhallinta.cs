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
            Disable();
        }

        private void Mokkivaraustenhallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void LinkitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Mysql serverin tiedot
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = @"SELECT mökki.mökki_id, mökki.nimi, mökki.osoite, mökki.kuvaus, mökki_varaus.lkm, mökki_varaus.alkamispäivämäärä, mökki_varaus.loppumispäivämäärä
                              FROM mökki
                              RIGHT JOIN mökki_varaus ON mökki.mökki_id = mökki_varaus.mökki_id";


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    dataGridVaraus.DataSource = dt;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) {
                Disable();
            }
            else {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                button4.Enabled = true;
                label2.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
            }
        }

        private void Disable()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            button4.Enabled = false;
            label2.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
        }

        private void Lisaa_tietue() {
            string kysely = @"INSERT INTO `mökki` (`nimi`, `osoite`, `mökki_id`, `kuvaus`) 
                            VALUES('mökki1', 'opistotie', '1', 'Tämä on hyvä mökki')";
        }
    }
}
