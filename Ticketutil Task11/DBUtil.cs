using System;
using System.Data.SqlClient;
namespace Ticketutil
{
    public static class DBUtil
    {
        public static string GetConnectionString()
        {
            return "Data Source=DESKTOP-295VFEG\\SQLEXPRESS;Initial Catalog=Ticket;Integrated Security=True;Trust Server Certificate=True;";
        }


        public static SqlConnection GetDBConn()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            conn.Open(); 
            return conn; 
        }
    }
}

