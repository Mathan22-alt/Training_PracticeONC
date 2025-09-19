using System.Data;
using Microsoft.Data.SqlClient;   // ✅ Use Microsoft.Data.SqlClient (latest)
using WebAPI_Using_ADONET.Models;

namespace WebAPI_Using_ADONET.Repository
{
    public class StudentRepository
    {
        // Non-nullable readonly string
        private readonly string _connectionString;

        // Constructor - fetches connection string from appsettings.json
        public StudentRepository(IConfiguration configuration)
        {
            // Read "DefaultConnection" from appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new ArgumentNullException("DefaultConnection",
                                  "Connection string 'DefaultConnection' is missing in appsettings.json");
        }

        // ------------------- CRUD OPERATIONS -------------------

        // Add Student
        public int AddStudent(Student student)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("AddStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);

            conn.Open();
            return (int)cmd.ExecuteScalar();  // Stored procedure returns new Id
        }

        // Get Student by Id
        public Student? GetStudentById(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("GetStudentById", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Student
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()!,
                    Age = (int)reader["Age"]
                };
            }
            return null;
        }

        // Get All Students
        public List<Student> GetAllStudents()
        {
            List<Student> students = new();
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("GetAllStudents", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()!,
                    Age = (int)reader["Age"]
                });
            }
            return students;
        }
        //HAVE TO USE TRY CATCH TO AVOID ERRORS
        // USE ASYNC AWAIT//
        // USe INETRFACE

        // Update Student
        public void UpdateStudent(Student student)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // Delete Student
        public void DeleteStudent(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("DeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
