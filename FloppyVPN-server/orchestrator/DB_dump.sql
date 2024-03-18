-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: x.x.x.x    Database: floppyvpn_db
-- ------------------------------------------------------
-- Server version	8.0.22-13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '50affa9b-dad1-11ee-8d98-525400123456:1-1067';

--
-- Table structure for table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accounts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(24) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `when_registered` datetime NOT NULL,
  `paid_till` datetime NOT NULL,
  `days_left` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `accounts_UN` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='It is what it is.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accounts`
--

LOCK TABLES `accounts` WRITE;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aliases`
--

DROP TABLE IF EXISTS `aliases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aliases` (
  `alias` char(24) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `login` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  UNIQUE KEY `payment_aliases_UN` (`alias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Used to anonymize payments shared with friends and etc by aliasing the login or another identity fingerprint.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aliases`
--

LOCK TABLES `aliases` WRITE;
/*!40000 ALTER TABLE `aliases` DISABLE KEYS */;
/*!40000 ALTER TABLE `aliases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencies`
--

DROP TABLE IF EXISTS `currencies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `currencies` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `enabled` tinyint(1) NOT NULL DEFAULT '0',
  `payment_service` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'What service to use to process payments of this currency',
  `currency_code` varchar(8) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `currency_name` varchar(24) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `month_cost` double NOT NULL,
  `minimum_sum` double NOT NULL COMMENT 'The minimal total sum that can be paid in this currency',
  `icon` varchar(100) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '/imgs/currencies/default.png',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Prices per month in each currency and their codes, names and payment processors.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currencies`
--

LOCK TABLES `currencies` WRITE;
/*!40000 ALTER TABLE `currencies` DISABLE KEYS */;
INSERT INTO `currencies` VALUES (1,1,'nowpayments','xmr','Monero',4,0.04,'/imgs/currencies/default.png'),(2,0,'lava','rub','Russian Ruble',520,500,'/imgs/currencies/default.png'),(3,1,'nowpayments','btc','Bitcoin',0.000012,6,'/imgs/currencies/default.png');
/*!40000 ALTER TABLE `currencies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karmas`
--

DROP TABLE IF EXISTS `karmas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karmas` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `hashed_ip_address` varchar(130) COLLATE utf8mb4_general_ci NOT NULL,
  `times_banned` tinyint unsigned NOT NULL DEFAULT '0' COMMENT 'How many times user has been banned in the past',
  `banned_till` datetime NOT NULL,
  `softbanned_till` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Dictionary of IP addresses and their karmas';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karmas`
--

LOCK TABLES `karmas` WRITE;
/*!40000 ALTER TABLE `karmas` DISABLE KEYS */;
INSERT INTO `karmas` VALUES (7,'4735deb91c8978a41b21ca258fd2823af84733c032aeb2865cddda52ca7d8bb5d925c1b6e3bca040cdc52abf1c91cbaa30245aafd886ea6d3c7f57fe3820c698',0,'0001-01-01 00:00:00','0001-01-01 00:00:00'),(8,'c906c243d4bb1a2cd958da13ad1f53504e3e3d4271d3ac1c2d16f3743a75be31acea6e7d390e0f5b1d95487659ac8d027f53b0d1ca1a6eb04bf16f0ed4bf5c5e',0,'0001-01-01 00:00:00','0001-01-01 00:00:00');
/*!40000 ALTER TABLE `karmas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logs` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `date_time` datetime NOT NULL,
  `sender` varchar(128) COLLATE utf8mb4_general_ci NOT NULL,
  `message` varchar(512) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logs`
--

LOCK TABLES `logs` WRITE;
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `id` char(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Unique and anonymous payment ID in hash, also used in payment URL',
  `login` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Login of the account balance of which is being topped up',
  `external_payment_id` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Payment ID of an extertal payments service',
  `address_to_pay_to` varchar(256) COLLATE utf8mb4_general_ci NOT NULL,
  `when_created` datetime NOT NULL,
  `to_be_paid_till` datetime NOT NULL,
  `status` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Current payment status, mostly for informing a user',
  `is_paid` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='All payments ever existed';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requests` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `date_time` datetime NOT NULL,
  `hashed_ip_address` bigint unsigned NOT NULL,
  `successful` tinyint(1) NOT NULL,
  `request` varchar(128) COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT 'What resource was requested',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='The journal of all requests to the system. Mainly used for karma calculation';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requests`
--

LOCK TABLES `requests` WRITE;
/*!40000 ALTER TABLE `requests` DISABLE KEYS */;
INSERT INTO `requests` VALUES (67,'2024-03-13 23:22:48',8,1,'registration'),(68,'2024-03-14 14:50:37',8,1,'idk'),(69,'2024-03-14 14:50:38',8,0,'login'),(70,'2024-03-14 14:51:26',8,1,'idk'),(71,'2024-03-14 14:51:28',8,0,'login'),(72,'2024-03-14 14:57:20',8,1,'idk'),(73,'2024-03-14 14:57:21',8,0,'login'),(74,'2024-03-14 14:58:22',8,1,'idk'),(75,'2024-03-14 14:58:23',8,0,'login'),(76,'2024-03-14 15:01:05',8,1,'idk'),(77,'2024-03-14 15:01:07',8,1,'login'),(78,'2024-03-14 21:20:42',8,1,'registration'),(79,'2024-03-14 21:21:41',8,1,'idk'),(80,'2024-03-14 21:21:42',8,1,'login'),(81,'2024-03-14 21:25:36',8,1,'registration'),(82,'2024-03-14 21:25:47',8,1,'idk'),(83,'2024-03-14 21:25:48',8,1,'login'),(84,'2024-03-14 21:26:23',8,1,'idk'),(85,'2024-03-14 21:26:25',8,1,'login'),(86,'2024-03-14 21:27:09',8,1,'idk'),(87,'2024-03-14 21:27:11',8,1,'login'),(88,'2024-03-15 20:32:22',8,1,'registration'),(89,'2024-03-15 20:32:42',8,1,'idk'),(90,'2024-03-15 20:32:43',8,1,'login'),(91,'2024-03-15 20:43:52',8,1,'registration'),(92,'2024-03-15 20:44:03',8,1,'idk'),(93,'2024-03-15 20:44:05',8,1,'login'),(94,'2024-03-15 20:45:23',8,1,'idk'),(95,'2024-03-15 20:45:25',8,1,'login'),(96,'2024-03-15 20:45:30',8,1,'idk'),(97,'2024-03-15 20:45:32',8,1,'login'),(98,'2024-03-15 20:45:37',8,1,'idk'),(99,'2024-03-15 20:45:39',8,1,'login'),(100,'2024-03-15 20:46:16',8,1,'registration'),(101,'2024-03-15 20:46:28',8,1,'idk'),(102,'2024-03-15 20:46:29',8,1,'login'),(103,'2024-03-15 21:24:25',8,1,'registration'),(104,'2024-03-15 21:24:46',8,1,'idk'),(105,'2024-03-15 21:24:48',8,1,'login'),(106,'2024-03-15 21:32:24',8,1,'registration'),(107,'2024-03-15 21:32:34',8,1,'idk'),(108,'2024-03-15 21:32:35',8,1,'login');
/*!40000 ALTER TABLE `requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'floppyvpn_db'
--
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-18 18:02:40
