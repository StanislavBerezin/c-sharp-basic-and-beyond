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
                //raw way of calling sql database, but can be tampered with sql injections
                //return connection.Query<Person>($"select * from People where LastName ='{ lastName }'").ToList();

                //we need to have alter procedure, in DB itself, where we define this search and here simply call it
                //then we create a dynamic class with LastName which matches @LastName with prop lastName
                //Not possible to tamper with SQL injection
                return connection.Query<Person>("dbo.Person.GetByLastName @LastName", new { LastName = lastName }).ToList();
            }
        }

        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };

                List<Person> people =  new List<Person>();

                people.Add(newPerson);

                connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);

            }
        }
    }
}
