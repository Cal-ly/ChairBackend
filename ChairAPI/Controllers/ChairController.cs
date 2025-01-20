namespace ChairAPI.Controllers;

using ChairLib;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChairController : ControllerBase
{
    private readonly ChairRepository _repository;

    public ChairController()
    {
        _repository = new ChairRepository();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Chair>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Chair> GetById(int id)
    {
        try
        {
            return Ok(_repository.GetById(id));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Chair> Add(Chair chair)
    {
        try
        {
            var addedChair = _repository.Add(chair);
            return CreatedAtAction(nameof(GetById), new { id = addedChair.Id }, addedChair);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Chair> Delete(int id)
    {
        try
        {
            var deletedChair = _repository.Delete(id);
            return Ok(deletedChair);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
