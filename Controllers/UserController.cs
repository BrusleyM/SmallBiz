using Microsoft.AspNetCore.Mvc;
using SmallBizAPI.Models;
using SmallBizAPI.Repositories.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    /// Gets all users from the database.
    /// <returns>A list of User objects.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    /// Gets a user by ID.
    /// <param name="id">The ID of the user to get.</param>
    /// <returns>The user with the given ID if found, otherwise NotFound.</returns>
    [HttpGet("byId/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
    /// <summary>
    /// Creates a new user in the system.
    /// </summary>
    /// <param name="user">The user object to be created. This must be passed in the request body.</param>
    /// <returns>A CreatedAtAction result containing the created user and a route to get it by ID, or a BadRequest if the model state is invalid.</returns>
    [HttpPost("add")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _userRepository.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    /// <summary>
    /// Updates a user with the given ID.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="user">The user object containing the updated values. This must be passed in the request body.</param>
    /// <returns>A NoContent result if the update is successful, or a NotFound if the user does not exist.</returns>
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null)
            return NotFound();

        _userRepository.UpdateUserAsync(existingUser);


        return NoContent();
    }

    /// <summary>
    /// Deletes a user by ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <returns>No content if the deletion was successful, or NotFound if the user does not exist.</returns>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        _userRepository.Delete(user);

        return NoContent();
    }

}
