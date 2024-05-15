-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2024 at 02:33 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `child_vaccine`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_login`
--

CREATE TABLE `admin_login` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `child_info`
--

CREATE TABLE `child_info` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `sex` varchar(10) NOT NULL,
  `birthdate` datetime NOT NULL,
  `place_of_birth` varchar(50) NOT NULL,
  `birth_method` varchar(50) NOT NULL,
  `child_blood_type` varchar(5) NOT NULL,
  `brgy` varchar(50) NOT NULL,
  `purok` varchar(50) NOT NULL,
  `mother_fname` varchar(50) NOT NULL,
  `mother_mname` varchar(50) NOT NULL,
  `mother_lname` varchar(50) NOT NULL,
  `mother-blood_type` varchar(50) NOT NULL,
  `mother_citizenship` varchar(50) NOT NULL,
  `mother_occupation` varchar(50) NOT NULL,
  `father_fname` varchar(50) NOT NULL,
  `father_mname` varchar(50) NOT NULL,
  `father_lname` varchar(50) NOT NULL,
  `father_blood_type` varchar(5) NOT NULL,
  `father_citizenship` varchar(50) NOT NULL,
  `father_occupation` varchar(50) NOT NULL,
  `contact_number` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `shot_records`
--

CREATE TABLE `shot_records` (
  `id` int(11) NOT NULL,
  `child_id` int(11) NOT NULL,
  `vaccine_id` int(11) NOT NULL,
  `dose_no` int(50) NOT NULL,
  `shot_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `vaccine_tbl`
--

CREATE TABLE `vaccine_tbl` (
  `id` int(11) NOT NULL,
  `vaccine_name` varchar(50) NOT NULL,
  `vaccine_brand` varchar(50) NOT NULL,
  `dose` int(11) NOT NULL,
  `date_added` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_login`
--
ALTER TABLE `admin_login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `child_info`
--
ALTER TABLE `child_info`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shot_records`
--
ALTER TABLE `shot_records`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vaccine_tbl`
--
ALTER TABLE `vaccine_tbl`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin_login`
--
ALTER TABLE `admin_login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `child_info`
--
ALTER TABLE `child_info`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shot_records`
--
ALTER TABLE `shot_records`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `vaccine_tbl`
--
ALTER TABLE `vaccine_tbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
