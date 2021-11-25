using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Lab_library
{
    public class BuisnesLayer
    {
        DataBase db = new DataBase();

        public void passFunction(string login, string password)
        {           
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @l AND `password`= @p", db.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
                Console.WriteLine("пользователь авторизован!\n");
            else
                Console.WriteLine("неверный логин или пароль\n");
        }
    }
}
