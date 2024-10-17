namespace BookingUtil
{
     public static class DBUtil
 {
     public static SqlConnection getDBConn()
     {
         string connectionString = "Data Source=DESKTOP-295VFEG\\SQLEXPRESS;Initial Catalog=Ticket;Integrated Security=True;";
         return new SqlConnection(connectionString);
     }
     }
}
