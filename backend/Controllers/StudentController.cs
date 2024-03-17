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
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth.ToString("dd-MM-yyyy"),
                NameOfFather = x.NameOfFather,
                NameOfMother = x.NameOfMother,
                Grade = x.Grade,
                Section = x.Section,
                DateOfStart = x.DateOfStart.ToString("dd-MM-yyyy")
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
            var grade = await _context.Students.OrderBy(x => x.Grade).Select(x => new GradeGetModel(x.Grade))
                .Distinct().ToListAsync();

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
                    DateOfStart = model.DateOfStart.ToUniversalTime()
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
