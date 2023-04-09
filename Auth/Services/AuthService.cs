using Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Auth.Services
{
    public  class AuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {

            _config = config;
        }


        public async Task<AuthResponse> GetUserAsync(AuthRequest authRequest)
        {
            var conString = _config.GetConnectionString("AuthDatabase").ToString();
            SqlConnection conn = new SqlConnection();
            string password;
            if (authRequest == null)
            {
                throw new ArgumentNullException(nameof(authRequest));
            }

            try
            {


                
                conn.ConnectionString = conString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[spGetUser]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserName", authRequest.UserName));
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    return new AuthResponse();
             
                }
                var result = new AuthResponse();
                //while (dr.Read())
                //{
                password = dr["PassWord"].ToString();
                if (authRequest.Password != password)
                {
                    return null;
                }
                var res = dr[1].ToString();
                    result.Username = dr["username"].ToString().Trim();
                    result.FirstName = dr["firstName"].ToString().Trim();
                    result.LastName = dr["lastName"].ToString().Trim();
                    result.Id =  dr["id"].ToString();
                    
                    result.Email = dr["Email"].ToString().Trim();
                    result.RoleName = dr["RoleName"].ToString().Trim();
                    result.IsActive = bool.Parse(dr["Active"].ToString());

                //}

             
             return result;

                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

       
    }
}
