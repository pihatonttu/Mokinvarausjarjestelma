using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System.Net.Mail;


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
            string kysely = @"SELECT lasku.lasku_id, mökki.nimi, mökki.hinta, palvelu.nimi, palvelu.hinta, asiakas.etunimi, asiakas.sukunimi, asiakas.lahiosoite, asiakas.postitoimipaikka, asiakas.postinro, asiakas.email, lasku.summa, lasku.alv, lasku.Maksettu
                              FROM lasku
                              INNER JOIN asiakas ON lasku.asiakas_id = asiakas.asiakas_id
                              INNER JOIN mökki_varaus ON lasku.varaus_id = mökki_varaus.varaus_id
                              INNER JOIN mökki ON mökki_varaus.mökki_id = mökki.mökki_id
                              INNER JOIN varaus ON lasku.varaus_id = varaus.varaus_id
                              INNER JOIN varauksen_palvelut ON varaus.varaus_id = varauksen_palvelut.varaus_id
                              INNER JOIN palvelu ON varauksen_palvelut.palvelu_id = palvelu.palvelu_id";

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

        private void Paperilasku()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter="PDF file|*.pdf", ValidateNames = true }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(Get_laskuntiedot()));
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    finally {
                        doc.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paperilasku();
        }

        private void Spostilasku()
        {
            // Testaamiseksi pitää syöttää oman sähköpostin tiedot ja vastaanottaja nuolella merkityille riveille
            try {
                MailMessage viesti = new MailMessage("laskutus@villagepeople.com", "vastaanottaja@esim.com"); // <--
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("käyttäjänimi", "salasana"); // <--
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Host = "smtp-serveri"; // <--
                viesti.Subject = "Lasku#" + this.dataGridLasku.SelectedRows[0].Cells["lasku_id"].Value.ToString();
                viesti.Body = Get_laskuntiedot();
                client.Send(viesti);
                MessageBox.Show("Viesti lähetetty!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\nTarkista lähettäjän tiedot koodista.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Spostilasku();
        }

        private string Get_laskuntiedot()
        {
            string tiedot = "Tilaaja: " + this.dataGridLasku.SelectedRows[0].Cells["etunimi"].Value.ToString() + " " + this.dataGridLasku.SelectedRows[0].Cells["sukunimi"].Value.ToString();
            tiedot += "\nMökki: " + this.dataGridLasku.SelectedRows[0].Cells["nimi"].Value.ToString();
            tiedot += "\nMökin hinta: " + this.dataGridLasku.SelectedRows[0].Cells["hinta"].Value.ToString();
            tiedot += "\nPalvelu: " + this.dataGridLasku.SelectedRows[0].Cells["nimi1"].Value.ToString();
            tiedot += "\nPalvelun hinta: " + this.dataGridLasku.SelectedRows[0].Cells["hinta1"].Value.ToString();
            tiedot += "\nAlv: " + this.dataGridLasku.SelectedRows[0].Cells["alv"].Value.ToString();
            tiedot += "\nLaskun summa(alv:in kanssa): " + this.dataGridLasku.SelectedRows[0].Cells["summa"].Value.ToString();
            return tiedot;
        }
    }
}
