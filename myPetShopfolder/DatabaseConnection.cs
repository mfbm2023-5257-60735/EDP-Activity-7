using System;
using MySql.Data.MySqlClient;

namespace PetShopInventory
{
    public class DatabaseConnection
    {
        // This is the magic string that connects to your XAMPP phpMyAdmin
        private string connectionString = "Server=localhost;Database=petshop_db;Uid=root;Pwd=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}