using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace lab9
{
    class DataManagement
    {
        public string connectionString { get; private set; }
        private ConnectionStringSettings connectionSettings;
        public DataManagement()
        {
            ConnectionStringSettingsCollection settings =
               ConfigurationManager.ConnectionStrings;

            string connectionString;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    if (cs.Name == "Actor")
                        connectionSettings = cs;
                }
            }


        }
       
        public int InsertActor(Actor actor)
        {
            //Create the SQL Query for inserting an actor
            string sqlQuery = String.Format("Insert into Actor (Name, Surname) Values('{0}', '{1}'); "
           + "Select @@Identity", actor.Name, actor.Surname);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(connectionSettings.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Execute the command to SQL Server and return the newly created ID
            int newActorID = Convert.ToInt32((decimal)command.ExecuteScalar());

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            return newActorID;
        }
        public List<Actor> GetActors()
        {
            List<Actor> result = new List<Actor>();

            //Create the SQL Query for returning all the actors
            string sqlQuery = String.Format("select * from Actor");

            //Create and open a connection to SQL Server 

            SqlConnection connection = new SqlConnection(connectionSettings.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new Actor
                    {

                        Id = Convert.ToInt32(dataReader["Id"]),
                        Name = dataReader["Name"].ToString(),
                        Surname = dataReader["Surname"].ToString()
                    });
                }
            }


            return result;

        }
        public List<Actor> GetActorsBySurname(Actor actor)
        {
            List<Actor> result = new List<Actor>();

            //Create the SQL Query for returning all the actors
            string sqlQuery = String.Format("select * from Actor where surname = '{0}'", actor.Surname);

            //Create and open a connection to SQL Server 

            SqlConnection connection = new SqlConnection(connectionSettings.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            
            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new Actor
                    {

                        Id = Convert.ToInt32(dataReader["Id"]),
                        Name = dataReader["Name"].ToString(),
                        Surname = dataReader["Surname"].ToString()
                    });
                }
            }

            return result;
        }

        public bool UpdateActor(Actor actor, Actor newActor)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("update Actor set name = '{0}', surname = '{1}' where name = '{2}' and surname = '{3}' "
                , newActor.Name, newActor.Surname, actor.Name, actor.Surname);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(connectionSettings.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }
        public bool DeleteActor(Actor actor)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Actor where name = '{0}' and surname = '{1}'", actor.Name, actor.Surname);

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(connectionSettings.ConnectionString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }

    }
}
