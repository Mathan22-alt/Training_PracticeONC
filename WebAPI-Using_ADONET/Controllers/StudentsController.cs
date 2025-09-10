using Microsoft.AspNetCore.Mvc;
using WebAPI_Using_ADONET.Models;
using WebAPI_Using_ADONET.Repository;

namespace WebAPI_Using_ADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _repository;

        public StudentsController(StudentRepository repository)
        {
            _repository = repository;
        }

        // POST: api/students
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            int newId = _repository.AddStudent(student);
            return Ok(new { Id = newId, Message = "Student added successfully" });
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
                return NotFound(new { Message = "Student not found" });

            return Ok(student);
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(students);
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var existing = _repository.GetStudentById(id);
            if (existing == null)
                return NotFound(new { Message = "Student not found" });

            student.Id = id; // make sure id matches
            _repository.UpdateStudent(student);

            return Ok(new { Message = "Student updated successfully" });
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existing = _repository.GetStudentById(id);
            if (existing == null)
                return NotFound(new { Message = "Student not found" });

            _repository.DeleteStudent(id);
            return Ok(new { Message = "Student deleted successfully" });
        }
    }
}
