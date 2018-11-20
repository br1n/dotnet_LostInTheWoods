using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using LostInTheWoods.Models;
using MySql.Data.MySqlClient;
using System.Linq;
using Microsoft.Extensions.Options;

namespace LostInTheWoods.Factories
{
    public class TrailFactory
    {
         static string server = "localhost";
        static string db = "trails"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection 
        {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        //get trail by {Id}
        public Trail GetTrailById(int Id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "SELECT * FROM trail WHERE Id = @Id";
                var param = new {ID=Id};
                var resultCollection = dbConnection.Query<Trail>(query, param);
                return resultCollection.FirstOrDefault();
            }
        }
        //get all trails
        public List<Trail> GetAllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = "SELECT * FROM trail";
                   dbConnection.Open();
                   return dbConnection.Query<Trail>(query).ToList();

                }
            }
        }

        // add a new trail
        public void Create(Trail newTrail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "INSERT INTO trail (Name, Description, Length, Elevation, Longitude, Latitude, CreatedAt) VALUES (@Name, @Description, @Length, @Elevation, @Longitude, @Latitude, @CreatedAt)";
                //Execute requires a string query
                dbConnection.Execute(query, newTrail);
            }
        }
    }
}