# Mokki VuokrausJärjestelmä

Kouluprojekti jossa on tarkoitus tehdä mökeille varausjärjestelmä, joka sisältää tietojen hallinnan ja laskutuksen.

phpmyadmin 212.149.169.90/phpmyadmin
käyttäjä: admin
salasana: admin123

Ryhmän jäsenet:
 - Samu Miettinen
 - Mikko Haikonen
 - Juha-Pekka Korhonen
 - Henri Mönkkönen


### TODO JUHIS:
 - [x] Tietokanta korjaukset:
   - [x] Hajota mökki irti palveluista
   - [x] Välitystaulu mökille ja varaukselle (2primaryy ja lkm)
   - [x] poista palvelutaulusta lkm kenttä
   - [x] Tyyppi taulusta poista mökki ja lisää Nimi + Kuvaus
   - [ ] Mökille tyypin tilalle kuvaus
   - [ ] Palvelulle päivämäärä liitostauluun? selvitys opelta
   - [ ] Mökkiliitos tauluun alku ja loppu pvm
   - [ ] varaus taulusta ylimääräiset päivämäärät pois

### TODO MIKKO:
  - [ ] Vaatimusmäärittely
  - [x] Viikkoraportti 14
  - [x] Projektikortti
  - [x] Viikkoraportti 15
  - [ ] Viesti opelle
  
### TODO HENRI:
  - [x] Palveluhallinta käyttöliittymä
  - [ ] Mökkihallinta toiminnallisuus + käyttöliittymä

### TODO SAMU:
  - [ ] Toimipisteidenhallinta
  - [x] serveri pystyssä


## USER CASE:
-----------
##### Tilanne:

Asiakas haluaa mökin viikoksi ja lisäksi vuokrata sukset 2 päiväksi.

##### Ongelma:

- Alku ja loppu päivämäärä ei voi olla sama(varaus taulussa)

##### Korjaus:
Päivämäärät liitos taulukkoihin joilla saadaan eroteltua kaikkia päivät
--------
