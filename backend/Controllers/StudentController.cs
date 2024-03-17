using backend.Data;
using backend.Data.Entities;
using backend.Data.Models.Get;
using backend.Data.Models.Post;
using backend.Data.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly ApplicationDBContext _context;
        public readonly StudentValidator _validator;
        
        public StudentController(ApplicationDBContext context, StudentValidator validator) { 
            _context = context;
            _validator = validator;
        }

        /// <summary>
        /// Services for getting all students
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/get/{grade}")]
        public async Task<IActionResult> GetStudent(int grade)
        {
            var student = await _context.Students.Where(x => x.Grade == grade).Select(x =>
            new StudentGetModel{
                Name = x.Name,
                DateOfBirth = x.DateOfBirth.ToString("yyyy-MM-dd"),
                NameOfFather = x.NameOfFather,
                NameOfMother = x.NameOfMother,
                Grade = x.Grade,
                Section = x.Section,
                DateofStart = x.DateofStart.ToString("yyyy-MM-dd")
            }).ToListAsync();
            if(student == null)
                return NoContent();
            return Ok(student);
        }

        /// <summary>
        /// Services for getting all grades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/get/grade")]
        public async Task<IActionResult> GetGrade()
        {
            var grade = await _context.Students.Select(x => x.Grade).Distinct().ToListAsync();
            if(grade == null)
                return NoContent();
            return Ok(grade);
        }

        /// <summary>
        /// Services for adding a student
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/add")]
        public async Task<IActionResult> AddStudent([FromBody] StudentPostModel model)
        {
            try
            {
                _validator.ValidateStudentPostModel(model);
                await _context.Students.AddAsync(new Student
                {
                    Name = model.Name,
                    DateOfBirth = model.DateOfBirth.ToUniversalTime(),
                    NameOfFather = model.NameOfFather,
                    NameOfMother = model.NameOfMother,
                    Grade = model.Grade,
                    Section = model.Section,
                    DateofStart = model.DateofStart.ToUniversalTime()
                });
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}
