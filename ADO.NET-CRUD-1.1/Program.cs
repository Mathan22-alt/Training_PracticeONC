using Azure;
using Microsoft.Data.SqlClient;
//appsettings
//user credatinlsssss on db 

internal class Program
{
    static string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADO.NET-DATA;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("ENTER THE OPTION ");
            Console.WriteLine("1.InsertDATA");
            Console.WriteLine("2.ReadDATA");
            Console.WriteLine("3.RemoveDATA");
            Console.WriteLine("4.UpdateData");
            Console.WriteLine("5.Exit");


            Console.Write("Ennter the choice");
            int choice = Convert.ToInt32(Console.ReadLine());
           

            switch (choice)
            {
                case 1:
                    InsertData();
                    break;
                case 2: ReadData(); break;
                case 3: RemoveData(); break;
                case 4: UpdateData(); break;
                case 5: return;

            }
            static void ReadData()
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {conn.Open();
                    string query = "select name ,age,id from students";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\n--- Students ---");

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
                    }
                }

            }
            static void InsertData()
            {
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter age");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the id");
                int id = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query = "Insert into students(name,age,id)values(@name,@age,@id)";
                    SqlCommand cmd = new SqlCommand(query,con);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rows} row(s) added.");

                }
            }
            static void RemoveData()
            {
                Console.WriteLine("enter the id ");
                int id = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query = "delete from students where id=@id";
                    SqlCommand cmd = new SqlCommand(query,con);

                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rows} row(s) deleted.");
                }
            }
            static void UpdateData()
            {
                Console.WriteLine("Enter the Id : ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the name :");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the age :");
                int age =  Convert.ToInt32(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    string query = "UPDATE students SET name = @name, age = @age WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);

                
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rows} row(s) updated.");


                }
                }
        }
    }
}