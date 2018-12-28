using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace SQL_UI
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            //we establish a connection only once when the request has been made, and then it kills it without keeping it open
            //helper is used here as well, we call Helper.CnnVall and we passing the name of DB we require
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                return connection.Query<Person>($"select * from People where LastName ='{ lastName }'").ToList();
            }
        }
    }
}
