using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using ITTP_Task.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;

namespace ITTP_Task.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public UserController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPost]

        public JsonResult Post(User user, string login, string password)
        {
            if (!isAdmin(login, password))
            {
                return new JsonResult("Not enough permission for this operation");
            }
            else
            {
                string query = @"insert into dbo.UserTable (guid, login, password, name, gender, birthday, admin, createdOn, createdBy 
                                values (@g, @l, @p, @name, @gen, @birth, @adm, @cO, @cB))";
                DataTable dt = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("ITTPAppCon");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand command = new SqlCommand(query, myCon))
                    {
                        command.Parameters.AddWithValue("@g", user.Guid);
                        command.Parameters.AddWithValue("@l", user.login);
                        command.Parameters.AddWithValue("@p", user.password);
                        command.Parameters.AddWithValue("@name", user.name);
                        command.Parameters.AddWithValue("@gen", user.gender);
                        command.Parameters.AddWithValue("@birth", user.birthday);
                        command.Parameters.AddWithValue("@adm", user.admin);
                        command.Parameters.AddWithValue("@cO", user.createdOn = DateTime.Today);
                        command.Parameters.AddWithValue("@cB", user.createdBy = login);


                        myReader = command.ExecuteReader();
                        dt.Load(myReader); ;
                        myReader.Close();
                        myCon.Close();
                    }
                }
                return new JsonResult("User have been created successfully!");
            }
        }
        [HttpGet]
        public bool isAdmin(string login, string password)
        {
            string query = @"select login, password, admin from dbo.UserTable where (login=@l and password=@p and admin=1) ";

            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ITTPAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand command = new SqlCommand(query, myCon))
                {
                    command.Parameters.AddWithValue("@l", login);
                    command.Parameters.AddWithValue("@p", password);
                    myReader = command.ExecuteReader();
                    dt.Load(myReader);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

        }
        
    }
}
