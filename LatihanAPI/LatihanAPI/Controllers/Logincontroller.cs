using LatihanAPI.Models;    
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
public record LoginRequest(string email, string password);
private IConfiguration _configuration;
namespace LatihanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logincontroller : ControllerBase
    {
        BooksContext db;
        IConfiguration configuration; 

        public Logincontroller(BooksContext _db, IConfiguration _configuration)
        {
            db = _db;
            configuration = _configuration;
        }
        // POST api/<Logincontroller>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest data)
        {
            var query = db.Users.FirstOrDefault(x => x.Email == data.email);

            if (query == null)
            {
                return NotFound(new { message = "Email tidak ditemukan" });
            }

            if (query.PasswordUser != data.password)
            {
                return BadRequest(new { message = "Password salah" });
            }
            return Ok(new) 
            {
                message = "Login berhasil",
                data = new
                {
                    id = query.Id,
                    email = query.Email,
                    name = query.NameUser,
                    role = query.RolesId
                }
            }
        }
    }
}
