using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;
using SafeTracSecondTest.Models;
using SafeTracSecondTest.Models.Dto;

namespace SafeTracSecondTest.Controllers
{
    public class UsersController : Controller
    {
        private SafeTracSecondTestDbContext db = new SafeTracSecondTestDbContext();

        // GET: Users
        public ActionResult IndexP1(UserFilterDTO search)
        {
            UserFilterDTO userFilter = new UserFilterDTO();
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["SafeTracSecondTestDbContext"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cnnString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("GetUsers", connection);
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = search.First_Name;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = search.Last_Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = search.Email_Address;
                command.Parameters.Add("@DateCreated", SqlDbType.NVarChar).Value = search.Date_Created.HasValue ? search.Date_Created.Value.ToString("yyyy-MM-dd") : null;
                command.Parameters.Add("@SortBy", SqlDbType.NVarChar).Value = search.Sort_Order;
                command.Parameters.Add("@SortDirection", SqlDbType.Bit).Value = search.Sort_Direction;
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    sda.SelectCommand = command;

                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        userFilter.UserDTOs = (from DataRow dr in ds.Tables[0].Rows
                                               select new UserDTO
                                               {
                                                   Id = int.Parse(dr["Id"].ToString()),
                                                   First_Name = dr["First_Name"].ToString(),
                                                   Last_Name = dr["Last_Name"].ToString(),
                                                   Email_Address = dr["Email_Address"].ToString(),
                                                   Date_Created = DateTime.Parse(dr["Date_Created"].ToString()),
                                                   Date_Created_AU_Format = ConvertAustralianUserFriendlyDateFormat(DateTime.Parse(dr["Date_Created"].ToString())),
                                               }).ToList();
                    }
                }
            }
            return View(userFilter);
        }

        public ActionResult IndexP2(UserFilterDTO search)
        {
            UserFilterDTO userFilter = new UserFilterDTO();
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["SafeTracSecondTestDbContext"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cnnString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("GetUsers", connection);
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = search.First_Name;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = search.Last_Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = search.Email_Address;
                command.Parameters.Add("@DateCreated", SqlDbType.NVarChar).Value = search.Date_Created.HasValue? search.Date_Created.Value.ToString("yyyy-MM-dd") : null;
                command.Parameters.Add("@SortBy", SqlDbType.NVarChar).Value = search.Sort_Order;
                command.Parameters.Add("@SortDirection", SqlDbType.Bit).Value = search.Sort_Direction;
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    command.Connection = connection;
                    sda.SelectCommand = command;

                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        userFilter.UserDTOs = (from DataRow dr in ds.Tables[0].Rows
                                         select new UserDTO
                                         {
                                             Id = int.Parse(dr["Id"].ToString()),
                                             First_Name = dr["First_Name"].ToString(),
                                             Last_Name = dr["Last_Name"].ToString(),
                                             Email_Address = dr["Email_Address"].ToString(),
                                             Date_Created = DateTime.Parse(dr["Date_Created"].ToString()),
                                             Date_Created_AU_Format = ConvertAustralianUserFriendlyDateFormat(DateTime.Parse(dr["Date_Created"].ToString())),
                                         }).ToList();
                    }
                }
            }

            return View(userFilter);
        }

        private string ConvertAustralianUserFriendlyDateFormat(DateTime date)
        {
            DateTimeFormatInfo cfg = CultureInfo.GetCultureInfo("en-AU").DateTimeFormat;
            return date.Day + " " + cfg.GetMonthName(date.Month) + " " + date.Year;
        }
    }
}
