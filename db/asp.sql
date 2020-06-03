-- phpMyAdmin SQL Dump
-- version 4.9.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jun 03, 2020 at 07:13 PM
-- Server version: 5.7.26
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `asp`
--

-- --------------------------------------------------------

--
-- Table structure for table `categorias`
--

CREATE TABLE `categorias` (
  `id` int(11) NOT NULL,
  `categoria` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categorias`
--

INSERT INTO `categorias` (`id`, `categoria`) VALUES
(0, 'Outros'),
(2, 'Alimentício'),
(3, 'Higiene'),
(4, 'Limpeza');

-- --------------------------------------------------------

--
-- Table structure for table `produtos`
--

CREATE TABLE `produtos` (
  `id` int(11) NOT NULL,
  `nome` varchar(30) NOT NULL,
  `descricao` varchar(50) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `tempo` int(200) NOT NULL,
  `id_categoria` varchar(40) NOT NULL,
  `fornecedor` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `produtos`
--

INSERT INTO `produtos` (`id`, `nome`, `descricao`, `valor`, `quantidade`, `tempo`, `id_categoria`, `fornecedor`) VALUES
(21, 'Biscoito Cream & Cracker', 'Aymoré', '1.90', 100, 0, '1', '0'),
(38, 'Amaciante', 'Baby Soft', '10.00', 1000, 15, '2', 'Mercado Extra'),
(39, 'Amaciante', 'Downy', '15.00', 1000, 60, '2', 'Mercado Carrefour');

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `email` varchar(30) NOT NULL,
  `senha` int(20) NOT NULL,
  `nome` varchar(20) NOT NULL,
  `nivel` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`id`, `email`, `senha`, `nome`, `nivel`) VALUES
(1, 'mariaclara@una.com', 123, 'Maria Clara ', 'admin'),
(2, 'felipe@una.com', 123, 'Felipe', 'admin'),
(3, 'pedro@una.com', 123, 'Pedro', 'admin'),
(4, 'caio@una.com', 123, 'Caio', 'admin'),
(5, 'farouk@una.com', 123, 'Farouk', 'admin ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categorias`
--
ALTER TABLE `categorias`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `produtos`
--
ALTER TABLE `produtos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
