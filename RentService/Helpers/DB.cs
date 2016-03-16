using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace RentService.Helpers
{
    public class DB
    {
        private static string connectionString;

        public static void ConnectionString(string sqlServer, string db)
        {
            connectionString = string.Format("Data Source={0};Initial Catalog={1}; Integrated Security=true", sqlServer, db);
        }

        public static string Error { get; set; }


        public static bool CredentialsCheck(Model.UserNew user, string sp)
        {
            using (SqlConnection Sqlcon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sp, Sqlcon);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);

                cmd.Parameters.Add("@IsValid", SqlDbType.Int);
                cmd.Parameters["@IsValid"].Direction = ParameterDirection.Output;
                Sqlcon.Open();

                cmd.ExecuteNonQuery();

                string LoginStatus = cmd.Parameters["@IsValid"].Value.ToString();

                if (LoginStatus == "1" || LoginStatus == "2")
                {

                    if (LoginStatus == "2")
                    {
                        return true; // if a user is admin
                    }
                    else
                    {
                        return true; // if a user is NOT admin
                    }
                }
                else
                {
                    return false; // The Username or Password you entered is incorrect.
                }
            }
        }
       

        public static void Exec(string sp, Dictionary<string, object> parameters) // run insert, update, delete
        {
            Error = string.Empty;

            using (var connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                var command = new SqlCommand(sp, connection)
                {
                    CommandType = CommandType.StoredProcedure

                };

                foreach (var item in parameters)
                {

                    command.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }

                //command.Parameters.AddRange(parameters);


                try
                {
                    connection.Open();

                    int result = command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
            }

        }

        public static List<T> Fill<T>(string sp) where T : new() // run select commands (4)
        {
            return Fill<T>(sp, new Dictionary<string, object>());
        }

        public static List<T> Fill<T>(string sp, Dictionary<string, object> parameters) where T : new()      // (5) fill List with data from DB
        {
            Error = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sp, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                try
                {
                    connection.Open();

                    SqlDataAdapter adpter = new SqlDataAdapter(command);
                    DataSet set = new DataSet();

                    adpter.Fill(set);

                    var table = set.Tables[0];
                    var list = new List<T>();
                    var type = typeof(T);

                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var item = new T();
                        var props = type.GetProperties();

                        foreach (var prop in props)
                        {
                            try
                            {
                                type.InvokeMember(prop.Name, BindingFlags.Public |
                                                             BindingFlags.Instance |
                                                             BindingFlags.SetProperty,
                                                             null, item, new[] { table.Rows[i][prop.Name] });

                            }
                            catch { }
                        }

                        list.Add(item);
                    }

                    connection.Close();

                    return list;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;

                    return null;
                }
            }
        }



    }
}