-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: 03.04.2019 klo 03:44
-- Palvelimen versio: 5.6.42
-- PHP Version: 5.6.39

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vp`
--

-- --------------------------------------------------------

--
-- Rakenne taululle `asiakas`
--

CREATE TABLE `asiakas` (
  `asiakas_id` int(11) NOT NULL,
  `etunimi` varchar(20) DEFAULT NULL,
  `sukunimi` varchar(40) DEFAULT NULL,
  `lahiosoite` varchar(40) DEFAULT NULL,
  `postitoimipaikka` varchar(30) DEFAULT NULL,
  `postinro` char(5) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `puhelinnro` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `asiakas`
--

INSERT INTO `asiakas` (`asiakas_id`, `etunimi`, `sukunimi`, `lahiosoite`, `postitoimipaikka`, `postinro`, `email`, `puhelinnro`) VALUES
(1, 'Matti', 'Meikäläinen', 'Katu 5', 'Kuopio', '70200', 'testi@hotmail.com', '05011111111');

-- --------------------------------------------------------

--
-- Rakenne taululle `lasku`
--

CREATE TABLE `lasku` (
  `lasku_id` int(11) NOT NULL,
  `varaus_id` int(11) DEFAULT NULL,
  `asiakas_id` int(11) DEFAULT NULL,
  `nimi` varchar(60) DEFAULT NULL,
  `lahiosoite` varchar(40) DEFAULT NULL,
  `postitoimipaikka` varchar(30) DEFAULT NULL,
  `postinro` char(5) DEFAULT NULL,
  `summa` double(8,2) NOT NULL,
  `alv` double(8,2) NOT NULL,
  `Maksettu` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `lasku`
--

INSERT INTO `lasku` (`lasku_id`, `varaus_id`, `asiakas_id`, `nimi`, `lahiosoite`, `postitoimipaikka`, `postinro`, `summa`, `alv`, `Maksettu`) VALUES
(1, 1, 1, 'Testi', 'testikatu', 'kuopio', '93248', 1000.00, 24.00, 1);

-- --------------------------------------------------------

--
-- Rakenne taululle `palvelu`
--

CREATE TABLE `palvelu` (
  `palvelu_id` int(11) NOT NULL,
  `toimipiste_id` int(11) DEFAULT NULL,
  `nimi` varchar(40) DEFAULT NULL,
  `tyyppi` int(11) DEFAULT NULL,
  `kuvaus` varchar(255) DEFAULT NULL,
  `hinta` double(8,2) NOT NULL,
  `alv` double(8,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `palvelu`
--

INSERT INTO `palvelu` (`palvelu_id`, `toimipiste_id`, `nimi`, `tyyppi`, `kuvaus`, `hinta`, `alv`) VALUES
(1, 1, 'Testipalvelu', 1, 'Testi', 1000.00, 24.00);

-- --------------------------------------------------------

--
-- Rakenne taululle `palvelu_tyypit`
--

CREATE TABLE `palvelu_tyypit` (
  `tyyppiID` int(11) NOT NULL,
  `mökki` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `palvelu_tyypit`
--

INSERT INTO `palvelu_tyypit` (`tyyppiID`, `mökki`) VALUES
(1, 'Testimökki');

-- --------------------------------------------------------

--
-- Rakenne taululle `toimipiste`
--

CREATE TABLE `toimipiste` (
  `toimipiste_id` int(11) NOT NULL,
  `nimi` varchar(40) DEFAULT NULL,
  `lahiosoite` varchar(40) DEFAULT NULL,
  `postitoimipaikka` varchar(30) DEFAULT NULL,
  `postinro` char(5) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `puhelinnro` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `toimipiste`
--

INSERT INTO `toimipiste` (`toimipiste_id`, `nimi`, `lahiosoite`, `postitoimipaikka`, `postinro`, `email`, `puhelinnro`) VALUES
(1, 'Tahko', 'Tahkotie', 'Kuopio', '72346', 'testi@tahko.com', '040543857');

-- --------------------------------------------------------

--
-- Rakenne taululle `varauksen_palvelut`
--

CREATE TABLE `varauksen_palvelut` (
  `varaus_id` int(11) NOT NULL DEFAULT '0',
  `palvelu_id` int(11) NOT NULL DEFAULT '0',
  `lkm` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `varauksen_palvelut`
--

INSERT INTO `varauksen_palvelut` (`varaus_id`, `palvelu_id`, `lkm`) VALUES
(1, 1, 6);

-- --------------------------------------------------------

--
-- Rakenne taululle `varaus`
--

CREATE TABLE `varaus` (
  `varaus_id` int(11) NOT NULL,
  `asiakas_id` int(11) DEFAULT NULL,
  `toimipiste_id` int(11) DEFAULT NULL,
  `varattu_pvm` datetime DEFAULT NULL,
  `vahvistus_pvm` datetime DEFAULT NULL,
  `varattu_alkupvm` datetime DEFAULT NULL,
  `varattu_loppupvm` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vedos taulusta `varaus`
--

INSERT INTO `varaus` (`varaus_id`, `asiakas_id`, `toimipiste_id`, `varattu_pvm`, `vahvistus_pvm`, `varattu_alkupvm`, `varattu_loppupvm`) VALUES
(1, 1, 1, '2019-04-03 00:00:00', '2019-04-04 00:00:00', '2019-04-07 00:00:00', '2019-04-13 00:00:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `asiakas`
--
ALTER TABLE `asiakas`
  ADD PRIMARY KEY (`asiakas_id`),
  ADD KEY `Asiakas_sukunimi_index` (`sukunimi`),
  ADD KEY `Asiakas_etunimi_index` (`etunimi`);

--
-- Indexes for table `lasku`
--
ALTER TABLE `lasku`
  ADD PRIMARY KEY (`lasku_id`),
  ADD UNIQUE KEY `Lasku_varaus_id_index` (`varaus_id`),
  ADD KEY `Lasku_nimi_index` (`nimi`),
  ADD KEY `Lasku_asiakas_id_index` (`asiakas_id`);

--
-- Indexes for table `palvelu`
--
ALTER TABLE `palvelu`
  ADD PRIMARY KEY (`palvelu_id`),
  ADD KEY `Palvelu_nimi_index` (`nimi`),
  ADD KEY `palvelu_toimipiste_id_index` (`toimipiste_id`),
  ADD KEY `tyyppi_liitos` (`tyyppi`);

--
-- Indexes for table `palvelu_tyypit`
--
ALTER TABLE `palvelu_tyypit`
  ADD PRIMARY KEY (`tyyppiID`);

--
-- Indexes for table `toimipiste`
--
ALTER TABLE `toimipiste`
  ADD PRIMARY KEY (`toimipiste_id`),
  ADD KEY `Toimipiste_nimi_index` (`nimi`);

--
-- Indexes for table `varauksen_palvelut`
--
ALTER TABLE `varauksen_palvelut`
  ADD PRIMARY KEY (`palvelu_id`,`varaus_id`),
  ADD KEY `vp_varaus_id_index` (`varaus_id`),
  ADD KEY `vp_palvelu_id_index` (`palvelu_id`);

--
-- Indexes for table `varaus`
--
ALTER TABLE `varaus`
  ADD PRIMARY KEY (`varaus_id`),
  ADD KEY `varaus_toimipiste_id_index` (`toimipiste_id`),
  ADD KEY `varaus_asiakas_id_index` (`asiakas_id`);

--
-- Rajoitteet vedostauluille
--

--
-- Rajoitteet taululle `lasku`
--
ALTER TABLE `lasku`
  ADD CONSTRAINT `lasku_ibfk_1` FOREIGN KEY (`varaus_id`) REFERENCES `varaus` (`varaus_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `lasku_ibfk_2` FOREIGN KEY (`asiakas_id`) REFERENCES `asiakas` (`asiakas_id`) ON DELETE CASCADE;

--
-- Rajoitteet taululle `palvelu`
--
ALTER TABLE `palvelu`
  ADD CONSTRAINT `palvelu_ibfk_1` FOREIGN KEY (`toimipiste_id`) REFERENCES `toimipiste` (`toimipiste_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `tyyppi_liitos` FOREIGN KEY (`tyyppi`) REFERENCES `palvelu_tyypit` (`tyyppiID`);

--
-- Rajoitteet taululle `varauksen_palvelut`
--
ALTER TABLE `varauksen_palvelut`
  ADD CONSTRAINT `varauksen_palvelut_ibfk_1` FOREIGN KEY (`varaus_id`) REFERENCES `varaus` (`varaus_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `varauksen_palvelut_ibfk_2` FOREIGN KEY (`palvelu_id`) REFERENCES `palvelu` (`palvelu_id`) ON DELETE CASCADE;

--
-- Rajoitteet taululle `varaus`
--
ALTER TABLE `varaus`
  ADD CONSTRAINT `varaus_ibfk_1` FOREIGN KEY (`toimipiste_id`) REFERENCES `toimipiste` (`toimipiste_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `varaus_ibfk_2` FOREIGN KEY (`asiakas_id`) REFERENCES `asiakas` (`asiakas_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
