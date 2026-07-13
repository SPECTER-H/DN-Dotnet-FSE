using Microsoft.AspNetCore.Mvc;

namespace RetailInventoryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private static readonly List<string> Values =
        ["value1", "value2"];

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok(Values);
    }

    [HttpGet("{id:int}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 1 || id > Values.Count)
        {
            return NotFound();
        }

        return Ok(Values[id - 1]);
    }

    [HttpPost]
    public ActionResult<string> Post([FromBody] string value)
    {
        Values.Add(value);

        return CreatedAtAction(
            nameof(Get),
            new { id = Values.Count },
            value);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        if (id < 1 || id > Values.Count)
        {
            return NotFound();
        }

        Values[id - 1] = value;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (id < 1 || id > Values.Count)
        {
            return NotFound();
        }

        Values.RemoveAt(id - 1);
        return NoContent();
    }
}