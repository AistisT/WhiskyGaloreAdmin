using System;
using System.Linq;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;




namespace WhiskyGaloreAdmin.Models
{
    public class Product
    {
        public Product()
        {
            this.dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = constr;
                con.Open();
                MySqlCommand cmd = new MySqlCommand("getProductInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("fail !");
            }
        }

        public DataTable dt { get; set; }
    }
}