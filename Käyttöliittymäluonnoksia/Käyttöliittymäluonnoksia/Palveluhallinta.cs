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
using System.Diagnostics;
using System.Threading;

namespace Käyttöliittymäluonnoksia
{
    
    public partial class Palveluhallinta : Form
    {

        //Mysql serverin tiedot
        string yhteysteksti = @"server= 85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
        DataTable dt = new DataTable();

        public Palveluhallinta()
        {
            InitializeComponent();
        }

        //Kun formi aukeaa päivitetään lista
        private void Palveluhallinta_Load(object sender, EventArgs e)
        {
            PaivitaLista();
        }

        //Haetaan tieto ja linkitetään se Datagridiin
        private void PaivitaLista()
        {
            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = "SELECT *  FROM palvelu";

            using ( MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();
            }
            if (dt.Rows.Count > 0)
            {
                

                if (dataGridPalvelu.InvokeRequired)
                {
                    dataGridPalvelu.Invoke(new MethodInvoker(delegate { dataGridPalvelu.DataSource = null; dataGridPalvelu.DataSource = dt; }));
                    
                } else
                {
                    dataGridPalvelu.DataSource = null;
                    dataGridPalvelu.DataSource = dt;
                }
            }

        }

        //Poistetaan tietue
        private void PoistaTietue()
        {
            string palveluid;
            if (dataGridPalvelu.SelectedRows.Count != 0)
            {
                palveluid = this.dataGridPalvelu.SelectedRows[0].Cells["palvelu_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM palvelu WHERE palvelu_id=" + palveluid;

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }
                //Poistetaan rivi näkyvistä
                this.dataGridPalvelu.Rows.RemoveAt(this.dataGridPalvelu.SelectedRows[0].Index);
            }   
        }

        //Tietojen muokkaus
        private void MuokkaaTietue()
        {
            //kerätään tiedot
            string palveluid = this.dataGridPalvelu.SelectedRows[0].Cells["palvelu_id"].Value.ToString();
            string toimipiste_id = this.dataGridPalvelu.SelectedRows[0].Cells["toimipiste_id"].Value.ToString();
            string nimi = this.dataGridPalvelu.SelectedRows[0].Cells["nimi"].Value.ToString();
            string kuvaus = this.dataGridPalvelu.SelectedRows[0].Cells["kuvaus"].Value.ToString();
            string hinta = this.dataGridPalvelu.SelectedRows[0].Cells["hinta"].Value.ToString();
            string alv = this.dataGridPalvelu.SelectedRows[0].Cells["alv"].Value.ToString();
            //Viedään ne toiseen formiin
            new PalveluLisaaTietue(palveluid, toimipiste_id, nimi,kuvaus,hinta,alv).ShowDialog();
            //Kun palataan niin päivitetään lista
            PaivitaLista();
        }

        //Lisää nappi
        private void button1_Click(object sender, EventArgs e)
        {
            new PalveluLisaaTietue().ShowDialog();
            PaivitaLista();
        }

        //Poistonappi
        private void button2_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        //Muokkaa nappi
        private void button3_Click(object sender, EventArgs e)
        {
            MuokkaaTietue();
        }
    }
}
