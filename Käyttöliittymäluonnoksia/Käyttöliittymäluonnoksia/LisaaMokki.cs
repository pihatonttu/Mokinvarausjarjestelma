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
    public partial class LisaaMokki : Form
    {
        public LisaaMokki()
        {
            InitializeComponent();
        }


        //Haetaan tieto ja linkitetään se Datagridiin
        private void LinkitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Mysql serverin tiedot
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = "SELECT *  FROM asiakas";


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
//dataGridView1.DataSource = dt;
                }
            }
        }

        private void LisaaMokki_Load(object sender, EventArgs e)
        {
            LinkitaTietokanta();
        }
    }
}
