using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WhiskyGaloreAdmin.Models
{
    public class DailyHours
    {
        public DailyHours()
        {
            this.currentDate = DateTime.Now.ToString("dd/MM/yyyy");
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

                this.staffFullNames = new SortedDictionary<uint, string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    staffFullNames.Add(Convert.ToUInt32(dt.Rows[i]["staffId"].ToString()), dt.Rows[i]["forename"].ToString() + " " + dt.Rows[i]["surname"].ToString());
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("fail !");
            }

        }




        [Required(ErrorMessage = "*can not be blank!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "*only positive numbers")]
        [DisplayName("Hours worked")]
        public double hours { get; set; }

        [DisplayName("Date")]
        public string currentDate { get; set; }

        public SortedDictionary<uint, string> staffIds { get; set; }

        [Required(ErrorMessage = "*can not be blank!, please select member of staff .")]
        [DisplayName("Staff ID")]
        public int staffId { get; set; }


        [DisplayName("Staff Name*")]
        public SortedDictionary<uint, string> staffFullNames { get; set; }

        public DataTable dt { get; set; }


        public void InsertDailyhours(DailyHours s)
        
        {
            System.Diagnostics.Debug.WriteLine("inside");
            System.Diagnostics.Debug.WriteLine(s.staffId.GetType());
            System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(s.currentDate).ToString("yyyy-MM-dd")+" "+ s.hours+ " " + s.staffId);
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = constr;
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insertNewDailyHours", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@icurrentDate", Convert.ToDateTime(s.currentDate).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ihoursWorked", (double)s.hours);
                cmd.Parameters.AddWithValue("@iStaff_staffId", s.staffId);                

                cmd.ExecuteNonQuery();

                con.Close();
                System.Diagnostics.Debug.WriteLine("End !");
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("fail !");
            }

        }
    }
}
