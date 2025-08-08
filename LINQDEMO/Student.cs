using System.Collections.Generic;
using System.Linq;

namespace LINQDEMO
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Department { get; set; } = string.Empty;
        public List<int> Marks { get; set; } = new List<int>();
    }

    public class LINQDemo
    {
        public List<Student> GetTopCSStudents(List<Student> students)
        {
            return students
                .Where(s => s.Department == "CS" && s.Marks.Average() > 80)
                .ToList();
        }
    }
}
