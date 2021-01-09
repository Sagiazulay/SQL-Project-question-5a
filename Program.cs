using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Targil5a
{
    class Program
    {
        static bool TestDbConnection(string conn)
        {
            try
            {
                using (var my_conn = new NpgsqlConnection(conn))
                {
                    my_conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static void a_sp_workers_position_name(string conn_string)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "a_sp_workers_position_name";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //(id bigint,text name, phone text, role text)
                List<Worker> workers = new List<Worker>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = (int)reader["id"];
                    string Name = (string)reader["name"];
                    string phone = (string)reader["phone"];
                    string role = (string)reader["role"];

                   workers.Add(new Worker(id = (int)reader["id"], Name = (string)reader["Name"], phone = (string)reader["Phone"], role = (string)reader["Role"]));
                    Console.WriteLine(workers);
                }
                //return new Worker(id = (long)reader["id"], name = (string)reader["Name"], phone = (string)reader["Phone"], role = (string)reader["Role"]);
            }
        }

        static void Main(string[] args)
        {
            string conn_string = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
            a_sp_workers_position_name(conn_string);
        }
    }
}
