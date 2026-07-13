using Microsoft.AspNetCore.Mvc;
using RetailInventoryAPI.Filters;
using RetailInventoryAPI.Models;

namespace RetailInventoryAPI.Controllers;

[ApiController]
[Route("api/Emp")]
[CustomAuthFilter]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees = [];

    public EmployeeController()
    {
        if (Employees.Count == 0)
        {
            Employees.AddRange(GetStandardEmployeeList());
        }
    }

    [HttpGet(Name = "GetStandardEmployees")]
    [ProducesResponseType(
        typeof(IEnumerable<Employee>),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<Employee>> GetStandard()
    {
        return Ok(Employees);
    }

    [HttpGet("{id:int}", Name = "GetEmployeeById")]
    [ProducesResponseType(
        typeof(Employee),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Employee> Get(int id)
    {
        var employee = Employees
            .FirstOrDefault(employee => employee.Id == id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType(
        typeof(Employee),
        StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> Post(
        [FromBody] Employee employee)
    {
        if (employee.Id <= 0)
        {
            employee.Id = Employees.Max(item => item.Id) + 1;
        }

        Employees.Add(employee);

        return CreatedAtAction(
            nameof(Get),
            new { id = employee.Id },
            employee);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(
        typeof(Employee),
        StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> Put(
        int id,
        [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee = Employees
            .FirstOrDefault(item => item.Id == id);

        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;
        existingEmployee.Department = employee.Department;
        existingEmployee.Skills = employee.Skills;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        return Ok(existingEmployee);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var employee = Employees
            .FirstOrDefault(item => item.Id == id);

        if (employee == null)
        {
            return BadRequest("Invalid employee id");
        }

        Employees.Remove(employee);

        return NoContent();
    }

    [HttpGet("exception")]
    [CustomExceptionFilter]
    [ProducesResponseType(
        StatusCodes.Status500InternalServerError)]
    public ActionResult TestException()
    {
        throw new InvalidOperationException(
            "Test exception from EmployeeController.");
    }

    private static List<Employee> GetStandardEmployeeList()
    {
        return
        [
            new Employee
            {
                Id = 1,
                Name = "Adithya",
                Salary = 50000,
                Permanent = true,
                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                Skills =
                [
                    new Skill
                    {
                        Id = 1,
                        Name = "C#"
                    },
                    new Skill
                    {
                        Id = 2,
                        Name = "ASP.NET Core"
                    }
                ],
                DateOfBirth = new DateTime(2002, 5, 15)
            },
            new Employee
            {
                Id = 2,
                Name = "Ananya",
                Salary = 45000,
                Permanent = false,
                Department = new Department
                {
                    Id = 2,
                    Name = "Quality Assurance"
                },
                Skills =
                [
                    new Skill
                    {
                        Id = 3,
                        Name = "Testing"
                    }
                ],
                DateOfBirth = new DateTime(2001, 9, 10)
            }
        ];
    }
}