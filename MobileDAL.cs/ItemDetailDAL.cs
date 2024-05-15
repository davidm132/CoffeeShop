using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ItemDAL.cs
{

    public  class ItemDetailDAL
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
      
        public static SqlConnection connect()
        {
             string connection = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
           SqlConnection con = new SqlConnection(connection);
            if(con.State==ConnectionState.Open)
            {
                con.Close();

            }
            else
            {
                con.Open();
            }


            return con;

        }

        public bool DMLOpperation(string query)
        {
            cmd = new SqlCommand(query, ItemDetailDAL.connect());
           int x= cmd.ExecuteNonQuery();
            if(x==1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public DataTable SelactAll(string query)
        {
            da = new SqlDataAdapter(query, ItemDetailDAL.connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       




    }
}
