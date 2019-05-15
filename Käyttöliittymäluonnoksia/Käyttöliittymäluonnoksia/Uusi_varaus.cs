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
using MySql.Data.MySqlClient;

namespace Käyttöliittymäluonnoksia
{
    public partial class Uusi_varaus : Form
    {
        public Uusi_varaus()
        {
            InitializeComponent();
        }

        private void Uusi_varaus_Load(object sender, EventArgs e)
        {
            // Linkitetään comboboxeihin tiedot tietokannasta
            DataTable table = LinkitaTietokanta("asiakas");
            table.Columns.Add("nimi", typeof(string), "etunimi + ' ' + sukunimi");
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "asiakas_id";
            comboBox1.DisplayMember = "nimi";

            comboBox2.DataSource = LinkitaTietokanta("toimipiste");
            comboBox2.ValueMember = "toimipiste_id";
            comboBox2.DisplayMember = "nimi";

            comboBox3.DataSource = LinkitaTietokanta("mökki");
            comboBox3.ValueMember = "mökki_id";
            comboBox3.DisplayMember = "nimi";
        }

        private DataTable LinkitaTietokanta(string taulu)
        {
            DataTable dt = new DataTable();

            //Mysql serverin tiedot
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = "SELECT * FROM " + taulu;

            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Asetetaan asiakkaan tiedot
            int id = int.Parse(comboBox1.SelectedValue.ToString());
            label1.Text = Get_string("asiakas", "etunimi", id);
            label2.Text = Get_string("asiakas", "sukunimi", id);
            label3.Text = Get_string("asiakas", "lahiosoite", id);
            label4.Text = Get_string("asiakas", "email", id);
            label5.Text = Get_string("asiakas", "puhelinnro", id);

            // Asetetaan varauksen tiedot
            label10.Text = Get_string("toimipiste", "nimi", int.Parse(comboBox2.SelectedValue.ToString()));
            label9.Text = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            label8.Text = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            label16.Text = numericUpDown1.Value.ToString();

            // Asetetaan mökin tiedot
            id = int.Parse(comboBox3.SelectedValue.ToString());
            label11.Text = Get_string("mökki", "nimi", id);
            label12.Text = Get_string("mökki", "osoite", id);
            label13.Text = Get_string("mökki", "hinta", id);

            button2.Enabled = true;
        }

        //Haetaan tietokannasta tekstiä jossa id täsmää
        private string Get_string(string table, string column, int id)
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
            string kysely = "SELECT " + column + " FROM " + table + " WHERE " + table + "_id = " + id;
            string txt = "";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    txt = reader.GetString(0);
                }
                yhteys.Close();
                return txt;
            }
        }

        //Haetaan tietokannasta tekstiä
        private string Get_string(string table, string column)
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
            string kysely = "SELECT " + column + " FROM " + table;
            string txt = "";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    txt = reader.GetString(0);
                }
                yhteys.Close();
                return txt;
            }
        }

        private void LisaaTietoja(string kysely)
        {
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti)) {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                yhteys.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string asiakas_id = comboBox1.SelectedValue.ToString();
            string toimipiste_id = comboBox2.SelectedValue.ToString();
            string varattu_pvm = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string mökki_id = comboBox3.SelectedValue.ToString();
            string lkm = numericUpDown1.Value.ToString();
            string alkamispvm = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string loppumispvm = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string kysely1 = @"INSERT INTO varaus (asiakas_id, toimipiste_id, varattu_pvm)
                               VALUES ('" + asiakas_id + "', '" + toimipiste_id + "', '" + varattu_pvm + "')";

            LisaaTietoja(kysely1);

            string varaus_id = Get_string("varaus", "MAX(varaus_id)");

            string kysely2 = @"INSERT INTO mökki_varaus (varaus_id, mökki_id, lkm, alkamispäivämäärä, loppumispäivämäärä)
                               VALUES ('" + varaus_id + "', '" + mökki_id + "', '" + lkm + "', '" + alkamispvm + "', '" + loppumispvm + "')";
            
            LisaaTietoja(kysely2);

            //Laskun tekeminen
            double mokinhinta = double.Parse(Get_string("mökki WHERE mökki_id = " + comboBox3.SelectedValue.ToString(),"hinta"));
            double alv = 24;
            string kysely3;

            //Tarkistetaan onko jo jotain laskua tälle varaukselle kuten palvelua
            string onkojojotain = Get_string("lasku WHERE varaus_id = "+varaus_id,"varaus_id");
            if (onkojojotain != "")
            {
                Debug.WriteLine(Get_string("lasku WHERE varaus_id =" + varaus_id,"summa"));
                double edsumma = double.Parse(Get_string("lasku WHERE varaus_id ="+varaus_id,"summa"));
                mokinhinta += edsumma;  //Jos on niin lisätään se summaan
                kysely3 = @"UPDATE lasku SET summa='" + mokinhinta +"' WHERE varaus_id='" + varaus_id + "';";
            }
            else{
                //Jos edellistä ei löydetty luodaan uusi lasku
                kysely3 = "INSERT INTO lasku (varaus_id, asiakas_id, summa, alv) " +
                 "VALUES ('" + varaus_id + "','" + asiakas_id + "','" + mokinhinta + "','" + alv + "')";
            }
            
            //Lähetetään kysely serverille
            LisaaTietoja(kysely3);

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new LisaaAsiakas().ShowDialog();
            DataTable table = LinkitaTietokanta("asiakas");
            table.Columns.Add("nimi", typeof(string), "etunimi + ' ' + sukunimi");
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "asiakas_id";
            comboBox1.DisplayMember = "nimi";
        }
    }
}
