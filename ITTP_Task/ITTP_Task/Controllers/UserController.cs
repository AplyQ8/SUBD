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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
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

        }

        public bool isAdmin(string login, string password)
        {
            string query = @"select login, password where login=@l, password=@p, admin=1";

            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ITTPAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

            }

        }

    }
}
