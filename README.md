# Mokki VuokrausJärjestelmä

Kouluprojekti jossa on tarkoitus tehdä mökeille varausjärjestelmä, joka sisältää tietojen hallinnan ja laskutuksen.

phpmyadmin 212.149.169.90/phpmyadmin
           85.23.149.196/phpmyadmin
käyttäjä: admin
salasana: admin123

Ryhmän jäsenet:
 - Samu Miettinen
 - Mikko Haikonen
 - Juha-Pekka Korhonen
 - Henri Mönkkönen


### TODO:
 - [x] Lisää mökkki varaus
 - [ ] Lisää palvelu varaus MÖNÖ
 
 - [ ] Poista kaikki suodatukset JUHIS

 - [ ] Laskut taulu id:t toimintaan SAMU
 - [ ] Asiakas taulu muokkaus toiminto
 - [x] mökin muokkaus toiminto
 - [ ] Varoitus kun poistaa isäntäkenttiä esim. Toimipisteissä
 - [ ] ulkoasut vastaaviksi
           datagrid 
           editmode: editProgrammably
           allowuseredit: false
           allowuserdelete: false
           allowuserorder: true   
           size: 819, 622
 
 Jos aikaa
 - [ ] Tietojen tarkastukset

## USER CASE:
-----------
##### Tilanne:

Asiakas haluaa mökin viikoksi ja lisäksi vuokrata sukset 2 päiväksi.

##### Ongelma:

- Alku ja loppu päivämäärä ei voi olla sama(varaus taulussa)

##### Korjaus:
Päivämäärät liitos taulukkoihin joilla saadaan eroteltua kaikkia päivät
--------
