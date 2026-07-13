using Microsoft.AspNetCore.Mvc;
using RetailInventoryAPI.Models;

namespace RetailInventoryAPI.Controllers;

[ApiController]
[Route("api/Emp")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees =
    [
        new Employee
        {
            Id = 1,
            Name = "Adithya"
        },
        new Employee
        {
            Id = 2,
            Name = "Ananya"
        }
    ];

    [HttpGet(Name = "GetEmployees")]
    [ProducesResponseType(
        typeof(IEnumerable<Employee>),
        StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Employee>> Get()
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
}