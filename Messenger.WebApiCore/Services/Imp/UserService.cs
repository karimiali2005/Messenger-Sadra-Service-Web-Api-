using System;
using System.Data;
using System.Data.SqlClient;
using Messenger.WebApiCore.Classes;
using Messenger.WebApiCore.Services.Interface;

namespace Messenger.WebApiCore.Services.Imp
{
    public class UserService : IUserService
    {
        #region ~( Methods )~
        public void OnConnectApp(int userId, string idConnectionSignalR, int loginType, string ip, int appVersion, string androidVersion, string mobileName)
        {
            try
            {
                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("mesLoginInsert", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.AddWithValue("@FkfUser", userId);
                        sqlCommand.Parameters.AddWithValue("@idConnectionSignalR", idConnectionSignalR);
                        sqlCommand.Parameters.AddWithValue("@loginType", loginType);
                        sqlCommand.Parameters.AddWithValue("@connectDateTime", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@disconnectDateTime", DBNull.Value);
                        sqlCommand.Parameters.AddWithValue("@comment", "");
                        sqlCommand.Parameters.AddWithValue("@ip", ip);
                        sqlCommand.Parameters.AddWithValue("@appVersion", appVersion);
                        sqlCommand.Parameters.AddWithValue("@androidVersion", androidVersion);
                        sqlCommand.Parameters.AddWithValue("@mobileName", mobileName);






                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();

                            // Customer ID is an IDENTITY value from the database.

                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnDisConnectApp(string idConnectionSignalR)
        {
            try
            {
                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("mesLoginUpdate", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.AddWithValue("@idConnectionSignalR", idConnectionSignalR);
                        sqlCommand.Parameters.AddWithValue("@disconnectDateTime", DateTime.Now);

                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();

                            // Customer ID is an IDENTITY value from the database.

                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckOnline(int userId)
        {
            try
            {


                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("mesCheckOnline", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.AddWithValue("@FkfUser", Convert.ToInt32(userId));

                        // Add the output parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@IsOnline", SqlDbType.Bit));
                        sqlCommand.Parameters["@IsOnline"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteReader();


                            return (bool)sqlCommand.Parameters["@IsOnline"].Value;


                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTokenFireBase(int userId)
        {
            try
            {


                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("mesUserGetByID", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.AddWithValue("@pkfUser", Convert.ToInt32(userId));


                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            SqlDataReader dr = sqlCommand.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                var tokenFireBase = dr["tokenFireBase"].ToString();
                                return tokenFireBase;
                            }




                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            connection.Close();
                        }
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public mesSetting GetSettingFireBase()
        {
            try
            {


                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("Select * FROM mesSetting", connection))
                    {

                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            SqlDataReader dr = sqlCommand.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                var setting = new mesSetting()
                                {
                                    serverKeyFireBase = dr["serverKeyFireBase"].ToString(),
                                    senderIdFireBase = dr["senderIdFireBase"].ToString(),
                                    webAddr = dr["webAddr"].ToString()
                                };
                                return setting;

                            }




                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            connection.Close();
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateIsFireBase(int pkfMessage)
        {
            try
            {


                using (var connection = new SqlConnection(Startup._connection))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (var sqlCommand = new SqlCommand("Update mesMessage Set IsFireBase=1 Where pkfMessage=" + pkfMessage, connection))
                    {


                        // Add input parameter for the stored procedure and specify what to use as its value.
                        //sqlCommand.Parameters.AddWithValue("@pkfUser", Convert.ToInt32(userId));


                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();





                        }
                        catch (Exception ex)
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            throw ex;
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                            connection.Close();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
