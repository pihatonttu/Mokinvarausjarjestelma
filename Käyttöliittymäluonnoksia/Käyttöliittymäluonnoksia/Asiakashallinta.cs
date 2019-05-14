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


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void PoistaTietue()
        {
            string asiakasid;
            if (dataGridView1.SelectedRows.Count != 0)
            {
                asiakasid = this.dataGridView1.SelectedRows[0].Cells["asiakas_id"].Value.ToString();

                //Tietueen poisto koodi
                string kysely = @"DELETE FROM asiakas WHERE asiakas_id=" + asiakasid;

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    yhteys.Close();
                }
            }
        }

        private void Asiakashallinta_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PoistaTietue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LisaaAsiakas().ShowDialog();
        }
    }
}
