using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTOs;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static readonly List<EmployeeDto> employeeDto = new()
        {
            new EmployeeDto
            {
                Id = 1,
                Name = "Arun",
                Department = "IT",
                Salary = 65000
            },

            new EmployeeDto
            {
                Id = 2,
                Name = "Kumar",
                Department = "Finance",
                Salary = 85000
            },

            new EmployeeDto
            {
                Id = 3,
                Name = "Rahul",
                Department = "IT",
                Salary = 95000
            },

            new EmployeeDto
            {
                Id = 4,
                Name = "Priya",
                Department = "HR",
                Salary = 75000
            },

            new EmployeeDto
            {
                Id = 5,
                Name = "Divya",
                Department = "IT",
                Salary = 110000
            }
        };

        [HttpGet("top")]
        public IActionResult GetTopEmployee()
        {
            var result = employeeDto
                .OrderByDescending(x => x.Salary)
                .Take(3)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary
                })
                .ToList();

            return Ok(result);
        }



    }
}
