using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Käyttöliittymäluonnoksia
{
    public partial class Seuranta: Form
    {
        string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
        DataTable listamokit = new DataTable();
        DataTable listapalvelut = new DataTable();

        public Seuranta()
        {
            InitializeComponent();
        }

        private void Seuranta_Load(object sender,EventArgs e)
        {
            // Linkitetään comboboxeihin tiedot tietokannasta
            mokkicombo.DataSource = LinkitaTietokanta("toimipiste");
            mokkicombo.ValueMember = "toimipiste_id";
            mokkicombo.DisplayMember = "nimi";

            palvelucombo.DataSource = LinkitaTietokanta("toimipiste");
            palvelucombo.ValueMember = "toimipiste_id";
            palvelucombo.DisplayMember = "nimi";
        }

        //Haetaan tietokannasta tekstiä
        private string Get_string(string table,string column)
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
            string kysely = "SELECT " + column + " FROM " + table;
            string txt = "";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txt = reader.GetString(0);
                }
                yhteys.Close();
                return txt;
            }
        }

        private DataTable LinkitaTietokanta(string taulu)
        {
            DataTable dt = new DataTable();

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = "SELECT * FROM " + taulu;

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }

        //Tarkistetaan päällekkäisyydet ja näytetään vapaat mökit
        private void button2_Click(object sender,EventArgs e)
        {
            datagridmok.DataSource = null;
            listamokit.Rows.Clear();

            string valinta = mokkicombo.SelectedValue.ToString();
            
            DateTime alkupvm = dtpalkumokki.Value;
            DateTime loppupvm = dtploppumokki.Value;

            //Haetaan tällä kaikki id:t mökki_varaus taulusta jotta voidaan vertailla niitä
            List<string> mokkienidt = new List<string>();
            string kysely = "SELECT mökki_id FROM mökki_varaus";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    mokkienidt.Add(reader["mökki_id"].ToString());
                }
                yhteys.Close();
            }

            //Käydään kaikki mökkivarauksien päivät läpi
            string vapaat = "";
            for (int i = 0; i < mokkienidt.Count; i++)
            {
                DateTime alkupvm2 = DateTime.Parse(Get_string("mökki_varaus WHERE mökki_id =" + mokkienidt[i], "alkamispäivämäärä"));
                if (alkupvm2 == null) {
                    break;
                }

                DateTime loppupvm2 = DateTime.Parse(Get_string("mökki_varaus WHERE mökki_id =" + mokkienidt[i],"loppumispäivämäärä"));

                //Tarkistetaan onko päällekkäisyyksiä
                bool solmussa = alkupvm < loppupvm2 && alkupvm2 > alkupvm;

                //Jos ei päällekkäisyyksiä niin lisätään se listaan
                if(!solmussa){
                    if (vapaat == "") { vapaat = mokkienidt[i]; } else { vapaat += ","+mokkienidt[i]; }
                }
            }
            //viedään vapaat mökit toiseen funktioon
            haeVapaatMokit(vapaat);
        }

        //Haetaan vapaiden mökkien tiedot
        private void haeVapaatMokit(string vapaat)
        {

            if (vapaat != "")
            {
                string kysely = "SELECT * FROM mökki WHERE mökki_id IN (" + vapaat + ")";

                using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                {
                    MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                    yhteys.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listamokit.Load(reader);
                    yhteys.Close();
                }
                datagridmok.DataSource = listamokit;
            }
        }

        //Haetaan vapaat palvelut
        private void haeVapaatPalvelut(string vapaat)
        {         
            listapalvelut.Rows.Clear();
            dataGridpalvelut.DataSource = null;

            if (vapaat != ""){

            string kysely = "SELECT * FROM palvelu WHERE palvelu_id IN (" + vapaat + ")";

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                listapalvelut.Load(reader);
                yhteys.Close();
            }
            dataGridpalvelut.DataSource = listapalvelut;
            }
        }

        //Haetaan kaikki vapaat palvelut tietyille päiville
        private void button1_Click(object sender,EventArgs e)
        {
            string valinta = palvelucombo.SelectedValue.ToString();

            DateTime alkupvm = dtpalkupalvelu.Value;
            DateTime loppupvm = dtploppupalvelu.Value;

            //Haetaan tällä kaikki id:t mökki_varaus taulusta jotta voidaan vertailla niitä
            List<string> palveluidt = new List<string>();
            string kysely = "SELECT palvelu_id FROM varauksen_palvelut";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely,yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    palveluidt.Add(reader["palvelu_id"].ToString());
                }
                yhteys.Close();
            }

            //Käydään kaikki mökkivarauksien päivät läpi
            string vapaat = "";
            for (int i = 0; i < palveluidt.Count; i++)
            {
                DateTime alkupvm2 = DateTime.Parse(Get_string("varauksen_palvelut WHERE palvelu_id =" + palveluidt[i],"alkamispvmäärä"));
                DateTime loppupvm2 = DateTime.Parse(Get_string("varauksen_palvelut WHERE palvelu_id =" + palveluidt[i],"loppumispvmäärä"));

                //Tarkistetaan onko päällekkäisyyksiä
                bool solmussa = alkupvm < loppupvm2 && alkupvm2 < alkupvm;

                //Jos ei päällekkäisyyksiä niin lisätään se listaan
                if (!solmussa)
                {
                    if (vapaat == "") { vapaat = palveluidt[i]; } else { vapaat += "," + palveluidt[i]; }
                }
            }
            //viedään vapaat mökit toiseen funktioon
            haeVapaatPalvelut(vapaat);
        }
    }
}
