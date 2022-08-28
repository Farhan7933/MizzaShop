using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADOMizzaAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string query = "select count(*) from MizzaSize;";
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["MizzaNextItems"].ConnectionString);
            MySqlCommand command = new MySqlCommand(query, con);
            command.CommandType = CommandType.Text;
            con.Open();
            var rowsAffected = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return new string[] { rowsAffected.ToString() };

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
