using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WhiskyGaloreAdmin.Models
{
    public class DailyHours
    {
        public DailyHours()
        {
            this.currentDate =DateTime.Now.ToString("dd/MM/yyyy");
            this.dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = constr;
                con.Open();
                MySqlCommand cmd = new MySqlCommand("getStaffIdName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
                EnumerableRowCollection<uint> staffId = from names in dt.AsEnumerable() select names.Field<uint>("staffId");
                this.staffFullNames = new List<string>();
                for(int i = 0; i <dt.Rows.Count; i++) { 
                    staffFullNames.Add(dt.Rows[i]["forename"].ToString()+" "+ dt.Rows[i]["surname"].ToString());
                }
                this.staffIds = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    staffFullNames.Add(dt.Rows[i]["staffId"].ToString());
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("fail !");
            }

        }



        //username table fields
        [DisplayName("Hours worked")]
        public int hours { get; set; }

        [DisplayName("Date")]
        public string currentDate { get; set; }

        public List<string> staffIds { get; set; }

        [DisplayName("Staff ID")]
        public string staffId { get; set; }

        //contact table fields
        [DisplayName("Staff Name*")]
        public List<string> staffFullNames { get; set; }

        public DataTable dt { get; set; }

        //private String con_str = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString.ToString();

       /* public void insertEmployee(DailyHours s)
        {
            using (MySqlConnection con = new MySqlConnection(con_str))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insertNewEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //params for insert into username
                    cmd.Parameters.AddWithValue("@username", s.username);
                    cmd.Parameters.AddWithValue("@password", s.password);
                    cmd.Parameters.AddWithValue("@accountType", s.acctype.ToString());

                    //params for insert into address
                    cmd.Parameters.AddWithValue("@firstLine", s.firstLine);
                    if (s.secondLine != null)
                    {
                        cmd.Parameters.AddWithValue("@secondLine", s.secondLine);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@secondLine", null);
                    }
                    cmd.Parameters.AddWithValue("@town", s.town);
                    cmd.Parameters.AddWithValue("@postcode", s.postcode);
                    cmd.Parameters.AddWithValue("@region", s.region);
                    cmd.Parameters.AddWithValue("@country", s.country);

                    //params for insert into bankDetails
                    cmd.Parameters.AddWithValue("@sortCode", s.sortCode);
                    cmd.Parameters.AddWithValue("@accountNumber", s.accountNumber);

                    //params for insert into contact
                    cmd.Parameters.AddWithValue("@title", s.title.ToString());
                    cmd.Parameters.AddWithValue("@forename", s.forename);
                    cmd.Parameters.AddWithValue("@surname", s.surname);
                    cmd.Parameters.AddWithValue("@firstNumber", s.firstNumber);
                    if (s.secondaryNumber != null)
                    {
                        cmd.Parameters.AddWithValue("@secondaryNumber", s.secondaryNumber);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@secondaryNumber", null);
                    }
                    cmd.Parameters.AddWithValue("@email", s.email);
                    if (s.fax != null)
                    {
                        cmd.Parameters.AddWithValue("@fax", s.fax);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@fax", null);
                    }

                    //params for insert into staff
                    cmd.Parameters.AddWithValue("@role", s.role);
                    cmd.Parameters.AddWithValue("@hourlyRate", s.hourlyRate);
                    cmd.Parameters.AddWithValue("@startDate", Convert.ToDateTime(s.startDate).ToString("yyyy-MM-dd"));


                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }*/
    }
}