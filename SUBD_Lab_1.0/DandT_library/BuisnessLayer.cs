using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace DandT_library
{
    public class BuisnessLayer
    {
        DataBase db = new DataBase();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        public string passFunction(string login, string password)
        {
            string str1 = "пользователь авторизован!\n";
            string str2 = "неверный логин или пароль\n";
            
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @l AND `password`= @p", db.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                db.closeConnection();
                return str1;
            }
            else
            {
                db.closeConnection();
                return str2;
            }

            
        }
        public void UserRegistration(string login, string password)
        {
            if (isUserExists(login))
                return;
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (login, password) values (@l, @p)", db.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
                Console.WriteLine("Пользователь зарегистрирован!\n");
            else
                Console.WriteLine("что-то пошло не так...\n");

            db.closeConnection();

            

        }
        public Boolean isUserExists(string login)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @l", db.getConnection());
            command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
