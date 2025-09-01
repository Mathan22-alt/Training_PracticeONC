using Microsoft.Data.SqlClient;


public class Program
{
    public static void Main(string[] args)
    {
        SqlConnection conn = new SqlConnection("server=mazenet-test;" +
            "Integrated Security=true;" +
            "database=management;TrustServerCertificate=true");
        conn.Open();

        string query = "select empid ,empname ,empdept from employee";

        SqlCommand cmd = new SqlCommand(query, conn);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {

            int empId = Convert.ToInt32(reader["empid"]);   // use quotes around column name
            string empName = reader["empname"].ToString(); // same here
            string empDept = reader["empdept"].ToString();

            Console.WriteLine($"{empId},{empName},{empDept}");
        }
        reader.Close();
        conn.Close();
    }
}