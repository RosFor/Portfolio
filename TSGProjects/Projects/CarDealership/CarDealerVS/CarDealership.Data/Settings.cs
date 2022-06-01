﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _repository;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return _connectionString;
        }

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repository))
                _repository = ConfigurationManager.AppSettings["RepositoryType"].ToString();

            return _repository;
        }
    }
}
