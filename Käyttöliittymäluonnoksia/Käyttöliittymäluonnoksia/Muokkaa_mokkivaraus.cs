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

namespace Käyttöliittymäluonnoksia {
    public partial class Muokkaa_mokkivaraus : Form {

        int lkm;
        DateTime alku;
        DateTime loppu;
        int id;

        public Muokkaa_mokkivaraus(int lkm, DateTime alku, DateTime loppu, int id)
        {
            InitializeComponent();
            this.lkm = lkm;
            this.alku = alku;
            this.loppu = loppu;
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yhteysteksti = @"server= 85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            string pvm1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string pvm2 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string kysely = "UPDATE mökki_varaus SET lkm = '"+int.Parse(numericUpDown1.Value.ToString())+"', alkamispäivämäärä = '"+ pvm1 +"', " +
                            "loppumispäivämäärä = '"+ pvm2 +"' WHERE varaus_id = '"+id+"'";

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                yhteys.Close();
            }
            this.Close();
        }

        private void Muokkaa_mokkivaraus_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = lkm;
            dateTimePicker1.Value = alku;
            dateTimePicker2.Value = loppu;
        }
    }
}
